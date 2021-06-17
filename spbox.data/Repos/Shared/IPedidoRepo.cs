using System;
using System.Collections.Generic;
using System.Text;
using spbox.core.Models;
using System.Threading.Tasks;

namespace spbox.data.Repos.Shared
{
    public interface IPedidoRepo : IRepository<Pedido>
    {
        Task<Pedido> GetPedido(int id);
    }
}
