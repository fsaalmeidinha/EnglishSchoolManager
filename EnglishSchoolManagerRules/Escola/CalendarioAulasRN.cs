using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EnglishSchoolManagerModel;

namespace EnglishSchoolManagerRules.Escola
{
    public class CalendarioAulasRN
    {
        #region Propriedades

        protected ESMEntities contexto;
        protected Usuario usuarioAtivo;
        private int minutosQuebraAula = 30;

        #endregion Propriedades

        #region Construtores

        public CalendarioAulasRN(Usuario usuarioAtivo)
            : this(usuarioAtivo, new ESMEntities())
        {
        }

        public CalendarioAulasRN(Usuario usuarioAtivo, ESMEntities contexto)
        {
            this.usuarioAtivo = usuarioAtivo;
            this.contexto = contexto;
        }

        #endregion Construtores

        public CalendarioAulas RecuperarCalendarioAulas()
        {
            CalendarioAulas calendarioAulas = new CalendarioAulas();

            List<Aula> aulas = contexto.Aulas.ToList();
            foreach (Aula aula in aulas)
            {
                foreach (HorarioAula horarioAula in aula.GetHorariosAula())
                {
                    adicionarHorarioAulaAoCalendario(ref calendarioAulas, aula, horarioAula);
                }
            }

            ordenarItensCalendario(ref calendarioAulas);

            return calendarioAulas;
        }

        private void adicionarHorarioAulaAoCalendario(ref CalendarioAulas calendarioAulas, Aula aula, HorarioAula horarioAula)
        {
            horarioAula.Aula = aula;

            switch (horarioAula.DiaSemana)
            {
                case DayOfWeek.Friday:
                    calendarioAulas.HorariosAulasSextaFeira.HorariosAulas.Add(horarioAula);
                    break;
                case DayOfWeek.Monday:
                    calendarioAulas.HorariosAulasSegundaFeira.HorariosAulas.Add(horarioAula);
                    break;
                case DayOfWeek.Saturday:
                    calendarioAulas.HorariosAulasSabado.HorariosAulas.Add(horarioAula);
                    break;
                case DayOfWeek.Sunday:
                    calendarioAulas.HorariosAulasDomingo.HorariosAulas.Add(horarioAula);
                    break;
                case DayOfWeek.Thursday:
                    calendarioAulas.HorariosAulasQuintaFeira.HorariosAulas.Add(horarioAula);
                    break;
                case DayOfWeek.Tuesday:
                    calendarioAulas.HorariosAulasTercaFeira.HorariosAulas.Add(horarioAula);
                    break;
                case DayOfWeek.Wednesday:
                    calendarioAulas.HorariosAulasQuartaFeira.HorariosAulas.Add(horarioAula);
                    break;
            }
        }

        private void ordenarItensCalendario(ref CalendarioAulas calendarioAulas)
        {
            calendarioAulas.HorariosAulasSegundaFeira.HorariosAulas = calendarioAulas.HorariosAulasSegundaFeira.HorariosAulas.OrderBy(horario => horario.HorarioInicio).ToList();
            calendarioAulas.HorariosAulasTercaFeira.HorariosAulas = calendarioAulas.HorariosAulasTercaFeira.HorariosAulas.OrderBy(horario => horario.HorarioInicio).ToList();
            calendarioAulas.HorariosAulasQuartaFeira.HorariosAulas = calendarioAulas.HorariosAulasQuartaFeira.HorariosAulas.OrderBy(horario => horario.HorarioInicio).ToList();
            calendarioAulas.HorariosAulasQuintaFeira.HorariosAulas = calendarioAulas.HorariosAulasQuintaFeira.HorariosAulas.OrderBy(horario => horario.HorarioInicio).ToList();
            calendarioAulas.HorariosAulasSextaFeira.HorariosAulas = calendarioAulas.HorariosAulasSextaFeira.HorariosAulas.OrderBy(horario => horario.HorarioInicio).ToList();
            calendarioAulas.HorariosAulasSabado.HorariosAulas = calendarioAulas.HorariosAulasSabado.HorariosAulas.OrderBy(horario => horario.HorarioInicio).ToList();
            calendarioAulas.HorariosAulasDomingo.HorariosAulas = calendarioAulas.HorariosAulasDomingo.HorariosAulas.OrderBy(horario => horario.HorarioInicio).ToList();
        }
    }
}
