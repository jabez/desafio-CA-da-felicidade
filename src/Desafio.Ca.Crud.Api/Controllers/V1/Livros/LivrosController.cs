using Desafio.Ca.Crud.Application.Handlers.V1.Autores.Excluir;
using Desafio.Ca.Crud.Application.Handlers.V1.Livros.Adicionar;
using Desafio.Ca.Crud.Application.Handlers.V1.Livros.Alterar;
using Desafio.Ca.Crud.Application.Handlers.V1.Livros.Excluir;
using Desafio.Ca.Crud.Application.Handlers.V1.Livros.Listar;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Desafio.Ca.Crud.Api.Controllers.V1.Livros
{

    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class LivrosController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LivrosController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [MapToApiVersion("1.0")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAll([FromQuery] ListaLivroRequest request)
        {
            var retorno = await _mediator.Send(request);
            return retorno.Livros.Any() ? Ok(retorno) : NotFound();
        }


        [HttpPost]
        [MapToApiVersion("1.0")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Create([FromBody] AdicionaLivroRequest adicionarlivroRequest)
        {
            var response = await _mediator.Send(adicionarlivroRequest);
            return Created("",response);
        }

        [HttpPut("{livroId:Guid}")]
        [MapToApiVersion("1.0")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdatelivroAsync(Guid livroId, [FromBody] AlteraLivroRequest alterarLivroRequest)
        {
            alterarLivroRequest.Id = livroId;

            var retorno = await _mediator.Send(alterarLivroRequest);

            if(!retorno.Sucesso && retorno.Codigo == 404)
            {
                return NotFound();
            }

            return Ok(retorno.Response);
        }
        
        [HttpDelete("{livroId:Guid}")]
        [MapToApiVersion("1.0")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteAsync(Guid livroId)
        {
            var retorno = await _mediator.Send(new ExcluiLivroRequest() { Id = livroId });
            if (!retorno.Sucesso && retorno.Codigo == 404)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
