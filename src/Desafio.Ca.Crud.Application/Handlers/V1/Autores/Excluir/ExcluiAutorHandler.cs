using Desafio.Ca.Crud.Application.Models.Retornos;
using Desafio.Ca.Crud.Domain.Interfaces.Repositories;
using MediatR;

namespace Desafio.Ca.Crud.Application.Handlers.V1.Autores.Excluir
{
    public class ExcluiAutorHandler : IRequestHandler<ExcluiAutorRequest, RetornoBase<ExcluiAutorResponse>>
    {
        private readonly IAutorRepository _autorRepository;
        public ExcluiAutorHandler(IAutorRepository autorRepository) => _autorRepository = autorRepository;

        public async Task<RetornoBase<ExcluiAutorResponse>> Handle(ExcluiAutorRequest request, CancellationToken cancellationToken)
        {
            var autor = await _autorRepository.Obter(request.Id);
            if (autor == null)
            {
                var retorno = new RetornoBase<ExcluiAutorResponse>
                {
                    Codigo = 404
                };
                return retorno;
            };

            await _autorRepository.RemoverAsync(autor);

            return new RetornoBase<ExcluiAutorResponse>() { Sucesso = true };
        }
    }
}
