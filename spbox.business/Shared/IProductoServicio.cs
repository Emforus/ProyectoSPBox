using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using spbox.core.Models;
using spbox.core.Models.DTOs;

namespace spbox.business.Shared
{
    public interface IProductoServicio
    {
        IEnumerable<ProductoDTO> ListarProductos();
        Task<ProductoDTO> BuscarProducto(int id);
        Task<Producto> ModificarProducto(int id, ProductoDTO productodto);
    }
}
