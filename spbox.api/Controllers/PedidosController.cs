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
    [Route("api/pedidos")]
    [ApiController]
    public class PedidosController : ControllerBase
    {
        private IPedidoServicio pedidoServicio;
        private IUnionServicio unionServicio;

        public PedidosController(IPedidoServicio pedidoServicio, IUnionServicio unionServicio)
        {
            this.pedidoServicio = pedidoServicio;
            this.unionServicio = unionServicio;
        }

        [HttpGet]
        public IEnumerable<PedidoDTO> ListarPedidos()
        {
            return pedidoServicio.ListarPedidos();
        }

        [HttpGet("{id}")]
        public PedidoDTO GetPedidos(int id)
        {
            return pedidoServicio.BuscarPedido(id).FirstOrDefault();
        }

        [HttpPost]
        public void AddPedido([FromBody] Pedido pedido)
        {
            pedidoServicio.CrearPedido(pedido);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ProductoPedido>> RemoveProducto(int id, [FromQuery] int producto)
        {
            try
            {
                var union = await unionServicio.BuscarUnion(id, producto);

                if (union == null)
                {
                    return NotFound($"Pedido con ID {id} no encontrado");
                }

                return await unionServicio.RemoverUnion(union);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error eliminando informacion");
            }
        }
    }
}
