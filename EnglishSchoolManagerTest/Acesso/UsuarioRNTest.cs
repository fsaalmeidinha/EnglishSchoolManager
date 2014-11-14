using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EnglishSchoolManagerModel;
using EnglishSchoolManagerTest.Geral;
using EnglishSchoolManagerModel.Enumerador;
using EnglishSchoolManagerModel.Geral;
using EnglishSchoolManagerRules.Acesso;

namespace EnglishSchoolManagerTest.Acesso
{
    [TestClass]
    public class UsuarioRNTest : TestBase
    {
        [TestInitialize]
        public void MyTestInitialize()
        {

        }

        [TestCleanup]
        public void MyTestCleanup()
        {
            ESMEntities contexto = new ESMEntities();

            contexto.Usuarios.Where(usr => usr.UsuarioInsercaoId == idUsuarioTeste).
                ToList().ForEach(usr => contexto.Usuarios.DeleteObject(usr));

            contexto.SaveChanges();
        }

        [TestMethod]
        public void Salvar_UsuarioNulo()
        {
            UsuarioRN usuarioRN = new UsuarioRN(this.usuarioTesteAdmin);
            Resultado resultado = usuarioRN.Salvar(null);

            Assert.IsTrue(!resultado.ObteveSucesso, "RN retornou 'ObteveSucesso' como true, mesmo enviando informações inválidas");
            Assert.IsTrue(resultado.Erros.Count == 1 && resultado.Erros.Count(err => err.Codigo == ErroEnum.Acesso_UsuarioRN_ValidarSalvar_UsuarioNULL.ToString()) == 1, "Quantidade de erros retornados inválida");
        }

        [TestMethod]
        public void Salvar_IdInexistente()
        {
            UsuarioRN usuarioRN = new UsuarioRN(this.usuarioTesteAdmin);

            Usuario usuario = new Usuario()
            {
                Id = Int32.MaxValue,
                Email = "usuarioTeste@email.com.br",
                NivelAcesso = Convert.ToInt32(NivelAcessoEnum.Administrador),
                Nome = "Usuário de teste",
                Senha = "123456"
            };

            Resultado resultado = usuarioRN.Salvar(usuario);

            Assert.IsTrue(!resultado.ObteveSucesso, "RN retornou 'ObteveSucesso' como true, mesmo enviando informações inválidas");
            Assert.IsTrue(resultado.Erros.Count == 1 && resultado.Erros.Count(err => err.Codigo == ErroEnum.Acesso_UsuarioRN_ValidarSalvar_UsuarioNaoExistente.ToString()) == 1, "Quantidade de erros retornados inválida");
        }

        [TestMethod]
        public void Salvar()
        {
            UsuarioRN usuarioRN = new UsuarioRN(this.usuarioTesteAdmin);

            Usuario usuario = new Usuario()
            {
                Email = "usuarioTeste@email.com.br",
                NivelAcesso = Convert.ToInt32(NivelAcessoEnum.Administrador),
                Nome = "Usuário de teste",
                Senha = "123456"
            };

            Resultado resultado = usuarioRN.Salvar(usuario);

            Assert.IsTrue(resultado.ObteveSucesso);
            Assert.IsTrue(resultado.Erros.Count == 0);

            Usuario usuarioSalvoBD = new ESMEntities().Usuarios.First(usr => usr.Id == resultado.IdEntidadeSalva);
            Assert.IsTrue(usuarioSalvoBD.Email == usuario.Email);
            Assert.IsTrue(usuarioSalvoBD.NivelAcesso == usuario.NivelAcesso);
            Assert.IsTrue(usuarioSalvoBD.Nome == usuario.Nome);
            Assert.IsTrue(usuarioSalvoBD.Senha == usuario.Senha);
            Assert.IsTrue(usuarioSalvoBD.UsuarioInsercaoId == idUsuarioTeste);
            Assert.IsTrue(usuarioSalvoBD.UsuarioAlteracaoId == idUsuarioTeste);
            Assert.IsTrue(usuarioSalvoBD.DataInsercao > DateTime.UtcNow.AddMinutes(-1));
            Assert.IsTrue(usuarioSalvoBD.DataAlteracao > DateTime.UtcNow.AddMinutes(-1));
        }

        [TestMethod]
        public void Salvar_AlterarUsuario()
        {
            Usuario usuarioAlterar = manipularBase_CriarUsuario();

            UsuarioRN usuarioRN = new UsuarioRN(this.usuarioTesteAdmin);

            usuarioAlterar.Nome = usuarioAlterar.Nome + "alt";
            usuarioAlterar.Senha = usuarioAlterar.Senha + "alt";

            Resultado resultado = usuarioRN.Salvar(usuarioAlterar);

            Assert.IsTrue(resultado.ObteveSucesso);
            Assert.IsTrue(resultado.Erros.Count == 0);

            Usuario usuarioAlteradoBD = new ESMEntities().Usuarios.First(usr => usr.Id == usuarioAlterar.Id);
            Assert.IsTrue(usuarioAlteradoBD.Nome == usuarioAlterar.Nome);
            Assert.IsTrue(usuarioAlteradoBD.Senha == usuarioAlterar.Senha);
        }

