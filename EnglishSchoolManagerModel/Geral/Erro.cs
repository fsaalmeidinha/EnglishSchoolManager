using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EnglishSchoolManagerModel.Enumerador;

namespace EnglishSchoolManagerModel.Geral
{
    public class Erro
    {
        #region Construtores

        public Erro()
        {
        }

        public Erro(string mensagem)
            : this(null, mensagem)
        {

        }

        public Erro(ErroEnum erroEnum)
        {
            this.Codigo = erroEnum.ToString();
            this.Mensagem = erroEnum.ObterDescricao();
        }

        public Erro(string codigo, string mensagem)
        {
            this.Codigo = codigo;
            this.Mensagem = mensagem;
        }

        #endregion Construtores

        public string Codigo { get; set; }
        public string Mensagem { get; set; }
    }
}
