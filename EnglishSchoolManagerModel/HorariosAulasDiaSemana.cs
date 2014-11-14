using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EnglishSchoolManagerModel
{
    [Serializable]
    public class HorariosAulasDiaSemana
    {
        public HorariosAulasDiaSemana()
        {
            HorariosAulas = new List<HorarioAula>();
        }

        public HorariosAulasDiaSemana(DayOfWeek diaSemana)
            : this()
        {
            DiaSemana = diaSemana;
        }

        public DayOfWeek DiaSemana { get; set; }

        public List<HorarioAula> HorariosAulas { get; set; }
    }
}
