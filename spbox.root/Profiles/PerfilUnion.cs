using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using spbox.core.Models;
using spbox.core.Models.DTOs;

namespace spbox.root.Profiles
{
    public class PerfilUnion : Profile
    {
        public PerfilUnion()
        {
            CreateMap<ProductoPedido, ProductoPedidoDTO>().ForMember(
                x => x.totalProducto, y => y.MapFrom(z => z.cantidadProducto*z.Producto.precioProducto));
        }
    }
}
