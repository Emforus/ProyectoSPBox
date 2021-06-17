using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using spbox.core.Models;
using spbox.core.Models.DTOs;

namespace spbox.root.Profiles
{
    public class PerfilDetalle : Profile
    {
        public PerfilDetalle()
        {
            CreateMap<DetallePedido, DetallePedidoDTO>();
        }
    }
}
