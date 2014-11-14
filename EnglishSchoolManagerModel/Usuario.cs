using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EnglishSchoolManagerModel
{
    public partial class Usuario
    {
        public string DescricaoStatusAtivo
        {
            get
            {
                return Ativo == true ? "Ativo" : "Inativo";
            }
            set { }
        }
    }
}
