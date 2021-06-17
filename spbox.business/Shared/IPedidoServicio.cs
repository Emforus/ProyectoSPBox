using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using spbox.core.Models;
using spbox.core.Models.DTOs;

namespace spbox.business.Shared
{
    public interface IPedidoServicio
    {
        IEnumerable<PedidoDTO> ListarPedidos();
        IQueryable<PedidoDTO> BuscarPedido(int id);
        void CrearPedido(Pedido pedido);
        void RemoverPedido(Pedido pedido);
    }
}
