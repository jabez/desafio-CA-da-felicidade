using Desafio.Ca.Crud.Application.Models.Retornos;
using MediatR;
using System.Text.Json.Serialization;

namespace Desafio.Ca.Crud.Application.Handlers.V1.Autores.Alterar
{
    public class AlteraAutorRequest : IRequest<RetornoBase<AlteraAutorResponse>>
    {
        [JsonIgnore]
        public Guid Id { get; set; }
        public string Nome { get; set; }
    }
}
