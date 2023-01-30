using Desafio.Ca.Crud.Application.Handlers.V1.Livros.Adicionar.Dtos;

namespace Desafio.Ca.Crud.Application.Handlers.V1.Livros.Adicionar
{
    public class AdicionaLivroResponse
    {
        public Guid Id { get; set; }
        public string Titulo { get; set; }
        public List<AutorDto> Autores { get; set; } = new List<AutorDto>();
        public string Categoria { get; set; }
        public string Editora { get; set; }
        public DateTime Lancamento { get; set; }
        public decimal Valor { get; set; }
        public string Edicao { get; set; }
        public string Sbn { get; set; }
        public bool Ativo { get; set; }
    }
}
