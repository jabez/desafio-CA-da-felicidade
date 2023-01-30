namespace Desafio.Ca.Crud.Domain.Entidades
{
    public class Livro
    {
        public Livro(string categoria, string editora, DateTime lancamento, decimal valor, string edicao, string sbn, string titulo)
        {
            Id = Guid.NewGuid();
            Categoria = categoria;
            Editora = editora;
            Lancamento = lancamento;
            Valor = valor;
            Edicao = edicao;
            Sbn = sbn;
            Titulo = titulo;
            Ativo = true;
        }

        public Guid Id { get; set; }
        public List<Autor> Autores { get; set; }
        public string Categoria { get; set; }
        public string Editora { get; set; }
        public DateTime Lancamento { get; set; }
        public decimal Valor { get; set; }
        public string Edicao { get; set; }
        public string Sbn { get; set; }
        public string Titulo { get; set; }
        public bool Ativo { get; set; }
    }
}
