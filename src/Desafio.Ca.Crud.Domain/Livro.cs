namespace Desafio.Ca.Crud.Domain
{
    public class Livro
    {
        public Guid Id { get; set; }
        public List<Autor> Autores { get; set; }
        public List<Categoria> Categorias { get; set; }
        public Editora Editora { get; set; }
        public DateTime Lancamento { get; set; }
        public decimal Valor { get; set; }
        public string Edicao { get; set; }
        public string Sbn { get; set; }
    }
}
