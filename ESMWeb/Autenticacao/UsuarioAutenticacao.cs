using EnglishSchoolManagerModel;
using EnglishSchoolManagerModel.Enumerador;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ESMWeb.Autenticacao
{
    public class UsuarioAutenticacao
    {
        public UsuarioAutenticacao()
        {

        }

        public UsuarioAutenticacao(Usuario usuario)
        {
            this.Id = usuario.Id;
            this.Nome = usuario.Nome;
            this.Email = usuario.Email;
            this.UsuarioAdmin = usuario.NivelAcesso == Convert.ToInt32(NivelAcessoEnum.Administrador);
            this.EscolaId = usuario.EscolaId;

            if (usuario.Escola != null)
            {
                this.NomeEscola = usuario.Escola.Nome;
            }
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public int EscolaId { get; set; }
        public string NomeEscola { get; set; }
        public bool UsuarioAdmin { get; set; }

        public Usuario RecuperarUsuario()
        {
            Usuario usuario = new Usuario()
            {
                Id = this.Id,
                EscolaId = this.EscolaId,
                Ativo = true,
                Nome = this.Nome,
                Email = this.Email,
                NivelAcesso = this.UsuarioAdmin ? Convert.ToInt32(NivelAcessoEnum.Administrador) : Convert.ToInt32(NivelAcessoEnum.Aluno)
            };

            if (!String.IsNullOrEmpty(this.NomeEscola))
            {
                usuario.Escola = new Escola()
                {
                    Id = this.EscolaId,
                    Nome = this.NomeEscola
                };
            }

            return usuario;
        }
    }
}