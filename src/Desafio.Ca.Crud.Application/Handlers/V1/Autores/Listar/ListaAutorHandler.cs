using Desafio.Ca.Crud.Application.Handlers.V1.Autores.Listar.Dtos;
using Desafio.Ca.Crud.Domain.Entidades;
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

            return new ListaAutorResponse() { Autores = MontarListaAutorDto(retorno) };
        }

        private static List<ListaAutorDto> MontarListaAutorDto(List<Autor> retorno)
        {
            return retorno.Select(x =>
                new ListaAutorDto()
                {
                    Id = x.Id,
                    Ativo = x.Ativo,
                    Nome = x.Nome,
                    DataAtualizacao = x.DataAtualizacao,
                    Livros = x.Livros.Select(x => new LivroDto()
                    {
                        Id = x.Id,
                        Titulo= x.Titulo
                    }).ToList(),
                }).ToList();
        }
    }
}
