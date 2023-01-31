using Desafio.Ca.Crud.Domain.Entidades;

namespace Desafio.Ca.Crud.Domain.Interfaces.Repositories
{
    public interface ILivroRepository
    {
        Task<Livro> AdicionarAsync(Livro livro);
        Task<List<Livro>> ObterTodosAsync();
        Task RemoverAsync(Livro livro);
        Task<Livro> AtualizarAsync(Livro livro);
        Task<Livro> PatchAsync(Livro livro);
        Task<List<Livro>> ObterTodosPaginadoAsync(int pageSize, int pageNumber);
        Task<Livro> Obter(Guid id);
    }
}
