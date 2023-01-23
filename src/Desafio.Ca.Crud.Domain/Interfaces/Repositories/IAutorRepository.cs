using Desafio.Ca.Crud.Domain.Entidades;

namespace Desafio.Ca.Crud.Domain.Interfaces.Repositories
{
    public interface IAutorRepository
    {
        Task<Autor> AdicionarAutorAsync(Autor autor);
    }
}
