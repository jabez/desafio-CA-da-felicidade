using Desafio.Ca.Crud.Application.Handlers.V1.Autores.Buscar;
using Desafio.Ca.Crud.Domain.Entidades;
using Desafio.Ca.Crud.Domain.Interfaces.Repositories;
using FluentAssertions;
using Moq;
using Xunit;

namespace Desafio.Ca.Crud.Application.Test.Handlers.V1.Autores.Buscar
{
    public class BuscaAutorHandlerTest
    {
        [Fact]
        public async Task Handler_QuandoAutorIdForEncontrado_DeveRetornarAutorDesejado()
        {
            //arrange
            var guid = Guid.NewGuid();
            var autorRepositoryMock = new Mock<IAutorRepository>();
            autorRepositoryMock.Setup(x => x.Obter(It.IsAny<Guid>())).ReturnsAsync(new Autor() { Id = guid, Nome = "Joao da silva" });
            var request = new BuscaAutorRequest() { Id = guid };
            var handler = new BuscaAutorHandler(autorRepositoryMock.Object);

            //act
            var result = await handler.Handle(request, new CancellationToken());

            // assert
            result.Nome.Should().Be("Joao da silva");
        }
    }
}
