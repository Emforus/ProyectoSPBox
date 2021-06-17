using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using System.Linq.Expressions;
using spbox.core.Models;
using spbox.data.Repos;
using spbox.data.Repos.Shared;
using spbox.core.Models.DTOs;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MySqlConnector;

namespace spbox.business
{
    public class PedidoServicio : Shared.IPedidoServicio
    {
        private IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PedidoServicio(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public IEnumerable<PedidoDTO> ListarPedidos()
        {
            IEnumerable<PedidoDTO> pedidoDTOs = _mapper.ProjectTo<PedidoDTO>(_unitOfWork.Pedidos.GetAllQueryable());
            return pedidoDTOs;
        }

        public IQueryable<PedidoDTO> BuscarPedido(int id)
        {
            var ped = _unitOfWork.Pedidos.Query(x => x.IDPedido == id).ProjectTo<PedidoDTO>(_mapper.ConfigurationProvider);
            return ped;
        }

        public void CrearPedido(Pedido pedido)
        {
            _unitOfWork.Pedidos.Add(pedido);
            _unitOfWork.Commit();
            return;
        }

        public void RemoverPedido(Pedido pedido)
        {
            _unitOfWork.Pedidos.Delete(pedido);
            _unitOfWork.Commit();
            return;
        }
    }
}
