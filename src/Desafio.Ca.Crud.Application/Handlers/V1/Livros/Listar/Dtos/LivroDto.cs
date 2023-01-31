using Desafio.Ca.Crud.Domain.Entidades;

namespace Desafio.Ca.Crud.Application.Handlers.V1.Livros.Listar.Dtos
{
    public class LivroDto
    {
        public Guid Id { get; set; }
        public AutorDto Autor { get; set; }
        public string Categoria { get; set; }
        public string Editora { get; set; }
        public DateTime Lancamento { get; set; }
        public decimal Valor { get; set; }
        public string Edicao { get; set; }
        public string Sbn { get; set; }
        public string Titulo { get; set; }
        public bool Ativo { get; set; }
    }

    public class AutorDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
