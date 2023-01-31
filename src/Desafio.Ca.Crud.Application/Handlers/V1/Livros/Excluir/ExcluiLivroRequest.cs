using Desafio.Ca.Crud.Application.Models.Retornos;
using MediatR;

namespace Desafio.Ca.Crud.Application.Handlers.V1.Livros.Excluir
{
    public class ExcluiLivroRequest : IRequest<RetornoBase<ExcluiLivroResponse>>
    {
        public Guid Id { get; set; }
    }
}
