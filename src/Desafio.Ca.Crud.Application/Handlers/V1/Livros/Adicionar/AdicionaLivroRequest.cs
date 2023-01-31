using MediatR;

namespace Desafio.Ca.Crud.Application.Handlers.V1.Livros.Adicionar
{
    public class AdicionaLivroRequest : IRequest<AdicionaLivroResponse>
    {
        public string Titulo { get; set; }
        public Guid? AutorId { get; set; }
        public string Categoria { get; set; }
        public string Editora { get; set; }
        public DateTime Lancamento { get; set; }
        public decimal Valor { get; set; }
        public string Edicao { get; set; }
        public string Sbn { get; set; }
    }
}
