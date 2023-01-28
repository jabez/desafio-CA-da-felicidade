using Desafio.Ca.Crud.Domain.Entidades;
using Desafio.Ca.Crud.Infra.DataBase.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Desafio.Ca.Crud.Infra.DataBase
{
    public class BibliotecaContext : DbContext
    {
        public BibliotecaContext()
        {

        }
        public BibliotecaContext(DbContextOptions<BibliotecaContext> options)
        : base(options) { }

        public DbSet<Livro> Livros {  get; set; }
        public DbSet<Autor> Autores { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            new LivroConfiguration().Configure(modelBuilder.Entity<Livro>());
            new AutorConfiguration().Configure(modelBuilder.Entity<Autor>());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

    }
}
