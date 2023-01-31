using Desafio.Ca.Crud.Application.Handlers.V1.Autores.Excluir;
using Desafio.Ca.Crud.Application.Models.Retornos;
using Desafio.Ca.Crud.Domain.Entidades;
using Desafio.Ca.Crud.Domain.Interfaces.Repositories;
using MediatR;

namespace Desafio.Ca.Crud.Application.Handlers.V1.Livros.Excluir
{
    public class ExcluiLivroHandler : IRequestHandler<ExcluiLivroRequest, RetornoBase<ExcluiLivroResponse>>
    {
        private readonly ILivroRepository _livroRepository;
        public ExcluiLivroHandler(ILivroRepository livroRepository) => _livroRepository = livroRepository;
        public async Task<RetornoBase<ExcluiLivroResponse>> Handle(ExcluiLivroRequest request, CancellationToken cancellationToken)
        {
            var livro = await _livroRepository.Obter(request.Id);
            if (livro == null)
            {
                var retorno = new RetornoBase<ExcluiLivroResponse>
                {
                    Codigo = 404
                };
                return retorno;
            };

            await _livroRepository.RemoverAsync(livro);

            return new RetornoBase<ExcluiLivroResponse>() { Sucesso = true };
        }
    }
}
