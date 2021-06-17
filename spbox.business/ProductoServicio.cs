using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using spbox.core.Models;
using spbox.data.Repos;
using spbox.data.Repos.Shared;
using spbox.core.Models.DTOs;
using AutoMapper;
using System.Linq;

namespace spbox.business
{
    public class ProductoServicio : Shared.IProductoServicio
    {
        private IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProductoServicio(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public IEnumerable<ProductoDTO> ListarProductos()
        {
            IEnumerable<ProductoDTO> productoDTOs = _mapper.ProjectTo<ProductoDTO>(_unitOfWork.Productos.GetAllQueryable());
            return productoDTOs;
        }
        
        public async Task<ProductoDTO> BuscarProducto(int id)
        {
            var producto = await _unitOfWork.Productos.GetProducto(id);
            return _mapper.Map<ProductoDTO>(producto);
        }

        public async Task<Producto> ModificarProducto(int id, ProductoDTO productodto)
        {
            var producto = await _unitOfWork.Productos.GetProducto(id);
            if (producto != null)
            {
                producto.nomProducto = productodto.nomProducto;
                producto.precioProducto = productodto.precioProducto;
                producto.descProducto = productodto.descProducto;

                _unitOfWork.Commit();

                return producto;
            }
            return null;
        }
    }
}
