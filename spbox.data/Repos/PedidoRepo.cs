using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Linq.Expressions;
using spbox.core.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace spbox.data.Repos
{
    public class PedidoRepo : Repository<Pedido>, Shared.IPedidoRepo
    {
        public PedidoRepo(DatabaseContext context) : base(context) { }
        public Task<Pedido> GetPedido(int id)
        {
            return _context.Set<Pedido>().Where(ped => ped.IDPedido == id).AsQueryable().FirstOrDefaultAsync();
        }
    }
}
