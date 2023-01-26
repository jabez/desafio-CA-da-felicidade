using Desafio.Ca.Crud.Application.Handlers.V1.Autores.Buscar;
using MediatR;

namespace Desafio.Ca.Crud.Application.Handlers.V1.Autores.Listar
{
    public  class ListaAutorRequest : IRequest<ListaAutorResponse>
    {
        const int maxPageSize = 20;
        public int PageNumber { get; set; } = 1;
        private int _pageSize = 10;
        public int PageSize
        {
            get { return _pageSize; }
            set { _pageSize = Math.Min(maxPageSize, value); }
        }
    }
}
