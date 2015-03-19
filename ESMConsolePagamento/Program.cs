using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESMConsolePagamento
{
    public class Program
    {
        static void Main()
        {
            using (EnglishSchoolManagerModel.ESMEntities contexto = new EnglishSchoolManagerModel.ESMEntities())
            {
                EnglishSchoolManagerModel.Usuario usuario = new EnglishSchoolManagerModel.Usuario()
                {
                    Ativo = true,
                    DataAlteracao = DateTime.UtcNow,
                    DataInsercao = DateTime.UtcNow,
                    Email = Guid.NewGuid().ToString().Substring(0, 10) + "@email.com",
                    EscolaId = 1,
                    NivelAcesso = 1,
                    Nome = Guid.NewGuid().ToString().Substring(0, 10),
                    Senha = "123456",
                    UsuarioAlteracaoId = -1,
                    UsuarioInsercaoId = -1
                };

                contexto.Usuarios.AddObject(usuario);
                contexto.SaveChanges();
            }
        }
    }
}
