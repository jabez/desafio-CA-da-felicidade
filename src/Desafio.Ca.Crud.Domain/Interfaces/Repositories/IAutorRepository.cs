using Desafio.Ca.Crud.Domain.Entidades;
using System.Linq.Expressions;

namespace Desafio.Ca.Crud.Domain.Interfaces.Repositories
{
    public interface IAutorRepository
    {
        Task<Autor> AdicionarAsync(Autor autor);
        Task<List<Autor>> ObterTodosAsync();
        Task RemoverAsync(Autor autor);
        Task<Autor> AtualizarAsync(Autor autor);
        Task<Autor> PatchAsync(Autor autor);
        Task<Autor> Obter(Guid id);
        Task<List<Autor>> ObterTodosPaginadoAsync(int pageSize, int pageNumber);
        Task<IEnumerable<Autor>> Where(Expression<Func<Autor, bool>> predicate);
    }
}
