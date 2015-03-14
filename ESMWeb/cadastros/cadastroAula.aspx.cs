using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EnglishSchoolManagerModel.Geral;
using EnglishSchoolManagerRules.Escola;
using ESMWeb.Endereco;
using EnglishSchoolManagerModel;
using EnglishSchoolManagerRules.Acesso;
using CommonsAPI.Serialize;

namespace ESMWeb.cadastros
{
    public partial class cadastroAula : AbstractPagina
    {
        int recuperarIdAula()
        {
            string idAulaStr = Request.QueryString["Id"];
            int idAula = 0;

            if (!String.IsNullOrEmpty(idAulaStr))
            {
                Int32.TryParse(idAulaStr, out idAula);
            }

            return idAula;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                carregarAlunos();
                carregarAula();
            }
        }

        private void carregarAlunos()
        {
            UsuarioRN usuarioRN = new UsuarioRN(UsuarioAtivo);
            List<Usuario> alunos = usuarioRN.ListarAlunosAtivosESemAula(recuperarIdAula());
            //ddlAluno.DataSource = alunos;
            //ddlAluno.DataBind();

            lbAlunos.DataSource = alunos;
            lbAlunos.DataBind();
        }

        private void carregarAula()
        {
            int idAula = recuperarIdAula();
            if (idAula > 0)
            {
                AulaRN aulaRN = new AulaRN(UsuarioAtivo);
                Aula aula = aulaRN.PesquisarPorId(idAula);
                if (aula != null)
                {
                    txtValor.Text = aula.ValorMensalidade.ToString("N2");
                    txtDescricao.Text = aula.Descricao;
                    cbParticular.Checked = aula.Particular;
                    hdnHorariosAula.Value = recuperarHorariosJSON(aula);
                    List<int> idsAlunos = aula.Alunos.Select(aluno => aluno.Id).ToList();
                    lbAlunos.Items.OfType<ListItem>().ToList().ForEach(itemAluno => { if (idsAlunos.Contains(Convert.ToInt32(itemAluno.Value))) itemAluno.Selected = true; });
                }
            }
        }

        private string recuperarHorariosJSON(Aula aula)
        {
            List<HorarioAulaCadastroAula> horariosAulaCadastro = aula.GetHorariosAula()
                .Select(horarioAula => new HorarioAulaCadastroAula(horarioAula.DiaSemanaId, horarioAula.HorarioInicio, horarioAula.HorarioFim)).ToList();

            return JavaScriptSerializerHelper.Serialize(horariosAulaCadastro);
        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                Aula aulaSalvar = null;
                if (recuperarIdAula() > 0)
                {
                    aulaSalvar = new AulaRN(UsuarioAtivo).PesquisarPorId(recuperarIdAula());
                }
                else
                {
                    aulaSalvar = new Aula();
                }

                if (!String.IsNullOrEmpty(txtValor.Text) && txtValor.Text.Split(' ').Length == 2)
                {
                    aulaSalvar.ValorMensalidade = Convert.ToDecimal(txtValor.Text.Split(' ')[1], new System.Globalization.CultureInfo("pt-BR"));
                }
                aulaSalvar.Descricao = txtDescricao.Text;
                aulaSalvar.Particular = cbParticular.Checked;
                preencherHorariosAula(aulaSalvar);
                aulaSalvar.IdsAlunos = lbAlunos.Items.OfType<ListItem>().Where(item => item.Selected)
                    .Select(item => Convert.ToInt32(item.Value)).ToList();

                AulaRN aulaRN = new AulaRN(UsuarioAtivo);
                Resultado resultado = aulaRN.Salvar(aulaSalvar);

                setErrors(resultado.Erros);
                if (resultado.ObteveSucesso)
                {
                    int idAula = recuperarIdAula();
                    string urlRedirect = String.Format("{0}?Id={1}", recuperarEnderecoURLSemQueryString(), resultado.IdEntidadeSalva);
                    Response.Redirect(urlRedirect);
                }
            }
            catch (Exception ex)
            {
                setErrors(new List<Erro>() { new Erro("Desculpe, ocorreu um erro desconhecido. Um relato automático foi enviado para a nossa equipe técnica analisar o problema!") });
            }
        }

        private void preencherHorariosAula(Aula aulaSalvar)
        {
            List<HorarioAulaCadastroAula> horariosAulaCadastro = JavaScriptSerializerHelper.Deserialize<List<HorarioAulaCadastroAula>>(hdnHorariosAula.Value);
            List<HorarioAula> horariosAula = horariosAulaCadastro.Select(horarioCadastro =>
                new HorarioAula()
                {
                    DiaSemanaId = horarioCadastro.DiaSemanaId,
                    HorarioInicio = new DateTime(2000, 01, 01, Convert.ToInt32(horarioCadastro.HoraInicial), Convert.ToInt32(horarioCadastro.MinutoInicial), 0),
                    HorarioFim = new DateTime(2000, 01, 01, Convert.ToInt32(horarioCadastro.HoraFinal), Convert.ToInt32(horarioCadastro.MinutoFinal), 0)
                }).ToList();
            aulaSalvar.SetHorariosAula(horariosAula);
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

        protected class HorarioAulaCadastroAula
        {
            public HorarioAulaCadastroAula()
            {

            }

            public HorarioAulaCadastroAula(int diaSemanaId, DateTime horarioInicio, DateTime horarioFim)
            {
                this.DiaSemanaId = diaSemanaId;
                this.HoraInicial = horarioInicio.Hour.ToString().PadLeft(2, '0');
                this.MinutoInicial = horarioInicio.Minute.ToString().PadLeft(2, '0');
                this.HoraFinal = horarioFim.Hour.ToString().PadLeft(2, '0');
                this.MinutoFinal = horarioFim.Minute.ToString().PadLeft(2, '0');
            }

            public int DiaSemanaId { get; set; }
            public string HoraInicial { get; set; }
            public string MinutoInicial { get; set; }
            public string HoraFinal { get; set; }
            public string MinutoFinal { get; set; }
        }
    }
}