using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using spbox.core.Models;
using spbox.data.Repos;
using spbox.data.Repos.Shared;
using spbox.core.Models.DTOs;
using AutoMapper;

namespace spbox.business
{
    public class UnionServicio : Shared.IUnionServicio
    {
        private IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UnionServicio(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<ProductoPedidoDTO> BuscarUnion(int pedido, int producto)
        {
            var union = await _unitOfWork.Uniones.GetUnion(pedido, producto);
            return _mapper.Map<ProductoPedidoDTO>(union);
        }

        public async Task<ProductoPedido> RemoverUnion(ProductoPedidoDTO uniondto)
        {
            var union = await _unitOfWork.Uniones.GetUnion(uniondto.IDPedido, uniondto.IDProducto);
            if (union != null)
            {
                _unitOfWork.Uniones.Delete(union);
                _unitOfWork.Commit();
                return union;
            }
            return null;
        }

    }
}
