using Desafio.Ca.Crud.Domain.Interfaces.Repositories;
using MediatR;

namespace Desafio.Ca.Crud.Application.Handlers.V1.Autores.Listar
{
    public class ListaAutorHandler : IRequestHandler<ListaAutorRequest, ListaAutorResponse>
    {
        private readonly IAutorRepository _autorRepository;

        public ListaAutorHandler(IAutorRepository autorRepository) => _autorRepository = autorRepository;
    

        public async Task<ListaAutorResponse> Handle(ListaAutorRequest request, CancellationToken cancellationToken)
        {
            var retorno = await _autorRepository.ObterTodosPaginadoAsync(request.PageSize, request.PageNumber);

            return new ListaAutorResponse() { Autores = retorno };
        }
    }
}
