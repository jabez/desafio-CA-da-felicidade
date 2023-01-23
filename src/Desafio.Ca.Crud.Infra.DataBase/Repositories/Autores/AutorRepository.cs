using Desafio.Ca.Crud.Domain.Entidades;
using Desafio.Ca.Crud.Domain.Interfaces.Repositories;

namespace Desafio.Ca.Crud.Infra.DataBase.Repositories.Autores
{
    public class AutorRepository : IAutorRepository
    {
        public readonly BibliotecaContext _bibliotecaContext;

        public AutorRepository(BibliotecaContext bibliotecaContext) => _bibliotecaContext = bibliotecaContext;
        
        public async Task<Autor> AdicionarAutorAsync(Autor autor)
        {
            await _bibliotecaContext.Autores.AddAsync(autor);
            await _bibliotecaContext.SaveChangesAsync();

            return autor;
        }
    }
}
