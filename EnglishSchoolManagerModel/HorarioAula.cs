using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EnglishSchoolManagerModel
{
    public class HorarioAula
    {
        private string codigo = Guid.NewGuid().ToString();
        public string Codigo { get { return codigo; } set { codigo = value; } }

        DateTime horarioInicio = DateTime.MinValue;
        public DateTime HorarioInicio
        {
            get { return horarioInicio; }
            set
            {
                horarioInicio = value;
                if (horarioInicio.Year < 2000)
                {
                    horarioInicio = horarioInicio.AddYears(2000 - horarioInicio.Year);
                }
            }
        }

        DateTime horarioFim = DateTime.MinValue;
        public DateTime HorarioFim
        {
            get { return horarioFim; }
            set
            {
                horarioFim = value;
                if (horarioFim.Year < 2000)
                {
                    horarioFim = horarioFim.AddYears(2000 - horarioFim.Year);
                }
            }
        }
        public DayOfWeek DiaSemana { get; set; }
        public int DiaSemanaId
        {
            get
            {
                return Convert.ToInt32(DiaSemana);
            }
            set
            {
                DiaSemana = ((DayOfWeek)value);
            }
        }

        public string DescricaoDiaSemana
        {
            get
            {
                switch (DiaSemana)
                {
                    case DayOfWeek.Friday:
                        return "Sexta";
                        break;
                    case DayOfWeek.Monday:
                        return "Segunda";
                        break;
                    case DayOfWeek.Saturday:
                        return "Sábado";
                        break;
                    case DayOfWeek.Sunday:
                        return "Domingo";
                        break;
                    case DayOfWeek.Thursday:
                        return "Quinta";
                        break;
                    case DayOfWeek.Tuesday:
                        return "Terça";
                        break;
                    case DayOfWeek.Wednesday:
                        return "Quarta";
                        break;
                    default:
                        return "";
                        break;
                }
            }
            set { }
        }

        public string DescricaoHorarioInicio
        {
            get
            {
                return HorarioInicio.ToString("HH:mm");
            }
            set
            {
            }
        }

        public string DescricaoHorarioFim
        {
            get
            {
                return HorarioFim.ToString("HH:mm");
            }
            set { }
        }

        public string DescricaoHorarioAula
        {
            get
            {
                return String.Format("{0} ({1} - {2})", DiaSemana.ToString(), HorarioInicio.ToString("HH:mm"), HorarioFim.ToString("HH:mm"));
            }
            set { }
        }

        public Aula Aula { get; set; }
    }
}
