using Desafio.Ca.Crud.Application.Handlers.V1.Autores.Listar.Dtos;
using Desafio.Ca.Crud.Domain.Entidades;

namespace Desafio.Ca.Crud.Application.Handlers.V1.Autores.Listar
{
    public  class ListaAutorResponse
    {
        public List<ListaAutorDto> Autores { get; set; }
    }
}
