using TDLembretes.Models;
using Microsoft.EntityFrameworkCore;

namespace TDLembretes.Repositories.Data
{
    public class SeedData
    {

        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new tdlDbContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<tdlDbContext>>()))
            {
                if (!context.Usuarios.Any())
                {
                    context.Usuarios.AddRange(
                        new Usuario(id: "1", nome: "João da Silva", email: "joaosilva@gmail.com", senha: "1234", pontos: 50, telefone: "1499123-5136", tarefasPersonalizadas: new List<UsuarioTarefasPersonalizadas>(), tarefasOficiais: new List<UsuarioTarefasOficiais>()),
                         new Usuario(id: "2", nome: "Roberta Maria", email: "roberta@gmail.com", senha: "9876", pontos: 100, telefone: "1496203-4215", tarefasPersonalizadas: new List<UsuarioTarefasPersonalizadas>(), tarefasOficiais: new List<UsuarioTarefasOficiais>()),
                          new Usuario(id: "3", nome: "Junior Rodrigues", email: "junior@gmail.com", senha: "1221", pontos: 150, telefone: "1497428-6342", tarefasPersonalizadas: new List<UsuarioTarefasPersonalizadas>(), tarefasOficiais: new List<UsuarioTarefasOficiais>())
                    ); context.SaveChanges();
                }           

            }
        }

    }
}
