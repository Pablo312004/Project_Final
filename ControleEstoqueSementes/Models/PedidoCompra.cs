using System.Collections.Generic;

namespace ControleEstoqueSementes.Models
{
    public class PedidoCompra
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public List<Semente> Sementes { get; set; }
        public bool Aprovado { get; set; }
        public bool Negado { get; set; }
    }
}
