using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EnglishSchoolManagerModel;

namespace ESMWeb.Endereco
{
    public abstract class AbstractPagina : System.Web.UI.Page
    {
        protected Usuario UsuarioAtivo
        {
            get
            {
                return AcessoHelper.UsuarioAtivoHelper.RecuperarUsuarioAtivo();
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
    }
}