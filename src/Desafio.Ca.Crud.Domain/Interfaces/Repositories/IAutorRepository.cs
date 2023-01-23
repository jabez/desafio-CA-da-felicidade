using Desafio.Ca.Crud.Domain.Entidades;

namespace Desafio.Ca.Crud.Domain.Interfaces.Repositories
{
    public interface IAutorRepository
    {
        Task<Autor> AdicionarAsync(Autor autor);
        Task<List<Autor>> ObterTodosAsync();
        Task RemoverAsync(Autor autor);
        Task<Autor> AtualizarAsync(Autor autor);
        Task<Autor> PatchAsync(Autor autor);
    }
}
