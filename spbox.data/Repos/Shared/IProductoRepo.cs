using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using spbox.core.Models;

namespace spbox.data.Repos.Shared
{
    public interface IProductoRepo : IRepository<Producto>
    {
        Task<Producto> GetProducto(int id);
    }
}
