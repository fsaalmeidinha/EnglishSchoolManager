using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EnglishSchoolManagerModel;
using EnglishSchoolManagerRules.Acesso;
using ESMWeb.AcessoHelper;
using EnglishSchoolManagerModel.Geral;
using ESMWeb.Endereco;

namespace ESMWeb.cadastros
{
    public partial class cadastroAluno : AbstractPagina
    {
        int recuperarIdUsuario()
        {
            string idAlunoStr = Request.QueryString["Id"];
            int idAluno = 0;

            if (!String.IsNullOrEmpty(idAlunoStr))
            {
                Int32.TryParse(idAlunoStr, out idAluno);
            }

            return idAluno;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                carregarAluno();
            }

            //EnglishSchoolManagerRules.Notificacao.EnvioSMS.EnviarSMS("5511982933310", "Te amo coisinha gorda!! Melhor namorada do mundo ;D");
        }

        private void carregarAluno()
        {
            int idAluno = recuperarIdUsuario();
            if (idAluno > 0)
            {
                UsuarioRN usuarioRN = new UsuarioRN(UsuarioAtivo);
                Usuario usuario = usuarioRN.PesquisarPorId(idAluno);
                if (usuario != null)
                {
                    txtNome.Text = usuario.Nome;
                    txtEmail.Text = usuario.Email;
                    txtSenha.Text = usuario.Senha;
                    txtTelefone.Text = usuario.Telefone;
                    cbAtivo.Checked = usuario.Ativo;
                }
            }
        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                Usuario usuarioSalvar = null;
                if (recuperarIdUsuario() > 0)
                {
                    usuarioSalvar = new UsuarioRN(UsuarioAtivo).PesquisarPorId(recuperarIdUsuario());
                }
                else
                {
                    usuarioSalvar = new Usuario();
                    usuarioSalvar.Email = txtEmail.Text;
                }

                usuarioSalvar.Telefone = txtTelefone.Text;
                usuarioSalvar.Ativo = cbAtivo.Checked;

                if (!String.IsNullOrEmpty(txtSenha.Text))
                {
                    usuarioSalvar.Senha = txtSenha.Text;
                }

                usuarioSalvar.Nome = txtNome.Text;

                UsuarioRN usuarioRN = new UsuarioRN(UsuarioAtivo);
                Resultado resultado = usuarioRN.Salvar(usuarioSalvar);

                setErrors(resultado.Erros);
                if (resultado.ObteveSucesso)
                {
                    int idAluno = recuperarIdUsuario();
                    string urlRedirect = String.Format("{0}?Id={1}", recuperarEnderecoURLSemQueryString(), resultado.IdEntidadeSalva);
                    Response.Redirect(urlRedirect);
                }
            }
            catch (Exception ex)
            {
                setErrors(new List<Erro>() { new Erro("Desculpe, ocorreu um erro desconhecido. Um relato automático foi enviado para a nossa equipe técnica analisar o problema!") });
            }
        }

        private void setErrors(List<Erro> erros)
        {
            if (erros == null || erros.Count == 0)
            {
                rptErros.Visible = false;
            }
            else
            {
                rptErros.DataSource = erros;
                rptErros.DataBind();
                rptErros.Visible = true;
                rptErros.Focus();
            }
        }
    }
}