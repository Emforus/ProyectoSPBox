using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using spbox.core.Models;
using spbox.core.Models.DTOs;

namespace spbox.business.Shared
{
    public interface IUnionServicio
    {
        Task<ProductoPedidoDTO> BuscarUnion(int pedido, int producto);
        Task<ProductoPedido> RemoverUnion(ProductoPedidoDTO union);
    }
}
