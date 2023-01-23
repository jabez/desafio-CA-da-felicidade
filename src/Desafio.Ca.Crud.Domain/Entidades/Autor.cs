namespace Desafio.Ca.Crud.Domain.Entidades
{
    public class Autor
    {
        public Autor(string nome)
        {
            Id = Guid.NewGuid();
            Nome = nome;
            Ativo = true;
            DataAtualizacao = DateTime.Now;
        }

        public Autor()
        {

        }

        public Guid Id { get; set; }
        public string Nome { get; set; }
        public bool Ativo { get; private set; }
        public DateTime DataAtualizacao { get; private set; }
        public List<Livro> Livros { get; set; }
    }
}
