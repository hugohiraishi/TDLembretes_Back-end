using Microsoft.EntityFrameworkCore;
using TDLembretes.Models;
namespace TDLembretes.Repositories.Data
{
    public partial class tdlDbContext : DbContext
    {

        public DbSet<Produto> Produtos { get; set; }
        public DbSet<TarefaOficial> TarefasOficial { get; set; }
        public DbSet<TarefaPersonalizada> TarefasPersonalizada { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<UsuarioTarefasOficiais> UsuariosTarefasOficiais { get; set; }
        public DbSet<UsuarioTarefasPersonalizadas> UsuariosTarefasPersonalizadas { get; set; }

        public tdlDbContext()
        {
        }

        public tdlDbContext(DbContextOptions<tdlDbContext> options)
       : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .UseCollation("utf8mb4_0900_ai_ci")
                .HasCharSet("utf8mb4");

            modelBuilder.Entity<Produto>()
                .HasKey(p => p.Id);
            modelBuilder.Entity<Produto>()
                .Property(p => p.Id);

            modelBuilder.Entity<TarefaOficial>()
                .HasKey(o => o.Id);
            modelBuilder.Entity<TarefaOficial>()
                .Property(o => o.Id);

            modelBuilder.Entity<TarefaPersonalizada>()
                .HasKey(t => t.Id);
            modelBuilder.Entity<TarefaPersonalizada>()
                .Property(t => t.Id);

            modelBuilder.Entity<Usuario>()
                .HasKey(u => u.Id);
            modelBuilder.Entity<Usuario>()
                .Property(u => u.Id);

            modelBuilder.Entity<UsuarioTarefasOficiais>()
                .HasKey(x => new { x.UsuarioId, x.TarefaOficialId });

            modelBuilder.Entity<UsuarioTarefasOficiais>()
                .HasOne(x => x.Usuario)
                .WithMany(u => u.TarefasOficiais)
                .HasForeignKey(x => x.UsuarioId);

            modelBuilder.Entity<UsuarioTarefasOficiais>()
                .HasOne(x => x.TarefaOficial)
                .WithMany()
                .HasForeignKey(x => x.TarefaOficialId);

            modelBuilder.Entity<UsuarioTarefasPersonalizadas>()
                .HasKey(x => new { x.UsuarioId, x.TarefaPersonalizadaId });

            modelBuilder.Entity<UsuarioTarefasPersonalizadas>()
                .HasOne(x => x.Usuario)
                .WithMany(u => u.TarefasPersonalizadas)
                .HasForeignKey(x => x.UsuarioId);

            modelBuilder.Entity<UsuarioTarefasPersonalizadas>()
                .HasOne(x => x.TarefaPersonalizada)
                .WithMany()
                .HasForeignKey(x => x.TarefaPersonalizadaId);


            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
