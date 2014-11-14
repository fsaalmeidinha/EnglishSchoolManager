using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EnglishSchoolManagerModel.Geral
{
    public class Resultado
    {
        #region Construtores

        public Resultado()
        {
            Erros = new List<Erro>();
        }

        public Resultado(List<Erro> erros)
        {
            Erros = erros;
            if (erros != null)
                ObteveSucesso = erros.Count == 0;
        }

        public Resultado(List<Erro> erros, int idEntidadeSalva)
        {
            Erros = erros;
            if (erros != null)
                ObteveSucesso = erros.Count == 0;

            this.IdEntidadeSalva = idEntidadeSalva;
        }

        #endregion Construtores

        public bool ObteveSucesso { get; set; }
        public List<Erro> Erros { get; set; }
        public int IdEntidadeSalva { get; set; }
    }
}
