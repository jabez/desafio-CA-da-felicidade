using Desafio.Ca.Crud.Domain.Entidades;
using Desafio.Ca.Crud.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Desafio.Ca.Crud.Infra.DataBase.Repositories.Livros
{
    public class LivroRepository : ILivroRepository
    {
        public readonly BibliotecaContext _bibliotecaContext;

        public LivroRepository(BibliotecaContext bibliotecaContext) => _bibliotecaContext = bibliotecaContext;

        public async Task<Livro> AdicionarAsync(Livro livro)
        {
            await _bibliotecaContext.Livros.AddAsync(livro);
            await _bibliotecaContext.SaveChangesAsync();

            return livro;
        }

        public async Task<List<Livro>> ObterTodosAsync()
        {
            return await _bibliotecaContext.Livros?.AsNoTracking().ToListAsync();
        }
        public async Task<Livro> Obter(Guid id)
        {
            var item = await _bibliotecaContext.Livros?.FirstOrDefaultAsync(p => p.Id == id)!;
            return item;
        }

        public async Task RemoverAsync(Livro livro)
        {
            _bibliotecaContext.Remove(livro);
            await _bibliotecaContext.SaveChangesAsync();
        }

        public async Task<Livro> AtualizarAsync(Livro livro)
        {
            _bibliotecaContext.Entry(livro).State = EntityState.Modified;
            await _bibliotecaContext.SaveChangesAsync();

            return livro;
        }

        public async Task<Livro> PatchAsync(Livro livro)
        {
            _bibliotecaContext.Livros.Update(livro);
            await _bibliotecaContext.SaveChangesAsync();

            return livro;
        }
    }
}
