using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EnglishSchoolManagerModel;
using EnglishSchoolManagerRules.Geral;
using EnglishSchoolManagerModel.Geral;
using EnglishSchoolManagerModel.Enumerador;

namespace EnglishSchoolManagerRules.Acesso
{
    public class UsuarioRN : RNBase<Usuario>
    {
        #region Construtores

        public UsuarioRN(Usuario usuarioAtivo)
            : base(usuarioAtivo)
        {

        }

        public UsuarioRN(Usuario usuarioAtivo, ESMEntities contexto)
            : base(usuarioAtivo, contexto)
        {

        }

        #endregion Construtores

        #region Métodos

        public List<Usuario> Listar()
        {
            return contexto.Usuarios.Where(usr => usr.EscolaId == usuarioAtivo.EscolaId).ToList();
        }

        public List<Usuario> ListarAlunosAtivosESemAula(int aulaId = 0)
        {
            int nivelAcessoAluno = Convert.ToInt32(NivelAcessoEnum.Aluno);
            return contexto.Usuarios.Where(usr => usr.NivelAcesso == nivelAcessoAluno
                && (usr.AulaId == null || usr.AulaId == aulaId)
                && usr.Ativo == true
                && usr.EscolaId == usuarioAtivo.EscolaId).ToList();
        }

        public static Usuario Autenticar(string email, string senha)
        {
            Usuario usuario = null;
            try
            {
                if (email != null)
                    email = email.ToLower();

                using (ESMEntities contexto = new ESMEntities())
                {
                    usuario = contexto.Usuarios.Include("Escola").FirstOrDefault(usr => usr.Email == email && usr.Senha == senha);
                }

            }
            catch (Exception ex)
            {
                LogRN.GravarLog(ex);
            }

            return usuario;
        }

        protected override List<EnglishSchoolManagerModel.Geral.Erro> validarSalvar(Usuario usuario)
        {
            List<Erro> erros = new List<Erro>();

            if (usuario == null)
            {
                erros.Add(new Erro(ErroEnum.Acesso_UsuarioRN_ValidarSalvar_UsuarioNULL));
                return erros;
            }

            if (usuario.Id > 0)
            {
                Usuario usuarioBD = contexto.Usuarios.FirstOrDefault(usr => usr.Id == usuario.Id && usr.EscolaId == usuarioAtivo.EscolaId);
                if (usuarioBD == null)
                {
                    erros.Add(new Erro(ErroEnum.Acesso_UsuarioRN_ValidarSalvar_UsuarioNaoExistente));
                    return erros;
                }

                if (usuarioBD.Email != usuario.Email)
                {
                    erros.Add(new Erro(ErroEnum.Acesso_UsuarioRN_ValidarSalvar_AlterarEmail));
                    return erros;
                }

                if (usuarioBD.NivelAcesso != usuario.NivelAcesso)
                {
                    erros.Add(new Erro(ErroEnum.Acesso_UsuarioRN_ValidarSalvar_AlterarNivelAcesso));
                    return erros;
                }
            }

            if (usuarioAtivo.NivelAcesso != Convert.ToInt32(NivelAcessoEnum.Administrador) && usuario.Id != usuarioAtivo.Id)
            {
                erros.Add(new Erro(ErroEnum.Acesso_UsuarioRN_ValidarSalvar_UsuarioNaoADM_SalvandoOuAlterandoUsuario));
                return erros;
            }

            if (usuario.NivelAcesso != Convert.ToInt32(NivelAcessoEnum.Administrador) && usuario.NivelAcesso != Convert.ToInt32(NivelAcessoEnum.Aluno))
            {
                erros.Add(new Erro(ErroEnum.Acesso_UsuarioRN_ValidarSalvar_NivelAcessoInvalido)); ;
            }

            if (String.IsNullOrEmpty(usuario.Email))
            {
                erros.Add(new Erro(ErroEnum.Acesso_UsuarioRN_ValidarSalvar_EmailInvalido));
            }
            else
            {
                usuario.Email = usuario.Email.ToLower();
            }

            string emailToLower = usuario.Email;
            if (contexto.Usuarios.Count(usr => usr.Id != usuario.Id && usr.Email == emailToLower) > 0)
            {
                erros.Add(new Erro(ErroEnum.Acesso_UsuarioRN_ValidarSalvar_EmailJaExistente));
            }

            if (String.IsNullOrEmpty(usuario.Nome))
            {
                erros.Add(new Erro(ErroEnum.Acesso_UsuarioRN_ValidarSalvar_NomeInvalido));
            }

            if (String.IsNullOrEmpty(usuario.Senha))
            {
                erros.Add(new Erro(ErroEnum.Acesso_UsuarioRN_ValidarSalvar_SenhaInvalida));
            }

            return erros;
        }

        protected override void tratarObjetoSalvar(Usuario usuario, Usuario usuarioBD)
        {
            usuario.NivelAcesso = Convert.ToInt32(NivelAcessoEnum.Aluno);
            if (usuario.Ativo == false && usuarioBD.Ativo == true)
            {
                usuario.AulaId = null;
                usuario.Aula = null;
            }
        }

        #endregion Métodos
    }
}
