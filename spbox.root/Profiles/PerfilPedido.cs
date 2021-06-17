using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using System.Linq;
using spbox.core.Models;
using spbox.core.Models.DTOs;

namespace spbox.root.Profiles
{
    public class PerfilPedido : Profile
    {
        public PerfilPedido()
        {
            CreateMap<Pedido, PedidoDTO>()
                .ForMember(obj => obj.DetallePedido, obj => obj.MapFrom(src => src.DetallePedido));
        }
    }
}
