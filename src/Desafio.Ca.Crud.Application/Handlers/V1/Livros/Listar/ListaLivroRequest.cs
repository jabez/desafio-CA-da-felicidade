﻿using MediatR;

namespace Desafio.Ca.Crud.Application.Handlers.V1.Livros.Listar
{
    public class ListaLivroRequest : IRequest<ListaLivroResponse> 
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
