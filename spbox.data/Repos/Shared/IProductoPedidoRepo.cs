using System;
using System.Collections.Generic;
using System.Text;
using spbox.core.Models;
using System.Threading.Tasks;

namespace spbox.data.Repos.Shared
{
    public interface IProductoPedidoRepo : IRepository<ProductoPedido>
    {
        Task<ProductoPedido> GetUnion(int pedido, int producto);
    }
}
