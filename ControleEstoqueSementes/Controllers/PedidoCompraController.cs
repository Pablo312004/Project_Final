using ControleEstoqueSementes.Services;
using ControleEstoqueSementes.Models;
using System;
using System.Collections.Generic;

namespace ControleEstoqueSementes.Controllers
{
    public class PedidoCompraController
    {
        private PedidoCompraService pedidoCompraService = new PedidoCompraService();

        public void FazerPedidoCompra(int usuarioId)
        {
            var pedido = new PedidoCompra { UsuarioId = usuarioId, Sementes = new List<Semente>() };
            Console.WriteLine("Informe os IDs das sementes para o pedido de compra (digite '0' para finalizar):");
            int id;
            do
            {
                id = Convert.ToInt32(Console.ReadLine());
                if (id != 0)
                {
                    var semente = new Semente { Id = id };
                    pedido.Sementes.Add(semente);
                }
            } while (id != 0);

            Console.WriteLine("Processando pedido...");
            pedidoCompraService.AdicionarPedidoCompra(pedido);
            Console.WriteLine("Pedido de compra realizado com sucesso!");
        }

        public List<PedidoCompra> ListarPedidos()
        {
            return pedidoCompraService.ListarPedidos();
        }

        public void AprovarPedido(int id)
        {
            pedidoCompraService.AprovarPedido(id);
        }

        public void NegarPedido(int id)
        {
            pedidoCompraService.NegarPedido(id);
        }

        public List<PedidoCompra> ListarPedidos(int usuarioId)
        {
            return pedidoCompraService.ListarPedidos().FindAll(p => p.UsuarioId == usuarioId);
        }
    }
}
