using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EnglishSchoolManagerModel;
using EnglishSchoolManagerRules.Geral;
using EnglishSchoolManagerModel.Geral;
using EnglishSchoolManagerModel.Enumerador;
using CommonsAPI.Date;

namespace EnglishSchoolManagerRules.Escola
{
    public class AulaRN : RNBase<Aula>
    {
        #region Construtores

        public AulaRN(Usuario usuarioAtivo)
            : base(usuarioAtivo)
        {

        }

        public AulaRN(Usuario usuarioAtivo, ESMEntities contexto)
            : base(usuarioAtivo, contexto)
        {

        }

        #endregion Construtores

        #region Métodos

        //No método salvar...
        //.OrderBy(horario => horario.DiaSemana).ThenBy(horario => horario.HorarioInicio)

        protected override List<EnglishSchoolManagerModel.Geral.Erro> validarSalvar(Aula aula)
        {
            List<Erro> erros = new List<Erro>();

            if (aula == null)
            {
                erros.Add(new Erro(ErroEnum.Escola_AulaRN_ValidarSalvar_UsuarioNULL));
                return erros;
            }

            if (usuarioAtivo.NivelAcesso != Convert.ToInt32(NivelAcessoEnum.Administrador))
            {
                erros.Add(new Erro(ErroEnum.Geral_PermissaoNegada));
                return erros;
            }

            if (aula.Id > 0)
            {
                if (PesquisarPorId(aula.Id) == null)
                {
                    erros.Add(new Erro(ErroEnum.Escola_AulaRN_ValidarSalvar_AulaNaoExistente));
                    return erros;
                }
            }
            validarHorariosAula(ref erros, aula);

            return erros;
        }

        private void validarHorariosAula(ref List<Erro> erros, Aula aula)
        {
            List<HorarioAula> horariosAula = aula.GetHorariosAula();
            if (horariosAula != null && horariosAula.Count > 0)
            {
                List<HorarioAula> horariosAulasSalvas = listarDemaisHorariosAulas(aula.Id);

                foreach (HorarioAula horarioAula in horariosAula)
                {
                    if (horarioAula.HorarioFim <= horarioAula.HorarioInicio)
                    {
                        erros.Add(new Erro(ErroEnum.Escola_AulaRN_ValidarSalvar_HorarioInvalido));
                        break;
                    }

                    if (verificarHorariosDuplicados(horarioAula, horariosAulasSalvas))
                    {
                        erros.Add(new Erro(ErroEnum.Escola_AulaRN_ValidarSalvar_HorarioJaExistete));
                        break;
                    }

                    if (verificarHorariosDuplicados(horarioAula, horariosAulasSalvas))
                    {
                        erros.Add(new Erro(ErroEnum.Escola_AulaRN_ValidarSalvar_HorarioJaExistete));
                        break;
                    }

                    if (verificarHorariosDuplicados(horarioAula, horariosAula.Where(horario => horario != horarioAula).ToList()))
                    {
                        erros.Add(new Erro(ErroEnum.Escola_AulaRN_ValidarSalvar_HorarioJaExistete));
                        break;
                    }
                }
            }
        }

        private List<HorarioAula> listarDemaisHorariosAulas(int aulaId)
        {
            List<HorarioAula> horariosAulasSalvas = new List<HorarioAula>();

            List<string> horariosDemaisAulas = contexto.Aulas
                .Where(aulaBD => aulaBD.Id != aulaId && aulaBD.HorariosJson != null && aulaBD.HorariosJson != "")
                .Select(aulaBD => aulaBD.HorariosJson).ToList();

            foreach (string horarioAulaStr in horariosDemaisAulas)
            {
                horariosAulasSalvas.AddRange(Aula.GetHorariosAula(horarioAulaStr));
            }

            return horariosAulasSalvas;
        }

        private bool verificarHorariosDuplicados(HorarioAula horarioAula, List<HorarioAula> horariosAulaBD)
        {
            foreach (HorarioAula horarioAulaBD in horariosAulaBD.Where(horaAulaBD => horaAulaBD.DiaSemana == horarioAula.DiaSemana))
            {
                if (DateHelper.PeriodosConcorrentes(horarioAula.HorarioInicio, horarioAula.HorarioFim.AddMinutes(-1), horarioAulaBD.HorarioInicio, horarioAulaBD.HorarioFim.AddMinutes(-1)))
                {
                    return true;
                }
            }

            return false;
        }

        protected override void beforeSave(Aula entidade, Aula entidadeSalvar)
        {
            base.beforeSave(entidade, entidadeSalvar);

            entidadeSalvar.Alunos.Clear();
            if (entidade.IdsAlunos != null && entidade.IdsAlunos.Count > 0)
            {
                List<Usuario> alunosInformados = contexto.Usuarios.Where(aluno => entidade.IdsAlunos.Contains(aluno.Id)).ToList();
                alunosInformados.ForEach(aluno => aluno.Aula = entidadeSalvar);
            }
        }

        #endregion Métodos
    }
}
