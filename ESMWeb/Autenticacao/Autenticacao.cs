using EnglishSchoolManagerModel;
using EnglishSchoolManagerRules.Acesso;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ESMWeb.Autenticacao
{
    public class Autenticacao
    {
        internal static Usuario AutenticarUsuario(string email, string senha)
        {
            Usuario usuarioAutenticado = UsuarioRN.Autenticar(email, senha);

            return usuarioAutenticado;
        }

        internal static Usuario RecuperarUsuarioAutenticado()
        {
            return WindowsFormsAuthentication.RecuperarUsuarioAutenticado();
        }
    }
}