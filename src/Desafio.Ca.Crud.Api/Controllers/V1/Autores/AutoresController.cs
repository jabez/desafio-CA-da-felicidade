using Desafio.Ca.Crud.Application.Handlers.V1.Autores.Adicionar;
using Desafio.Ca.Crud.Application.Handlers.V1.Autores.Alterar;
using Desafio.Ca.Crud.Application.Handlers.V1.Autores.Buscar;
using Desafio.Ca.Crud.Application.Handlers.V1.Autores.Excluir;
using Desafio.Ca.Crud.Application.Handlers.V1.Autores.Listar;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Desafio.Ca.Crud.Api.Controllers.V1.Autores
{

    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class AutoresController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AutoresController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [MapToApiVersion("1.0")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAll([FromQuery] ListaAutorRequest request)
        {
            var retorno = await _mediator.Send(request);
            return retorno.Autores.Any() ? Ok(retorno) : NotFound();
        }


        [HttpPost]
        [MapToApiVersion("1.0")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateProduct([FromBody] AdicionaAutorRequest adicionarAutorRequest)
        {
            var response = await _mediator.Send(adicionarAutorRequest);
            return Created("",response);
        }

        [HttpGet("{autorId:Guid}")]
        [MapToApiVersion("1.0")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(IEnumerable<BuscaAutorResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetById([FromRoute] Guid autorId)
        {
            var retorno =  await _mediator.Send(new BuscaAutorRequest() { Id = autorId });
            return retorno != null ? Ok(retorno) : NotFound();
        }

        [HttpPut("{autorId:Guid}")]
        [MapToApiVersion("1.0")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateAutorAsync(Guid autorId, [FromBody] AlteraAutorRequest alterarAutorRequest)
        {
            alterarAutorRequest.Id = autorId;

            var retorno = await _mediator.Send(alterarAutorRequest);

            if(!retorno.Sucesso && retorno.Codigo == 404)
            {
                return NotFound();
            }

            return Ok(retorno.Response);
        }
        
        [HttpDelete("{autorId:Guid}")]
        [MapToApiVersion("1.0")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteAsync(Guid autorId)
        {
            var retorno = await _mediator.Send(new ExcluiAutorRequest() { Id = autorId});
            if (!retorno.Sucesso && retorno.Codigo == 404)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
