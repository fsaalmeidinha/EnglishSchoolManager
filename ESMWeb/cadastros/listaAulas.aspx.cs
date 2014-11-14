using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EnglishSchoolManagerRules.Escola;
using ESMWeb.Endereco;

namespace ESMWeb.cadastros
{
    public partial class listaAulas : AbstractPagina
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                AulaRN aulaRN = new AulaRN(UsuarioAtivo);
                rptUsuarios.DataSource = aulaRN.Listar();
                rptUsuarios.DataBind();
            }
        }
    }
}