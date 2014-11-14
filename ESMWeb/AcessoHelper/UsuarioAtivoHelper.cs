using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EnglishSchoolManagerModel;

namespace ESMWeb.AcessoHelper
{
    public class UsuarioAtivoHelper
    {
        public static Usuario RecuperarUsuarioAtivo()
        {
            return new Usuario()
            {
                Id = -99,
                NivelAcesso = 0
            };
        }
    }
}