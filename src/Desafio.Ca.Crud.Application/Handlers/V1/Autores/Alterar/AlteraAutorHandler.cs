using Desafio.Ca.Crud.Application.Models.Retornos;
using Desafio.Ca.Crud.Domain.Interfaces.Repositories;
using MediatR;

namespace Desafio.Ca.Crud.Application.Handlers.V1.Autores.Alterar
{
    public class AlteraAutorHandler : IRequestHandler<AlteraAutorRequest, RetornoBase<AlteraAutorResponse>>
    {
        private readonly IAutorRepository _autorRepository;
        public AlteraAutorHandler(IAutorRepository autorRepository) => _autorRepository = autorRepository;


        public async Task<RetornoBase<AlteraAutorResponse>> Handle(AlteraAutorRequest request, CancellationToken cancellationToken)
        {
            var autor = await _autorRepository.Obter(request.Id);
            if (autor == null)
            {
                var retorno = new RetornoBase<AlteraAutorResponse>
                {
                    Codigo = 404
                };
                return retorno;
            };

            autor.Nome = request.Nome;
            await _autorRepository.AtualizarAsync(autor);

            return new RetornoBase<AlteraAutorResponse>()
            {
                Sucesso = true,
                Response = new AlteraAutorResponse
                {
                    Id = autor.Id.ToString(),
                    Nome = autor.Nome,
                    Ativo = autor.Ativo,
                }
            };
        }

    }
}
