using Desafio.Ca.Crud.Application.Models.Retornos;
using MediatR;
using System.Text.Json.Serialization;

namespace Desafio.Ca.Crud.Application.Handlers.V1.Livros.Alterar
{
    public class AlteraLivroRequest : IRequest<RetornoBase<AlteraLivroResponse>>
    {
        [JsonIgnore]
        public Guid Id { get; set; }
        public string Categoria { get; set; }
        public string Editora { get; set; }
        public DateTime Lancamento { get; set; }
        public decimal Valor { get; set; }
        public string Edicao { get; set; }
        public string Sbn { get; set; }
        public string Titulo { get; set; }
        public List<Guid> Autores { get; set; }
    }
}
