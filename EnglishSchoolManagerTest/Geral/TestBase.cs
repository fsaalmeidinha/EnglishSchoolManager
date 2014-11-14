using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EnglishSchoolManagerModel;
using EnglishSchoolManagerModel.Enumerador;

namespace EnglishSchoolManagerTest.Geral
{
    public class TestBase
    {
        protected const int idUsuarioTeste = -99;

        protected Usuario usuarioTesteAdmin = new Usuario()
        {
            Id = idUsuarioTeste,
            Email = "admin@email.com.br",
            NivelAcesso = Convert.ToInt32(NivelAcessoEnum.Administrador),
            Nome = "Usuário admin",
            Senha = "123456"
        };

        protected Usuario usuarioTesteAluno = new Usuario()
        {
            Id = idUsuarioTeste,
            Email = "aluno@email.com.br",
            NivelAcesso = Convert.ToInt32(NivelAcessoEnum.Aluno),
            Nome = "Usuário aluno",
            Senha = "123456"
        };
    }
}
