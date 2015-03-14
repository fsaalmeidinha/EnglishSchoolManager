using EnglishSchoolManagerModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Security;

namespace ESMWeb.Autenticacao
{
    internal class WindowsFormsAuthentication
    {
        internal static void AutenticarUsuario(Usuario usuarioAutenticado)
        {
            UsuarioAutenticacao usuarioAutenticacao = new UsuarioAutenticacao(usuarioAutenticado);

            FormsAuthenticationTicket ticketDeAutenticacao = new
                FormsAuthenticationTicket(1, //version
                usuarioAutenticado.Nome, // user name
                DateTime.Now,             //creation
                DateTime.Now.AddMinutes(10080), //Expiration (you can set it to 1 month
                true,  //Persistent
                new JavaScriptSerializer().Serialize(usuarioAutenticacao));

            String encryptedTicket = System.Web.Security.FormsAuthentication.Encrypt(ticketDeAutenticacao);
            HttpCookie authCookie = new HttpCookie(System.Web.Security.FormsAuthentication.FormsCookieName, encryptedTicket);
            authCookie.Expires = ticketDeAutenticacao.Expiration;
            HttpContext.Current.Response.Cookies.Add(authCookie);
        }

        internal static void AtualizarInformacoesUsuarioNoCookie(Usuario usuarioAutenticado)
        {
            UsuarioAutenticacao novoUsuarioAutenticacao = new UsuarioAutenticacao(usuarioAutenticado);

            HttpCookie cookie = HttpContext.Current.Request.Cookies[System.Web.Security.FormsAuthentication.FormsCookieName];
            System.Web.Security.FormsAuthenticationTicket ticketPersistido = System.Web.Security.FormsAuthentication.Decrypt(cookie.Value);

            System.Web.Security.FormsAuthenticationTicket novoTicket = new
                FormsAuthenticationTicket(ticketPersistido.Version,
                usuarioAutenticado.Nome,
                ticketPersistido.IssueDate,
                ticketPersistido.Expiration,
                ticketPersistido.IsPersistent,
                new JavaScriptSerializer().Serialize(novoUsuarioAutenticacao),
                ticketPersistido.CookiePath
                );
            String encryptedTicket = System.Web.Security.FormsAuthentication.Encrypt(novoTicket);
            cookie.Value = encryptedTicket;
            HttpContext.Current.Response.Cookies.Set(cookie);
        }

        internal static Usuario RecuperarUsuarioAutenticado()
        {
            HttpCookie cookie = HttpContext.Current.Request.Cookies[System.Web.Security.FormsAuthentication.FormsCookieName];
            if (cookie == null)
            {
                return null;
            }

            FormsAuthenticationTicket authTicket = FormsAuthentication.Decrypt(cookie.Value);
            if (authTicket == null)
                return null;

            UsuarioAutenticacao usuarioAutenticacao = (UsuarioAutenticacao)new JavaScriptSerializer().Deserialize(authTicket.UserData, typeof(UsuarioAutenticacao));
            if (usuarioAutenticacao == null)
                return null;

            return usuarioAutenticacao.RecuperarUsuario();
        }
    }
}