using ControleEstoqueSementes.Models;
using ControleEstoqueSementes.Data;
using System.Collections.Generic;
using System.Linq;

namespace ControleEstoqueSementes.Services
{
    public class PedidoCompraService
    {
        private readonly JsonStorageService<PedidoCompra> _storageService;
        private readonly string _filePath = "pedidosCompra.json";
        private List<PedidoCompra> pedidos;

        public PedidoCompraService()
        {
            _storageService = new JsonStorageService<PedidoCompra>(_filePath);
            pedidos = _storageService.LoadData();
        }

        public void AdicionarPedidoCompra(PedidoCompra pedido)
        {
            pedido.Id = pedidos.Count + 1;
            pedidos.Add(pedido);
            _storageService.SaveData(pedidos);
        }

        public List<PedidoCompra> ListarPedidos()
        {
            return pedidos;
        }

        public void AprovarPedido(int id)
        {
            var pedido = pedidos.SingleOrDefault(p => p.Id == id);
            if (pedido != null)
            {
                pedido.Aprovado = true;
                _storageService.SaveData(pedidos);
            }
        }

        public void NegarPedido(int id)
        {
            var pedido = pedidos.SingleOrDefault(p => p.Id == id);
            if (pedido != null)
            {
                pedido.Negado = true;
                _storageService.SaveData(pedidos);
            }
        }
    }
}
