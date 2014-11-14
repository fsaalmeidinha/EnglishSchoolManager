using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace EnglishSchoolManagerModel.Enumerador
{
    public static class ExtencaoEnum
    {
        public static string ObterDescricao(this object enumerador)
        {
            DescriptionAttribute atributoDescricao = enumerador.GetType().GetField(enumerador.ToString()).GetCustomAttributes(typeof(DescriptionAttribute), true).FirstOrDefault() as DescriptionAttribute;
            if (atributoDescricao == null)
                return enumerador.ToString();
            else
                return atributoDescricao.Description;
        }
    }
}
