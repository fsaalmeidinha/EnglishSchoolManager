using EnglishSchoolManagerModel;
using EnglishSchoolManagerModel.Enumerador;
using EnglishSchoolManagerModel.Geral;
using EnglishSchoolManagerRules.Geral;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnglishSchoolManagerRules.Pagamento
{
    public class PagamentoRN : RNBase<EnglishSchoolManagerModel.Pagamento>
    {
        #region Construtores

        public PagamentoRN(Usuario usuarioAtivo)
            : base(usuarioAtivo)
        {

        }

        public PagamentoRN(Usuario usuarioAtivo, ESMEntities contexto)
            : base(usuarioAtivo, contexto)
        {

        }

        #endregion Construtores

        public List<EnglishSchoolManagerModel.Pagamento> Listar(FiltroPagamento filtroPagamento)
        {
            List<EnglishSchoolManagerModel.Pagamento> pagamentos = new List<EnglishSchoolManagerModel.Pagamento>();
            if (usuarioAtivo.NivelAcesso == Convert.ToInt32(NivelAcessoEnum.Administrador))
            {
                using (ESMEntities contexto = new ESMEntities())
                {
                    var queryPagamentos = contexto.Pagamentos.Include("Aluno")
                        .Where(pagamento => pagamento.EscolaId == usuarioAtivo.EscolaId
                            && pagamento.DataPagamento >= filtroPagamento.DataInicialVencimento
                            && pagamento.DataPagamento <= filtroPagamento.DataFinalVencimento);

                    if (filtroPagamento.StatusPagamentoEfetuado != null)
                    {
                        bool statusPagamento = filtroPagamento.StatusPagamentoEfetuado.GetValueOrDefault();
                        queryPagamentos = queryPagamentos.Where(pagamento => pagamento.PagamentoEfetuado == statusPagamento);
                    }

                    pagamentos = queryPagamentos.OrderBy(pagamento => pagamento.DataPagamento).ToList();
                }
            }
            return pagamentos;
        }

        public bool ConfirmarPagamento(int pagamentoId)
        {
            bool resultado = false;
            try
            {
                if (usuarioAtivo.NivelAcesso == Convert.ToInt32(NivelAcessoEnum.Administrador))
                {
                    using (ESMEntities contexto = new ESMEntities())
                    {
                        EnglishSchoolManagerModel.Pagamento pagamento = contexto.Pagamentos
                            .FirstOrDefault(pgto => pgto.Id == pagamentoId && pgto.EscolaId == usuarioAtivo.EscolaId);

                        if (pagamento != null && pagamento.PagamentoEfetuado == false)
                        {
                            pagamento.PagamentoEfetuado = true;
                            pagamento.UsuarioAlteracaoId = usuarioAtivo.Id;
                            pagamento.DataAlteracao = DateTime.UtcNow;
                            contexto.SaveChanges();
                            resultado = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                LogRN.GravarLog(ex);
            }

            return resultado;
        }

        public bool ExcluirPagamento(int pagamentoId)
        {
            bool resultado = false;
            try
            {
                if (usuarioAtivo.NivelAcesso == Convert.ToInt32(NivelAcessoEnum.Administrador))
                {
                    using (ESMEntities contexto = new ESMEntities())
                    {
                        EnglishSchoolManagerModel.Pagamento pagamento = contexto.Pagamentos
                            .FirstOrDefault(pgto => pgto.Id == pagamentoId && pgto.EscolaId == usuarioAtivo.EscolaId);

                        if (pagamento != null)
                        {
                            contexto.Pagamentos.DeleteObject(pagamento);
                            contexto.SaveChanges();
                            resultado = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                LogRN.GravarLog(ex);
            }

            return resultado;
        }

        protected override List<Erro> validarSalvar(EnglishSchoolManagerModel.Pagamento pagamento)
        {
            List<Erro> erros = new List<Erro>();

            if (pagamento == null)
            {
                erros.Add(new Erro(ErroEnum.Pagamento_PagamentoRN_ValidarSalvar_PagamentoNULL));
                return erros;
            }

            if (pagamento.Id > 0)
            {
                erros.Add(new Erro(ErroEnum.Pagamento_PagamentoRN_ValidarSalvar_NaoPermitidoAlterarPagamento));
            }

            if (usuarioAtivo.NivelAcesso != Convert.ToInt32(NivelAcessoEnum.Administrador))
            {
                erros.Add(new Erro(ErroEnum.Pagamento_PagamentoRN_ValidarSalvar_UsuarioSemAcesso));
            }

            Usuario alunoPagamento = contexto.Usuarios.FirstOrDefault(usuario => usuario.Id == pagamento.AlunoId && usuario.EscolaId == usuarioAtivo.EscolaId);
            if (alunoPagamento == null || alunoPagamento.Ativo == false || alunoPagamento.AulaId == null)
            {
                erros.Add(new Erro(ErroEnum.Pagamento_PagamentoRN_ValidarSalvar_AlunoInvalido));
            }

            return erros;
        }

        protected override void beforeSave(EnglishSchoolManagerModel.Pagamento entidadeInformada, EnglishSchoolManagerModel.Pagamento entidadeSalvar)
        {
            base.beforeSave(entidadeInformada, entidadeSalvar);

            Usuario aluno = contexto.Usuarios.Include("Aula").First(usuario => usuario.Id == entidadeSalvar.AlunoId);
            decimal valorMensalidade = aluno.ValorPersonalizado ? aluno.ValorMensalidade : aluno.Aula.ValorMensalidade;
            entidadeSalvar.Valor = valorMensalidade;
        }

        #region Geração de pagamento

        public static void GerarPagamentos()
        {
            try
            {
                List<int> idsEscolas = null;
                using (ESMEntities contexto = new ESMEntities())
                {
                    idsEscolas = contexto.Escolas.Where(escola => escola.Ativo).Select(escola => escola.Id).ToList();
                }

                List<Task> tasks = new List<Task>();
                foreach (int idEscola in idsEscolas)
                {
                    tasks.Add(Task.Factory.StartNew(() => { gerarPagamentos(idEscola); }));
                }

                Task.WaitAll(tasks.ToArray());
            }
            catch (Exception ex)
            {
                //TODO: Logar exception
            }
        }

        private static void gerarPagamentos(int escolaId)
        {
            try
            {
                using (ESMEntities contexto = new ESMEntities())
                {
                    List<Usuario> alunosGerarPagamento = listarAlunosGerarPagamento(escolaId, contexto);
                    if (alunosGerarPagamento.Count > 0)
                    {
                        foreach (Usuario aluno in alunosGerarPagamento)
                        {
                            gerarPagamento(aluno, contexto);
                        }
                        contexto.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                //TODO: Logar exception
            }
        }

        private static void gerarPagamento(Usuario aluno, ESMEntities contexto)
        {
            decimal valorMensalidade = aluno.ValorPersonalizado ? aluno.ValorMensalidade : aluno.Aula.ValorMensalidade;
            EnglishSchoolManagerModel.Pagamento pagamento = new EnglishSchoolManagerModel.Pagamento()
            {
                AlunoId = aluno.Id,
                DataPagamento = aluno.DataProximoPagamento,
                EscolaId = aluno.EscolaId,
                Valor = valorMensalidade,
                UsuarioInsercaoId = -99,
                UsuarioAlteracaoId = -99,
                DataInsercao = DateTime.UtcNow,
                DataAlteracao = DateTime.UtcNow
            };
            contexto.Pagamentos.AddObject(pagamento);
            aluno.DataProximoPagamento = aluno.DataProximoPagamento.GetValueOrDefault().AddMonths(1);
        }

        private static List<Usuario> listarAlunosGerarPagamento(int escolaId, ESMEntities contexto)
        {
            List<Usuario> alunosGerarPagamento = new List<Usuario>();
            try
            {
                DateTime dataDeHoje = DateTime.Today;
                DateTime dataMesQueVem = DateTime.Today.AddMonths(1);
                int nivelAcessoAluno = Convert.ToInt32(NivelAcessoEnum.Aluno);
                alunosGerarPagamento = contexto.Usuarios.Include("Aula")
                       .Where(usuario => usuario.Ativo == true
                           && usuario.EscolaId == escolaId
                           && usuario.AulaId != null
                           && usuario.NivelAcesso == nivelAcessoAluno
                           && usuario.DataProximoPagamento < dataMesQueVem
                           && !usuario.Pagamentos.Any(pagamento => pagamento.DataPagamento < dataMesQueVem
                                                       && pagamento.DataPagamento >= dataDeHoje)).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return alunosGerarPagamento;
        }

        #endregion Geração de pagamento
    }
}
