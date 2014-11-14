using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ESMWeb.Endereco;
using EnglishSchoolManagerModel;
using EnglishSchoolManagerRules.Escola;

namespace ESMWeb.cadastros
{
    public partial class listaHorariosAulas : AbstractPagina
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                CalendarioAulas calendarioAulas = new CalendarioAulasRN(AcessoHelper.UsuarioAtivoHelper.RecuperarUsuarioAtivo()).RecuperarCalendarioAulas();
                List<HorarioAula> horariosAulas = new List<HorarioAula>();
                horariosAulas.AddRange(calendarioAulas.HorariosAulasSegundaFeira.HorariosAulas.OrderBy(horario => horario.HorarioInicio));
                horariosAulas.AddRange(calendarioAulas.HorariosAulasTercaFeira.HorariosAulas.OrderBy(horario => horario.HorarioInicio));
                horariosAulas.AddRange(calendarioAulas.HorariosAulasQuartaFeira.HorariosAulas.OrderBy(horario => horario.HorarioInicio));
                horariosAulas.AddRange(calendarioAulas.HorariosAulasQuintaFeira.HorariosAulas.OrderBy(horario => horario.HorarioInicio));
                horariosAulas.AddRange(calendarioAulas.HorariosAulasSextaFeira.HorariosAulas.OrderBy(horario => horario.HorarioInicio));
                horariosAulas.AddRange(calendarioAulas.HorariosAulasSabado.HorariosAulas.OrderBy(horario => horario.HorarioInicio));
                horariosAulas.AddRange(calendarioAulas.HorariosAulasDomingo.HorariosAulas.OrderBy(horario => horario.HorarioInicio));

                rptHorariosAulas.DataSource = horariosAulas;
                rptHorariosAulas.DataBind();
            }
        }
    }
}