        [TestMethod]
        public void Salvar_AlterarEmail()
        {
            Usuario usuarioAlterar = manipularBase_CriarUsuario();

            UsuarioRN usuarioRN = new UsuarioRN(this.usuarioTesteAdmin);

            usuarioAlterar.Email = usuarioAlterar.Email + "alt";

            Resultado resultado = usuarioRN.Salvar(usuarioAlterar);

            Assert.IsTrue(!resultado.ObteveSucesso);
            Assert.IsTrue(resultado.Erros.Count == 1 && resultado.Erros.Count(err => err.Codigo == ErroEnum.Acesso_UsuarioRN_ValidarSalvar_AlterarEmail.ToString()) == 1);
        }

        [TestMethod]
        public void Salvar_AlterarNivelAcesso()
        {
            Usuario usuarioAlterar = manipularBase_CriarUsuario();

            UsuarioRN usuarioRN = new UsuarioRN(this.usuarioTesteAdmin);

            usuarioAlterar.NivelAcesso = Convert.ToInt32(usuarioAlterar.NivelAcesso == Convert.ToInt32(NivelAcessoEnum.Administrador) ? NivelAcessoEnum.Aluno : NivelAcessoEnum.Administrador);

            Resultado resultado = usuarioRN.Salvar(usuarioAlterar);

            Assert.IsTrue(!resultado.ObteveSucesso);
            Assert.IsTrue(resultado.Erros.Count == 1 && resultado.Erros.Count(err => err.Codigo == ErroEnum.Acesso_UsuarioRN_ValidarSalvar_AlterarNivelAcesso.ToString()) == 1);
        }

        [TestMethod]
        public void Salvar_EmailExistente()
        {
            Usuario usuarioAlterar = manipularBase_CriarUsuario();

            UsuarioRN usuarioRN = new UsuarioRN(this.usuarioTesteAdmin);

            Usuario usuario = new Usuario()
            {
                Email = usuarioAlterar.Email,
                NivelAcesso = Convert.ToInt32(NivelAcessoEnum.Administrador),
                Nome = "Usuário de teste",
                Senha = "123456"
            };

            Resultado resultado = usuarioRN.Salvar(usuario);

            Assert.IsTrue(!resultado.ObteveSucesso);
            Assert.IsTrue(resultado.Erros.Count == 1 && resultado.Erros.Count(err => err.Codigo == ErroEnum.Acesso_UsuarioRN_ValidarSalvar_EmailJaExistente.ToString()) == 1);
        }

        [TestMethod]
        public void Salvar_NivelAcessoInvalido()
        {
            UsuarioRN usuarioRN = new UsuarioRN(this.usuarioTesteAdmin);

            Usuario usuario = new Usuario()
            {
                Email = "usuarioTeste@email.com.br",
                NivelAcesso = Int32.MaxValue,
                Nome = "Usuário de teste",
                Senha = "123456"
            };

            Resultado resultado = usuarioRN.Salvar(usuario);

            Assert.IsTrue(!resultado.ObteveSucesso);
            Assert.IsTrue(resultado.Erros.Count == 1 && resultado.Erros.Count(err => err.Codigo == ErroEnum.Acesso_UsuarioRN_ValidarSalvar_NivelAcessoInvalido.ToString()) == 1);
        }

        [TestMethod]
        public void Salvar_EmailInvalido()
        {
            UsuarioRN usuarioRN = new UsuarioRN(this.usuarioTesteAdmin);

            Usuario usuario = new Usuario()
            {
                Email = "",
                NivelAcesso = Convert.ToInt32(NivelAcessoEnum.Administrador),
                Nome = "Usuário de teste",
                Senha = "123456"
            };

            Resultado resultado = usuarioRN.Salvar(usuario);

            Assert.IsTrue(!resultado.ObteveSucesso);
            Assert.IsTrue(resultado.Erros.Count == 1 && resultado.Erros.Count(err => err.Codigo == ErroEnum.Acesso_UsuarioRN_ValidarSalvar_EmailInvalido.ToString()) == 1);
        }

        [TestMethod]
        public void Salvar_NomeInvalido()
        {
            UsuarioRN usuarioRN = new UsuarioRN(this.usuarioTesteAdmin);

            Usuario usuario = new Usuario()
            {
                Email = "usuarioTeste@email.com.br",
                NivelAcesso = Convert.ToInt32(NivelAcessoEnum.Administrador),
                Nome = "",
                Senha = "123456"
            };

            Resultado resultado = usuarioRN.Salvar(usuario);

            Assert.IsTrue(!resultado.ObteveSucesso);
            Assert.IsTrue(resultado.Erros.Count == 1 && resultado.Erros.Count(err => err.Codigo == ErroEnum.Acesso_UsuarioRN_ValidarSalvar_NomeInvalido.ToString()) == 1);
        }

