using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EnglishSchoolManagerRules.Acesso;
using ESMWeb.Endereco;

namespace ESMWeb.cadastros
{
    public partial class listaAlunos : AbstractPagina
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                UsuarioRN usuarioRN = new UsuarioRN(UsuarioAtivo);
                rptUsuarios.DataSource = usuarioRN.Listar();
                rptUsuarios.DataBind();
            }
        }
    }
}