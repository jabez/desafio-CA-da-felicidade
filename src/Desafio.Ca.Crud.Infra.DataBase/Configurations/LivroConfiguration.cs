using Azure;
using Desafio.Ca.Crud.Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Diagnostics;
using System.Reflection.Emit;

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

            builder.HasOne(x => x.Autor)
                .WithMany(x => x.Livros);
        }
    }
}
