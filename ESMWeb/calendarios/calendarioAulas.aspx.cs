using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ESMWeb.Endereco;
using EnglishSchoolManagerModel;
using EnglishSchoolManagerRules.Escola;

namespace ESMWeb.calendarios
{
    public partial class calendarioAulas : AbstractPagina
    {
        int totalMinutosInicial = 480;
        int totalMinutosFinal = 1260;
        int intervaloMinutos = 30;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                carregarHorariosAulas();
                carregarLegendas();
            }
        }

        private void carregarLegendas()
        {
            rptLegenda.DataSource = InfoAulaPorHorario.bgColorPorAula;
            rptLegenda.DataBind();
        }

        private void carregarHorariosAulas()
        {
            CalendarioAulas calendarioAulas = new CalendarioAulasRN(AcessoHelper.UsuarioAtivoHelper.RecuperarUsuarioAtivo()).RecuperarCalendarioAulas();
            List<InfoAulaPorHorario> infosAulaPorHorario = new List<InfoAulaPorHorario>();
            int totalMinutosInicioAula = totalMinutosInicial;
            while (totalMinutosInicioAula <= totalMinutosFinal)
            {
                preencherInfoHorarioParaOInicioDaAula(ref calendarioAulas, ref infosAulaPorHorario, totalMinutosInicioAula);
                totalMinutosInicioAula += intervaloMinutos;
            }

            rptHorariosAulas.DataSource = infosAulaPorHorario;
            rptHorariosAulas.DataBind();
        }

        private void preencherInfoHorarioParaOInicioDaAula(ref CalendarioAulas calendarioAulas, ref List<InfoAulaPorHorario> infosAulaPorHorario, int totalMinutosInicioAula)
        {
            //int totalMinutosFinalAula = totalMinutosInicioAula + intervaloMinutos;
            InfoAulaPorHorario infoAulaPorHorario = new InfoAulaPorHorario()
            {
                //Horario = String.Format("{0}:{1} {2}:{3}", Convert.ToInt32(totalMinutosInicioAula / 60).ToString().PadLeft(2, '0'), (totalMinutosInicioAula % 60).ToString().PadLeft(2, '0'),
                //                                             Convert.ToInt32(totalMinutosFinalAula / 60).ToString().PadLeft(2, '0'), (totalMinutosFinalAula % 60).ToString().PadLeft(2, '0'))
                Horario = String.Format("{0}:{1}", Convert.ToInt32(totalMinutosInicioAula / 60).ToString().PadLeft(2, '0'), (totalMinutosInicioAula % 60).ToString().PadLeft(2, '0'))
            };
            HorarioAula horarioAulaDeSegunda = calendarioAulas.HorariosAulasSegundaFeira.HorariosAulas
                .FirstOrDefault(horarioAula => getTotalMinutes(horarioAula.HorarioInicio) <= totalMinutosInicioAula && getTotalMinutes(horarioAula.HorarioFim) > totalMinutosInicioAula);
            HorarioAula horarioAulaDeTerca = calendarioAulas.HorariosAulasTercaFeira.HorariosAulas
                .FirstOrDefault(horarioAula => getTotalMinutes(horarioAula.HorarioInicio) <= totalMinutosInicioAula && getTotalMinutes(horarioAula.HorarioFim) > totalMinutosInicioAula);
            HorarioAula horarioAulaDeQuarta = calendarioAulas.HorariosAulasQuartaFeira.HorariosAulas
                .FirstOrDefault(horarioAula => getTotalMinutes(horarioAula.HorarioInicio) <= totalMinutosInicioAula && getTotalMinutes(horarioAula.HorarioFim) > totalMinutosInicioAula);
            HorarioAula horarioAulaDeQuinta = calendarioAulas.HorariosAulasQuintaFeira.HorariosAulas
                .FirstOrDefault(horarioAula => getTotalMinutes(horarioAula.HorarioInicio) <= totalMinutosInicioAula && getTotalMinutes(horarioAula.HorarioFim) > totalMinutosInicioAula);
            HorarioAula horarioAulaDeSexta = calendarioAulas.HorariosAulasSextaFeira.HorariosAulas
                .FirstOrDefault(horarioAula => getTotalMinutes(horarioAula.HorarioInicio) <= totalMinutosInicioAula && getTotalMinutes(horarioAula.HorarioFim) > totalMinutosInicioAula);
            HorarioAula horarioAulaDeSabado = calendarioAulas.HorariosAulasSabado.HorariosAulas
                .FirstOrDefault(horarioAula => getTotalMinutes(horarioAula.HorarioInicio) <= totalMinutosInicioAula && getTotalMinutes(horarioAula.HorarioFim) > totalMinutosInicioAula);
            HorarioAula horarioAulaDeDomingo = calendarioAulas.HorariosAulasDomingo.HorariosAulas
                .FirstOrDefault(horarioAula => getTotalMinutes(horarioAula.HorarioInicio) <= totalMinutosInicioAula && getTotalMinutes(horarioAula.HorarioFim) > totalMinutosInicioAula);

            if (horarioAulaDeSegunda != null)
            {
                infoAulaPorHorario.AulaSegunda = horarioAulaDeSegunda.Aula;
            }

            if (horarioAulaDeTerca != null)
            {
                infoAulaPorHorario.AulaTerca = horarioAulaDeTerca.Aula;
            }

            if (horarioAulaDeQuarta != null)
            {
                infoAulaPorHorario.AulaQuarta = horarioAulaDeQuarta.Aula;
            }

            if (horarioAulaDeQuinta != null)
            {
                infoAulaPorHorario.AulaQuinta = horarioAulaDeQuinta.Aula;
            }

            if (horarioAulaDeSexta != null)
            {
                infoAulaPorHorario.AulaSexta = horarioAulaDeSexta.Aula;
            }

            if (horarioAulaDeSabado != null)
            {
                infoAulaPorHorario.AulaSabado = horarioAulaDeSabado.Aula;
            }

            if (horarioAulaDeDomingo != null)
            {
                infoAulaPorHorario.AulaDomingo = horarioAulaDeDomingo.Aula;
            }

            infosAulaPorHorario.Add(infoAulaPorHorario);
        }

        private int getTotalMinutes(DateTime horario)
        {
            return horario.Hour * 60 + horario.Minute;
        }
    }

    internal class InfoAulaPorHorario
    {
        static InfoAulaPorHorario()
        {
            BGColors = new List<string>() {
            "#088A08",
            "#2EFE2E",
            "#868A08",
            "#F7FE2E",
            "#610B0B",
            "#FF0000",
            "#8904B1",
            "#B40404",
            "#BF00FF",
            "#D358F7",
            "#08088A",
            "#0101DF",
            "#D7DF01",
            "#2E2EFE",
            "#088A85",
            "#01DFD7",
            "#01DF01",
            "#2EFEF7"
            };
            bgColorPorAulaId = new Dictionary<int, string>();
        }

        internal static List<string> BGColors = new List<string>();
        internal static Dictionary<int, string> bgColorPorAulaId = new Dictionary<int, string>();
        internal static Dictionary<Aula, string> bgColorPorAula = new Dictionary<Aula, string>();

        public string Horario { get; set; }
        public Aula AulaSegunda { get; set; }
        public Aula AulaTerca { get; set; }
        public Aula AulaQuarta { get; set; }
        public Aula AulaQuinta { get; set; }
        public Aula AulaSexta { get; set; }
        public Aula AulaSabado { get; set; }
        public Aula AulaDomingo { get; set; }

        public string BGColorSegunda
        {
            get
            {
                return getBGColor(AulaSegunda);
            }
        }
        public string BGColorTerca
        {
            get
            {
                return getBGColor(AulaTerca);
            }
        }
        public string BGColorQuarta
        {
            get
            {
                return getBGColor(AulaQuarta);
            }
        }
        public string BGColorQuinta
        {
            get
            {
                return getBGColor(AulaQuinta);
            }
        }
        public string BGColorSexta
        {
            get
            {
                return getBGColor(AulaSexta);
            }
        }
        public string BGColorSabado
        {
            get
            {
                return getBGColor(AulaSabado);
            }
        }
        public string BGColorDomingo
        {
            get
            {
                return getBGColor(AulaDomingo);
            }
        }
        private string getBGColor(Aula aula)
        {
            if (aula == null)
            {
                return "";
            }

            if (!bgColorPorAulaId.ContainsKey(aula.Id))
            {
                if (BGColors.Count > 0)
                {
                    bgColorPorAulaId.Add(aula.Id, BGColors[0]);
                    bgColorPorAula.Add(aula, BGColors[0]);
                    BGColors.RemoveAt(0);
                }
                else
                {
                    bgColorPorAulaId.Add(aula.Id, "#CECECE");
                }
            }
            return bgColorPorAulaId[aula.Id];
        }
        //private string getBGColor(Aula aula)
        //{
        //    if (aula == null)
        //    {
        //        return "#04B404";
        //    }
        //    else
        //    {
        //        return "#DF0101";
        //    }
        //}
    }
}