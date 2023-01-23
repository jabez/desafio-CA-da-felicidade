namespace Desafio.Ca.Crud.Application.Handlers.V1.Autores.Buscar
{
    public class BuscaAutorResponse
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public bool Ativo { get; set; }
        public DateTime DataAtualizacao { get; set; }
    }
}
