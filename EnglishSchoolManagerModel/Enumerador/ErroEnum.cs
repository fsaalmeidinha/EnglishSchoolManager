using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EnglishSchoolManagerModel.Enumerador
{
    public enum ErroEnum
    {
        [System.ComponentModel.Description("Permissão negada")]
        Geral_PermissaoNegada = 999990001,

        [System.ComponentModel.Description("Erro desconhecido")]
        ErroDesconhecido = 0,
        [System.ComponentModel.Description("O usuário não foi informado")]
        Acesso_UsuarioRN_ValidarSalvar_UsuarioNULL = 1,
        [System.ComponentModel.Description("Usuário informado não existe")]
        Acesso_UsuarioRN_ValidarSalvar_UsuarioNaoExistente = 2,
        [System.ComponentModel.Description("O email do usuário não pode ser alterado")]
        Acesso_UsuarioRN_ValidarSalvar_AlterarEmail = 3,
        [System.ComponentModel.Description("O nível de acesso do usuário não pode ser alterado")]
        Acesso_UsuarioRN_ValidarSalvar_AlterarNivelAcesso = 4,
        [System.ComponentModel.Description("Nível de acesso inválido para o usuário")]
        Acesso_UsuarioRN_ValidarSalvar_NivelAcessoInvalido = 5,
        [System.ComponentModel.Description("Email inválido")]
        Acesso_UsuarioRN_ValidarSalvar_EmailInvalido = 6,
        [System.ComponentModel.Description("Nome inválido")]
        Acesso_UsuarioRN_ValidarSalvar_NomeInvalido = 7,
        [System.ComponentModel.Description("Senha inválida")]
        Acesso_UsuarioRN_ValidarSalvar_SenhaInvalida = 8,
        [System.ComponentModel.Description("Usuário não tem permissão")]
        Acesso_UsuarioRN_ValidarSalvar_UsuarioNaoADM_SalvandoOuAlterandoUsuario = 9,
        [System.ComponentModel.Description("Email já existente na base de dados")]
        Acesso_UsuarioRN_ValidarSalvar_EmailJaExistente = 10,
        [System.ComponentModel.Description("O usuário não foi informado")]
        Escola_AulaRN_ValidarSalvar_UsuarioNULL = 11,
        [System.ComponentModel.Description("Horário da aula inválido")]
        Escola_AulaRN_ValidarSalvar_HorarioInvalido = 12,
        [System.ComponentModel.Description("Já existe uma aula para o mesmo horário e dia da semana")]
        Escola_AulaRN_ValidarSalvar_HorarioJaExistete = 13,
        [System.ComponentModel.Description("Aula informada não existe")]
        Escola_AulaRN_ValidarSalvar_AulaNaoExistente = 14,
    }
}
