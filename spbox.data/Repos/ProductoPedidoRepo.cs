using System;
using System.Collections.Generic;
using System.Text;
using spbox.core.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace spbox.data.Repos
{
    public class ProductoPedidoRepo : Repository<ProductoPedido>, Shared.IProductoPedidoRepo
    {
        public ProductoPedidoRepo(DatabaseContext context) : base(context) { }
        public Task<ProductoPedido> GetUnion(int pedido, int producto)
        {
            return _context.Set<ProductoPedido>().FirstOrDefaultAsync(x => x.IDPedido == pedido && x.IDProducto == producto); ;
        }
    }
}
