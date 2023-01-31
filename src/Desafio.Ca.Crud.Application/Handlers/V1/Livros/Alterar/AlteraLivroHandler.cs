using Desafio.Ca.Crud.Application.Models.Retornos;
using Desafio.Ca.Crud.Domain.Entidades;
using Desafio.Ca.Crud.Domain.Interfaces.Repositories;
using MediatR;

namespace Desafio.Ca.Crud.Application.Handlers.V1.Livros.Alterar
{
    public class AlteraLivroHandler : IRequestHandler<AlteraLivroRequest, RetornoBase<AlteraLivroResponse>>
    {
        private readonly ILivroRepository _livroRepository;
        private readonly IAutorRepository _autorRepository;
        public AlteraLivroHandler(ILivroRepository livroRepository, IAutorRepository autorRepository)
        {
            _livroRepository = livroRepository;
            _autorRepository = autorRepository;
        } 

        public async Task<RetornoBase<AlteraLivroResponse>> Handle(AlteraLivroRequest request, CancellationToken cancellationToken)
        {
            var livro = await _livroRepository.Obter(request.Id);
            if (livro == null)
            {
                var retorno = new RetornoBase<AlteraLivroResponse>
                {
                    Codigo = 404
                };
                return retorno;
            };
            await AtualizarPropriedadesLivro(livro,request);

            return new RetornoBase<AlteraLivroResponse>()
            {
                Sucesso = true,
                Response = new AlteraLivroResponse
                {
                    Livro = livro
                }
            };
        }

        private async Task AtualizarPropriedadesLivro(Livro livro, AlteraLivroRequest request)
        {
            livro.Categoria = request.Categoria;
            livro.Editora= request.Editora;
            livro.Lancamento= request.Lancamento;
            livro.Valor= request.Valor;
            livro.Edicao= request.Edicao;
            livro.Sbn = request.Sbn;
            livro.Titulo = request.Titulo;
            livro.Autor = await ObterAutor(request.AutorId);

        }

        private async Task<Autor> ObterAutor(Guid? autorId)
        {
            if (!autorId.HasValue)
            {
                return null;
            }

            var autor = await _autorRepository.Obter(autorId.Value);
            if (autor != null)
                return autor;

            return null;
        }
    }
}
