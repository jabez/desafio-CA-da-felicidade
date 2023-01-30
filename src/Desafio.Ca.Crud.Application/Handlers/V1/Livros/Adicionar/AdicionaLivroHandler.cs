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

            if (request.Autores != null)
            {
                livro.Autores = await ObterAutores(request.Autores);
            }

            await _livroRepository.AdicionarAsync(livro);

            return MontarAdicionaLivroResponse(livro);
        }

        private async Task<List<Autor>> ObterAutores(List<Guid> Ids)
        {
            var retorno = new List<Autor>();

            foreach (var item in Ids)
            {
                var autor = await _autorRepository.Obter(item);
                if(autor!= null)
                    retorno.Add(autor);
            }

            return retorno;
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
            };

            foreach (var item in livro.Autores)
            {
                adicionaLivroResponse.Autores.Add(new AutorDto() { Nome = item.Nome });
            }

            return adicionaLivroResponse;
        }
    }
}
