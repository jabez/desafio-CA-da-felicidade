
using Desafio.Ca.Crud.Domain.Interfaces.Repositories;
using MediatR;

namespace Desafio.Ca.Crud.Application.Handlers.V1.Autores.Buscar
{
    public class BuscaAutorHandler : IRequestHandler<BuscaAutorRequest, BuscaAutorResponse>
    {
        private readonly IAutorRepository _autorRepository;
        public BuscaAutorHandler(IAutorRepository autorRepository) => _autorRepository = autorRepository;

        public async Task<BuscaAutorResponse> Handle(BuscaAutorRequest request, CancellationToken cancellationToken)
        {
            var autor = await _autorRepository.Obter(request.Id);
            if(autor == null)
            {
                return null;
            }


            return new BuscaAutorResponse()
            {
                Id = autor.Id,
                Nome= autor.Nome,
                Ativo= autor.Ativo,
                DataAtualizacao = autor.DataAtualizacao
            };
        }
    }
}
