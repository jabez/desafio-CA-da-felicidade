using Desafio.Ca.Crud.Domain.Entidades;
using Desafio.Ca.Crud.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Desafio.Ca.Crud.Infra.DataBase.Repositories.Autores
{
    public class AutorRepository : IAutorRepository
    {
        public readonly BibliotecaContext _bibliotecaContext;

        public AutorRepository(BibliotecaContext bibliotecaContext) => _bibliotecaContext = bibliotecaContext;
        
        public async Task<Autor> AdicionarAsync(Autor autor)
        {
            await _bibliotecaContext.Autores.AddAsync(autor);
            await _bibliotecaContext.SaveChangesAsync();

            return autor;
        }

        public async Task<List<Autor>> ObterTodosAsync()
        {
            return await _bibliotecaContext.Autores?.AsNoTracking().ToListAsync();
        }

        public async Task<List<Autor>> ObterTodosPaginadoAsync(int pageSize, int pageNumber)
        {
            return await _bibliotecaContext.Autores ?
                         .Include(x => x.Livros)
                         .AsNoTracking()
                         .Skip((pageNumber - 1) * pageSize)
                         .Take(pageSize)
                         .ToListAsync();
        }

        public async Task<Autor> Obter(Guid id)
        {
            var item = await _bibliotecaContext.Autores?.FirstOrDefaultAsync(p => p.Id == id)!;
            return item;
        }

        public async Task RemoverAsync(Autor autor)
        {
            _bibliotecaContext.Remove(autor);
            await _bibliotecaContext.SaveChangesAsync();
        }

        public async Task<Autor> AtualizarAsync(Autor autor)
        {
            _bibliotecaContext.Entry(autor).State = EntityState.Modified;
            await _bibliotecaContext.SaveChangesAsync();

            return autor;
        }

        public async Task<Autor> PatchAsync(Autor autor)
        {
            _bibliotecaContext.Autores.Update(autor);
            await _bibliotecaContext.SaveChangesAsync();

            return autor;
        }

        public async Task<IEnumerable<Autor>> Where(Expression<Func<Autor, bool>> predicate)
        {
            return await _bibliotecaContext.Autores.Where(predicate).ToListAsync();
        }
    }
}
