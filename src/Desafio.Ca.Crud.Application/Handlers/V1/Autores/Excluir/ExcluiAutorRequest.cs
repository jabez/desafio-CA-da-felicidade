using Desafio.Ca.Crud.Application.Models.Retornos;
using MediatR;

namespace Desafio.Ca.Crud.Application.Handlers.V1.Autores.Excluir
{
    public class ExcluiAutorRequest : IRequest<RetornoBase<ExcluiAutorResponse>>
    {
        public Guid Id { get; set; }
    }
}
