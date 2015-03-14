using EnglishSchoolManagerModel;
using ESMWeb.Autenticacao;
using ESMWeb.Endereco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ESMWeb.Account
{
    public partial class Login : AbstractPagina
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Coloca o FormsAuthenticate como não autenticado / Efetua o logout, desconectando o usuário.
            FormsAuthentication.SignOut();

            if (!IsPostBack)
            {
                if (Request.Cookies["userid"] != null)
                    txtEmail.Text = Request.Cookies["userid"].Value;
                if (Request.Cookies["pwd"] != null)
                    txtSenha.Attributes.Add("value", Request.Cookies["pwd"].Value);
                if (Request.Cookies["userid"] != null && Request.Cookies["pwd"] != null)
                    cbLembrarMe.Checked = true;
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string usuario = txtEmail.Text;
            string senha = txtSenha.Text;
            bool autenticado = autenticar(usuario, senha);
            tratarLembrarPassword(autenticado, usuario, senha);

            if (autenticado)
            {
                RedirecionarParaPaginaPrincipal();
            }
            else
            {
                paragraphWrongAccount.Visible = true;
            }
        }

        private void tratarLembrarPassword(bool autenticado, string usuario, string senha)
        {
            if (autenticado)
            {
                if (cbLembrarMe.Checked == true)
                {
                    Response.Cookies["userid"].Value = usuario;
                    Response.Cookies["pwd"].Value = senha;
                    Response.Cookies["userid"].Expires = DateTime.Now.AddDays(15);
                    Response.Cookies["pwd"].Expires = DateTime.Now.AddDays(15);
                }
                else
                {
                    Response.Cookies["userid"].Expires = DateTime.Now.AddDays(-1);
                    Response.Cookies["pwd"].Expires = DateTime.Now.AddDays(-1);
                }
            }
        }

        private bool autenticar(string usuario, string senha)
        {
            if (!Page.IsValid)
                return false;

            Usuario usuarioAutenticado = Autenticacao.Autenticacao.AutenticarUsuario(usuario, senha);

            if (usuarioAutenticado != null)
            {
                WindowsFormsAuthentication.AutenticarUsuario(usuarioAutenticado);
            }

            return usuarioAutenticado != null;
        }
    }
}
