using Desafio.Ca.Crud.Application.Handlers.V1.Livros.Adicionar.Dtos;
using Desafio.Ca.Crud.Domain.Entidades;
using Desafio.Ca.Crud.Domain.Interfaces.Repositories;
using MediatR;

namespace Desafio.Ca.Crud.Application.Handlers.V1.Livros.Adicionar
{
    public class AdicionaLivroHandler : IRequestHandler<AdicionaLivroRequest, AdicionaLivroResponse>
    {
        private readonly IAutorRepository _autorRepository;
        private readonly ILivroRepository _livroRepository;
        public AdicionaLivroHandler(IAutorRepository autorRepository, ILivroRepository livroRepository)
        {
            _autorRepository = autorRepository;
            _livroRepository = livroRepository;
        } 

        public async Task<AdicionaLivroResponse> Handle(AdicionaLivroRequest request, CancellationToken cancellationToken)
        {
            var livro = new Livro(categoria: request.Categoria, editora: request.Editora, lancamento: request.Lancamento,
                                  valor: request.Valor, edicao: request.Edicao, sbn: request.Sbn, titulo: request.Titulo);

            if (request.AutorId != null)
            {
                livro.Autor = await ObterAutor(request.AutorId.Value);
            }

            await _livroRepository.AdicionarAsync(livro);

            return MontarAdicionaLivroResponse(livro);
        }

        private async Task<Autor> ObterAutor(Guid autorId)
        {
           var autor = await _autorRepository.Obter(autorId);
            if (autor != null)
                return autor;

            return null;
        }

        private static AdicionaLivroResponse MontarAdicionaLivroResponse(Livro livro)
        {
            var adicionaLivroResponse = new AdicionaLivroResponse()
            {
                Id= livro.Id,
                Titulo= livro.Titulo,
                Categoria= livro.Categoria,
                Editora= livro.Editora,
                Lancamento= livro.Lancamento,
                Valor= livro.Valor,
                Edicao= livro.Edicao,
                Sbn = livro.Sbn,
                Ativo= livro.Ativo,
                Autor = new AutorDto() { Nome = livro.Autor.Nome } 
            };

            return adicionaLivroResponse;
        }
    }
}
