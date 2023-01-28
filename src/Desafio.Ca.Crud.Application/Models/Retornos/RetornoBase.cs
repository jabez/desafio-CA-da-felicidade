
namespace Desafio.Ca.Crud.Application.Models.Retornos
{
    public class RetornoBase<T>
    {
        public bool Sucesso { get; set; }
        public int Codigo { get; set; }
        public string Mensagem { get; set; }
        public T Response { get; set; }
    }
}
