using Azure;
using Desafio.Ca.Crud.Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Desafio.Ca.Crud.Infra.DataBase.Configurations
{
    public class LivroConfiguration : IEntityTypeConfiguration<Livro>
    {
        public void Configure(EntityTypeBuilder<Livro> builder)
        {
            builder
                .ToTable("Livro");

            builder
                .HasKey(c => c.Id);

            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd();

            builder.Property(x => x.Categoria)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(x => x.Editora)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(x => x.Edicao)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(x => x.Sbn)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(x => x.Titulo)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(x => x.Lancamento)
                .IsRequired();

            builder.Property(x => x.Valor)
                .IsRequired().HasPrecision(14,2);

            builder.Property(x => x.Ativo)
                .IsRequired();

           /* builder.HasMany(x => x.Autores)
                .WithMany(x => x.Livros)
                .UsingEntity(j => j.ToTable("LivroAutor"));*/
            builder.HasMany(x => x.Autores)
                .WithMany(x => x.Livros)
                .UsingEntity<Dictionary<string, object>>(
                "LivroAutor",
                j => j
                    .HasOne<Autor>()
                    .WithMany()
                    .HasForeignKey("AutoresId")
                    .HasConstraintName("FK_LivroAutor_Autor_AutorId")
                    .OnDelete(DeleteBehavior.Cascade),
                j => j
                    .HasOne<Livro>()
                    .WithMany()
                    .HasForeignKey("LivrosId")
                    .HasConstraintName("FK_LivroAutor_Livro_LivroId")
                    .OnDelete(DeleteBehavior.ClientCascade));
        }
    }
}
