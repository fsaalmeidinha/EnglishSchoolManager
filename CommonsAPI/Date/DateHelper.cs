using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommonsAPI.Date
{
    public class DateHelper
    {
        public static bool PeriodosConcorrentes(DateTime dtInicial1, DateTime dtFinal1, DateTime dataInicial2, DateTime dataFinal2)
        {
            return DataDentroIntervalo(dtInicial1, dataInicial2, dataFinal2) || DataDentroIntervalo(dtFinal1, dataInicial2, dataFinal2);
        }

        public static bool DataDentroIntervalo(DateTime data, DateTime dtInicial, DateTime dataFinal)
        {
            return dtInicial <= data && dataFinal >= data;
        }
    }
}