        [TestMethod]
        public void Salvar_SenhaInvalida()
        {
            UsuarioRN usuarioRN = new UsuarioRN(this.usuarioTesteAdmin);

            Usuario usuario = new Usuario()
            {
                Email = "usuarioTeste@email.com.br",
                NivelAcesso = Convert.ToInt32(NivelAcessoEnum.Administrador),
                Nome = "Usuário de teste",
                Senha = ""
            };

            Resultado resultado = usuarioRN.Salvar(usuario);

            Assert.IsTrue(!resultado.ObteveSucesso);
            Assert.IsTrue(resultado.Erros.Count == 1 && resultado.Erros.Count(err => err.Codigo == ErroEnum.Acesso_UsuarioRN_ValidarSalvar_SenhaInvalida.ToString()) == 1);
        }

        [TestMethod]
        public void Salvar_UsuarioAtivo_NivelDiferenteADM()
        {
            UsuarioRN usuarioRN = new UsuarioRN(this.usuarioTesteAluno);

            Usuario usuario = new Usuario()
            {
                Email = "usuarioTeste@email.com.br",
                NivelAcesso = Convert.ToInt32(NivelAcessoEnum.Administrador),
                Nome = "Usuário de teste",
                Senha = "123456"
            };

            Resultado resultado = usuarioRN.Salvar(usuario);

            Assert.IsTrue(!resultado.ObteveSucesso);
            Assert.IsTrue(resultado.Erros.Count == 1 && resultado.Erros.Count(err => err.Codigo == ErroEnum.Acesso_UsuarioRN_ValidarSalvar_UsuarioNaoADM_SalvandoOuAlterandoUsuario.ToString()) == 1);
        }

        [TestMethod]
        public void Salvar_Alterar_UsuarioAtivo_NivelDiferenteADM()
        {
            Usuario usuarioAlterar = manipularBase_CriarUsuario();

            UsuarioRN usuarioRN = new UsuarioRN(this.usuarioTesteAluno);

            usuarioAlterar.Nome = usuarioAlterar.Nome + "alt";

            Resultado resultado = usuarioRN.Salvar(usuarioAlterar);

            Assert.IsTrue(!resultado.ObteveSucesso);
            Assert.IsTrue(resultado.Erros.Count == 1 && resultado.Erros.Count(err => err.Codigo == ErroEnum.Acesso_UsuarioRN_ValidarSalvar_UsuarioNaoADM_SalvandoOuAlterandoUsuario.ToString()) == 1);
        }

        [TestMethod]
        public void Autenticar()
        {
            Usuario usuarioSalvoBD = manipularBase_CriarUsuario();

            Usuario usuarioAutenticado = UsuarioRN.Autenticar(usuarioSalvoBD.Email.ToUpper(), usuarioSalvoBD.Senha);

            Assert.IsTrue(usuarioAutenticado != null && usuarioAutenticado.Id == usuarioSalvoBD.Id);
        }

        [TestMethod]
        public void Autenticar_SenhaIncorreta()
        {
            Usuario usuarioSalvoBD = manipularBase_CriarUsuario();

            Usuario usuarioAutenticado = UsuarioRN.Autenticar(usuarioSalvoBD.Email.ToUpper(), "SENHA ERRADA..");

            Assert.IsTrue(usuarioAutenticado == null);
        }

        [TestMethod]
        public void Autenticar_EmailIncorreto()
        {
            Usuario usuarioSalvoBD = manipularBase_CriarUsuario();

            Usuario usuarioAutenticado = UsuarioRN.Autenticar("EMAIL INCORRETO", usuarioSalvoBD.Senha);

            Assert.IsTrue(usuarioAutenticado == null);
        }

        #region Manipulação da base de dados

        private Usuario manipularBase_CriarUsuario()
        {
            ESMEntities contexto = new ESMEntities();

            Usuario usuario = new Usuario()
            {
                Email = "usuarioTeste@email.com.br",
                NivelAcesso = Convert.ToInt32(NivelAcessoEnum.Administrador),
                Nome = "Usuário de teste",
                Senha = "123456",

                UsuarioInsercaoId = idUsuarioTeste,
                UsuarioAlteracaoId = idUsuarioTeste,
                DataInsercao = DateTime.UtcNow,
                DataAlteracao = DateTime.UtcNow
            };

            contexto.Usuarios.AddObject(usuario);
            contexto.SaveChanges();

            return usuario;
        }

        #endregion Manipulação da base de dados
    }
}
