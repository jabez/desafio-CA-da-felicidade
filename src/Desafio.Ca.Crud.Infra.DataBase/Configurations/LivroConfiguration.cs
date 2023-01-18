using Desafio.Ca.Crud.Domain;
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
                .IsRequired();

            builder.Property(x => x.Ativo)
                .IsRequired();

            builder.HasMany(x => x.Autores)
                .WithMany();
        }
    }
}
