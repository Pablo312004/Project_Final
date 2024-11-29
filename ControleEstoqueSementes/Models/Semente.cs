using System;

namespace ControleEstoqueSementes.Models
{
    public class Semente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Categoria { get; set; }
        public int Quantidade { get; set; }
        public decimal Preco { get; set; }
        public string Fornecedor { get; set; }
        public DateTime DataValidade { get; set; }
        public bool Excluida { get; set; }
    }
}
