using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EnglishSchoolManagerModel
{
    [Serializable]
    public class CalendarioAulas
    {
        public CalendarioAulas()
        {
            HorariosAulasSegundaFeira = new HorariosAulasDiaSemana(DayOfWeek.Monday);
            HorariosAulasTercaFeira = new HorariosAulasDiaSemana(DayOfWeek.Tuesday);
            HorariosAulasQuartaFeira = new HorariosAulasDiaSemana(DayOfWeek.Wednesday);
            HorariosAulasQuintaFeira = new HorariosAulasDiaSemana(DayOfWeek.Thursday);
            HorariosAulasSextaFeira = new HorariosAulasDiaSemana(DayOfWeek.Friday);
            HorariosAulasSabado = new HorariosAulasDiaSemana(DayOfWeek.Saturday);
            HorariosAulasDomingo = new HorariosAulasDiaSemana(DayOfWeek.Sunday);
        }

        public HorariosAulasDiaSemana HorariosAulasSegundaFeira { get; set; }
        public HorariosAulasDiaSemana HorariosAulasTercaFeira { get; set; }
        public HorariosAulasDiaSemana HorariosAulasQuartaFeira { get; set; }
        public HorariosAulasDiaSemana HorariosAulasQuintaFeira { get; set; }
        public HorariosAulasDiaSemana HorariosAulasSextaFeira { get; set; }
        public HorariosAulasDiaSemana HorariosAulasSabado { get; set; }
        public HorariosAulasDiaSemana HorariosAulasDomingo { get; set; }
    }
}
