using Desafio.Ca.Crud.Application.Handlers.V1.Livros.Listar.Dtos;
using Desafio.Ca.Crud.Domain.Entidades;
using Desafio.Ca.Crud.Domain.Interfaces.Repositories;
using MediatR;
using System.Linq;

namespace Desafio.Ca.Crud.Application.Handlers.V1.Livros.Listar
{
    public class ListaLivroHandler : IRequestHandler<ListaLivroRequest, ListaLivroResponse>
    {
        private readonly ILivroRepository _livroRepository;

        public ListaLivroHandler(ILivroRepository livroRepository) => _livroRepository = livroRepository;

        public async Task<ListaLivroResponse> Handle(ListaLivroRequest request, CancellationToken cancellationToken)
        {
            var retorno = await _livroRepository.ObterTodosPaginadoAsync(request.PageSize, request.PageNumber);
            return new ListaLivroResponse() { Livros = MontarLivroDto(retorno) };
        }

        private static List<LivroDto> MontarLivroDto(List<Livro> retorno)
        {
            return retorno.Select(x =>
                new LivroDto()
                {
                    Id = x.Id,
                    Ativo = x.Ativo,
                    Categoria = x.Categoria,
                    Editora = x.Editora,
                    Lancamento = x.Lancamento,
                    Valor = x.Valor,
                    Edicao = x.Edicao,
                    Sbn = x.Sbn,
                    Titulo = x.Titulo,
                    Autor = new AutorDto()
                    {
                        Id = x.Autor.Id,
                        Name = x.Autor.Nome
                    }
                }).ToList();
        }
    }
}
