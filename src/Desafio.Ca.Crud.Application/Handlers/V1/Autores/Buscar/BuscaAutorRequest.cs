using MediatR;

namespace Desafio.Ca.Crud.Application.Handlers.V1.Autores.Buscar
{
    public class BuscaAutorRequest : IRequest<BuscaAutorResponse>
    {
        public Guid Id { get; set; }
    }
}
