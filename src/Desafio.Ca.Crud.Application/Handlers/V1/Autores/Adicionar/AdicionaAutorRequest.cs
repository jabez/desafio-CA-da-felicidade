using MediatR;

namespace Desafio.Ca.Crud.Application.Handlers.V1.Autores.Adicionar
{
    public class AdicionaAutorRequest : IRequest<AdicionaAutorResponse>
    {
        public string Nome { get; set; }
        public bool Ativo { get; set; }
    }
}
