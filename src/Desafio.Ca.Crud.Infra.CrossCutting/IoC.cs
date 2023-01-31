using Desafio.Ca.Crud.Domain.Interfaces.Repositories;
using Desafio.Ca.Crud.Infra.DataBase.Repositories.Autores;
using Desafio.Ca.Crud.Infra.DataBase.Repositories.Livros;
using Microsoft.Extensions.DependencyInjection;

namespace Desafio.Ca.Crud.Infra.CrossCutting
{
    public static class IoC
    {
        public static void AddDependeciesInjections(this IServiceCollection Services)
        {
            //IoC
            Services.AddScoped<IAutorRepository, AutorRepository>();
            Services.AddScoped<ILivroRepository, LivroRepository>();
        }

    }
}