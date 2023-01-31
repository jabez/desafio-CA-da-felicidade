using Desafio.Ca.Crud.Domain.Interfaces.Repositories;
using MediatR;

namespace Desafio.Ca.Crud.Application.Handlers.V1.Livros.Listar
{
    public class ListaLivroHandler : IRequestHandler<ListaLivroRequest, ListaLivroResponse>
    {
        private readonly ILivroRepository _livroRepository;

        public ListaLivroHandler(ILivroRepository livroRepository) => _livroRepository = livroRepository;

        public async Task<ListaLivroResponse> Handle(ListaLivroRequest request, CancellationToken cancellationToken)
        {
            var retorno = await _livroRepository.ObterTodosPaginadoAsync(request.PageSize, request.PageNumber);
            return new ListaLivroResponse() { Livros = retorno };
        }
    }
}
