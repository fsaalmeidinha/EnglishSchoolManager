using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EnglishSchoolManagerRules.Escola;
using ESMWeb.Endereco;
using EnglishSchoolManagerModel;

namespace ESMWeb.handlers
{
    /// <summary>
    /// Summary description for calendarioAulas
    /// </summary>
    public class calendarioAulas : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            CalendarioAulas calendarioAulas = new CalendarioAulasRN(Autenticacao.Autenticacao.RecuperarUsuarioAutenticado()).RecuperarCalendarioAulas();
            context.Response.Write(CommonsAPI.Serialize.JavaScriptSerializerHelper.Serialize(calendarioAulas));
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}