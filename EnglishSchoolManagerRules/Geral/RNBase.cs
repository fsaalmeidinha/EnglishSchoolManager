using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EnglishSchoolManagerModel;
using EnglishSchoolManagerModel.Geral;
using EnglishSchoolManagerModel.Enumerador;
using CommonsAPI.Entity;
using System.Data;
using System.Data.Objects.DataClasses;

namespace EnglishSchoolManagerRules.Geral
{
    public abstract class RNBase<Entidade> : IRN<Entidade>
        where Entidade : EntityObject, new()
    {
        #region Propriedades

        protected ESMEntities contexto;
        protected Usuario usuarioAtivo;

        #endregion Propriedades

        #region Construtores

        public RNBase(Usuario usuarioAtivo)
            : this(usuarioAtivo, new ESMEntities())
        {
        }

        public RNBase(Usuario usuarioAtivo, ESMEntities contexto)
        {
            this.usuarioAtivo = usuarioAtivo;
            this.contexto = contexto;
        }

        #endregion Construtores

        #region Métodos

        public Entidade PesquisarPorId(int id)
        {
            string containerName = contexto.DefaultContainerName;
            var objSet = contexto.CreateObjectSet<Entidade>();
            string setName = objSet.EntitySet.Name;
            var entityKey = new EntityKey(containerName + "." + setName, "Id", id);
            object entidade = null;
            contexto.TryGetObjectByKey(entityKey, out entidade);

            if (entidade != null)
            {
                int escolaId = Convert.ToInt32(entidade.GetType().GetProperty("EscolaId").GetValue(entidade, null));
                if (usuarioAtivo.EscolaId != escolaId)
                {
                    entidade = null;
                }
            }

            return entidade as Entidade;
        }

        //public List<Entidade> Listar()
        //{
        //    return contexto.CreateObjectSet<Entidade>().ToList();
        //}

        public Resultado Salvar(Entidade entidade)
        {
            int idEntidadeSalva = 0;
            List<Erro> erros = null;
            try
            {
                erros = validarSalvar(entidade);
                if (erros.Count == 0)
                {
                    int idEntidade = getEntityId(entidade);
                    Entidade entidadeSalvar = new Entidade();

                    PropertiesHelper.CopyProperties(entidade, entidadeSalvar);
                    entidadeSalvar.GetType().GetProperty("EscolaId").SetValue(entidadeSalvar, usuarioAtivo.EscolaId, null);
                    entidadeSalvar.GetType().GetProperty("UsuarioAlteracaoId").SetValue(entidadeSalvar, usuarioAtivo.Id, null);
                    entidadeSalvar.GetType().GetProperty("DataAlteracao").SetValue(entidadeSalvar, DateTime.UtcNow, null);
                    if (idEntidade == 0)
                    {
                        entidadeSalvar.GetType().GetProperty("UsuarioInsercaoId").SetValue(entidadeSalvar, usuarioAtivo.Id, null);
                        entidadeSalvar.GetType().GetProperty("DataInsercao").SetValue(entidadeSalvar, DateTime.UtcNow, null);
                        contexto.CreateObjectSet<Entidade>().AddObject(entidadeSalvar);
                        tratarObjetoSalvar(entidade, null);
                    }
                    else
                    {
                        string containerName = contexto.DefaultContainerName;
                        var objSet = contexto.CreateObjectSet<Entidade>();
                        string setName = objSet.EntitySet.Name;
                        var entityKey = new EntityKey(containerName + "." + setName, "Id", idEntidade);
                        Entidade entidadeBD = contexto.GetObjectByKey(entityKey) as Entidade;

                        tratarObjetoSalvar(entidadeSalvar, entidadeBD);
                        entidadeSalvar = contexto.CreateObjectSet<Entidade>().ApplyCurrentValues(entidadeSalvar);
                    }

                    beforeSave(entidade, entidadeSalvar);

                    contexto.SaveChanges();
                    idEntidadeSalva = getEntityId(entidadeSalvar);
                }
            }
            catch (Exception ex)
            {
                LogRN.GravarLog(ex);
                erros = new List<Erro>();
                erros.Add(new Erro(ErroEnum.ErroDesconhecido));
            }

            return new Resultado(erros, idEntidadeSalva);
        }

        protected virtual void beforeSave(Entidade entidade, Entidade entidadeSalvar)
        {
        }

        protected virtual void tratarObjetoSalvar(Entidade entidade, Entidade entidadeBD)
        {

        }

        protected virtual List<Erro> validarSalvar(Entidade entidade)
        {
            throw new NotImplementedException();
        }

        private int getEntityId(Entidade entidade)
        {
            return Convert.ToInt32((typeof(Entidade).GetProperty("Id").GetValue(entidade, null)));
        }

        #endregion Métodos
    }
}
