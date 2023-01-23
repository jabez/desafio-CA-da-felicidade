using Desafio.Ca.Crud.Domain.Entidades;
using Desafio.Ca.Crud.Domain.Interfaces.Repositories;
using MediatR;

namespace Desafio.Ca.Crud.Application.Handlers.V1.Autores.Adicionar
{
    public class AdicionarAutorHandler : IRequestHandler<AdicionarAutorRequest, AdicionarAutorResponse>
    {
        private readonly IAutorRepository _autorRepository;
        public AdicionarAutorHandler(IAutorRepository autorRepository) => _autorRepository = autorRepository;
        
        public async Task<AdicionarAutorResponse> Handle(AdicionarAutorRequest request, CancellationToken cancellationToken)
        {
            var autor = new Autor(nome: request.Nome);
            await _autorRepository.AdicionarAutorAsync(autor);

            return new AdicionarAutorResponse
            {
                Id = autor.Id.ToString(),
                Nome = autor.Nome,
                Ativo = autor.Ativo,
            };
        }
    }
}
