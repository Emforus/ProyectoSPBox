using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using spbox.core.Models;
using spbox.business.Shared;
using spbox.core.Models.DTOs;

namespace spbox.api.Controllers
{
    [Route("api/productos")]
    [ApiController]
    public class ProductosController : ControllerBase
    {
        private IProductoServicio productoServicio;

        public ProductosController(IProductoServicio productoServicio)
        {
            this.productoServicio = productoServicio;
        }

        [HttpGet]
        public IEnumerable<ProductoDTO> ListarProductos()
        {
            return productoServicio.ListarProductos();
        }

        [HttpGet("{id:int}")]
        public Task<ProductoDTO> GetProducto(int id)
        {
            return productoServicio.BuscarProducto(id);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<Producto>> UpdateProducto(int id, [FromForm] ProductoDTO producto)
        {
            try
            {
                var prod = await productoServicio.BuscarProducto(id);
                if (prod == null)
                {
                    return NotFound($"Producto con ID {id} no encontrado");
                }
                return await productoServicio.ModificarProducto(id, producto);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error actualizando informacion");
            }
        }
    }
}
