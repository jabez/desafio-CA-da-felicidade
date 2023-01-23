using Desafio.Ca.Crud.Domain.Entidades;
using Desafio.Ca.Crud.Domain.Interfaces.Repositories;
using MediatR;

namespace Desafio.Ca.Crud.Application.Handlers.V1.Autores.Adicionar
{
    public class AdicionaAutorHandler : IRequestHandler<AdicionaAutorRequest, AdicionaAutorResponse>
    {
        private readonly IAutorRepository _autorRepository;
        public AdicionaAutorHandler(IAutorRepository autorRepository) => _autorRepository = autorRepository;
        
        public async Task<AdicionaAutorResponse> Handle(AdicionaAutorRequest request, CancellationToken cancellationToken)
        {
            var autor = new Autor(nome: request.Nome);
            await _autorRepository.AdicionarAsync(autor);

            return new AdicionaAutorResponse
            {
                Id = autor.Id.ToString(),
                Nome = autor.Nome,
                Ativo = autor.Ativo,
            };
        }
    }
}
