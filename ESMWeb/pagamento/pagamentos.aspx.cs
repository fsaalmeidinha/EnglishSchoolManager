using EnglishSchoolManagerModel;
using EnglishSchoolManagerModel.Geral;
using EnglishSchoolManagerRules.Acesso;
using EnglishSchoolManagerRules.Pagamento;
using ESMWeb.Endereco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ESMWeb.pagamento
{
    public partial class pagamentos : AbstractPagina
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                DateTime dtInicial = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
                DateTime dtFinal = dtInicial.AddMonths(1).AddDays(-1);
                txtDataInicial.Text = dtInicial.ToString("dd/MM/yyyy");
                txtDataFinal.Text = dtFinal.ToString("dd/MM/yyyy");

                filtrarPagamentos();
                carregarAlunosCriarPagamento();
            }
        }

        private void carregarAlunosCriarPagamento()
        {
            UsuarioRN usuarioRN = new UsuarioRN(UsuarioAtivo);
            ddlAluno.DataSource = usuarioRN.ListarAlunosAtivosComTurma();
            ddlAluno.DataBind();
        }

        protected void btnFiltrar_Click(object sender, EventArgs e)
        {
            filtrarPagamentos();
        }

        private void filtrarPagamentos()
        {
            FiltroPagamento filtroPagamento = new FiltroPagamento()
            {
                DataInicialVencimento = Convert.ToDateTime(txtDataInicial.Text, cultura),
                DataFinalVencimento = Convert.ToDateTime(txtDataFinal.Text, cultura)
            };

            switch (ddlBoletoPago.SelectedValue)
            {
                case "S":
                    filtroPagamento.StatusPagamentoEfetuado = true;
                    break;
                case "N":
                    filtroPagamento.StatusPagamentoEfetuado = false;
                    break;
            }

            PagamentoRN pagamentoRN = new PagamentoRN(UsuarioAtivo);
            List<Pagamento> pagamentos = pagamentoRN.Listar(filtroPagamento);
            rptPagamentos.DataSource = pagamentos;
            rptPagamentos.DataBind();

            tratarTotalPagamentoEPendencias(pagamentos);
        }

        private void tratarTotalPagamentoEPendencias(List<Pagamento> pagamentos)
        {
            lblTotalPago.Visible = false;
            lblTotalPendencias.Visible = false;
            switch (ddlBoletoPago.SelectedValue)
            {
                case "S":
                    lblTotalPago.Visible = true;
                    lblTotalPago.Text = String.Format("Total pago no período: R$ {0}", pagamentos.Sum(pag => pag.Valor));
                    break;
                case "N":
                    lblTotalPendencias.Visible = true;
                    lblTotalPendencias.Text = String.Format("Total de pendências no período: R$ {0}", pagamentos.Sum(pag => pag.Valor));
                    break;
                default:
                    lblTotalPago.Text = String.Format("Total pago no período: R$ {0}", pagamentos.Where(pag => pag.PagamentoEfetuado).Sum(pag => pag.Valor));
                    lblTotalPendencias.Text = String.Format("Total de pendências no período: R$ {0}", pagamentos.Where(pag => !pag.PagamentoEfetuado).Sum(pag => pag.Valor));
                    lblTotalPago.Visible = true;
                    lblTotalPendencias.Visible = true;
                    break;
            }
        }

        protected void btnConfirmarPagamento_Click(object sender, EventArgs e)
        {
            int pagamentoId = Convert.ToInt32((sender as Button).CommandArgument);
            PagamentoRN pagamentoRN = new PagamentoRN(UsuarioAtivo);
            bool resultado = pagamentoRN.ConfirmarPagamento(pagamentoId);

            string msg = resultado ? "Pagamento confirmado com sucesso!" : "Erro ao confirmar o pagamento. Por favor, tente novamente!";
            Page.ClientScript.RegisterClientScriptBlock(typeof(Page), "feedback", " $(document).ready(function() { alert('" + msg + "');});", true);

            if (resultado)
                filtrarPagamentos();
        }

        protected void btnExcluirPagamento_Click(object sender, EventArgs e)
        {
            int pagamentoId = Convert.ToInt32((sender as Button).CommandArgument);
            PagamentoRN pagamentoRN = new PagamentoRN(UsuarioAtivo);
            bool resultado = pagamentoRN.ExcluirPagamento(pagamentoId);

            string msg = resultado ? "Pagamento excluído com sucesso!" : "Erro ao excluir o pagamento. Por favor, tente novamente!";
            Page.ClientScript.RegisterClientScriptBlock(typeof(Page), "feedback", " $(document).ready(function() { alert('" + msg + "');});", true);

            if (resultado)
                filtrarPagamentos();
        }

        protected void btnCriarPagamento_Click(object sender, EventArgs e)
        {
            try
            {
                Pagamento pagamento = new Pagamento()
                {
                    AlunoId = Convert.ToInt32(ddlAluno.SelectedValue),
                    DataPagamento = Convert.ToDateTime(txtDataVencimento.Text, cultura)
                };

                PagamentoRN pagamentoRN = new PagamentoRN(UsuarioAtivo);
                Resultado resultado = pagamentoRN.Salvar(pagamento);

                string msg = resultado.ObteveSucesso ? "Pagamento criado com sucesso!" : "Erro ao criar o pagamento. Por favor, tente novamente!";
                Page.ClientScript.RegisterClientScriptBlock(typeof(Page), "feedback", " $(document).ready(function() { alert('" + msg + "');});", true);

                if (resultado.ObteveSucesso)
                {
                    ddlAluno.ClearSelection();
                    txtDataVencimento.Text = "";
                    filtrarPagamentos();
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterClientScriptBlock(typeof(Page), "erro", " $(document).ready(function() { alert('Erro ao criar o pagamento. Por favor, tente novamente!');});", true);
            }
        }
    }
}