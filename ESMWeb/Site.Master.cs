﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ESMWeb
{
    public partial class SiteMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            spanNomeEscola.InnerText = Autenticacao.Autenticacao.RecuperarUsuarioAutenticado().Escola.Nome;
        }
    }
}
