using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using System.Linq;
using spbox.core.Models;
using Microsoft.EntityFrameworkCore;

namespace spbox.data.Repos
{
    public class ProductoRepo : Repository<Producto>, Shared.IProductoRepo
    {
        public ProductoRepo(DatabaseContext context) : base(context) { }
        public Task<Producto> GetProducto(int id)
        {
            return _context.Set<Producto>().FirstOrDefaultAsync(prod => prod.IDProducto == id);
        }
    }
}
