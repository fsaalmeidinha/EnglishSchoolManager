using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EnglishSchoolManagerModel;
using EnglishSchoolManagerModel.Enumerador;

namespace ESMWeb.Endereco
{
    public abstract class AbstractPagina : System.Web.UI.Page
    {
        protected Usuario UsuarioAtivo
        {
            get
            {
                return Autenticacao.Autenticacao.RecuperarUsuarioAutenticado();
            }
            set { }
        }

        protected string recuperarFullHostUrl()
        {
            return Request.UrlReferrer.AbsoluteUri.Replace(Request.UrlReferrer.AbsolutePath + Request.UrlReferrer.Query, "");
        }

        protected string recuperarEnderecoURLSemQueryString()
        {
            string URLSistema = Request.UrlReferrer.AbsoluteUri;
            if (!String.IsNullOrEmpty(Request.UrlReferrer.Query))
            {
                URLSistema = URLSistema.Replace(Request.UrlReferrer.Query, "");
            }
            return URLSistema;
        }

        public void RedirecionarParaPaginaPrincipal()
        {
            string url = "~/Index/ManagerIndex.aspx";

            HttpContext.Current.Response.Redirect(url);
        }
    }
}