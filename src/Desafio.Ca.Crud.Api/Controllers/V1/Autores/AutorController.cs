using Desafio.Ca.Crud.Application.Handlers.V1.Autores.Adicionar;
using Desafio.Ca.Crud.Application.Handlers.V1.Autores.Buscar;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Desafio.Ca.Crud.Api.Controllers.V1.Autores
{

    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class AutorController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AutorController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [MapToApiVersion("1.0")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAll()
        {
            var retorno = new List<dynamic>() { new { teste = "1" } };

            return retorno.Any() ? Ok(retorno) : NotFound();
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
    }
}
