using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using spbox.core.Models;
using spbox.data.Repos.Shared;
using Microsoft.EntityFrameworkCore;


namespace spbox.data.Repos
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DatabaseContext _context;
        private IProductoRepo _productoRepo;
        private IPedidoRepo _pedidoRepo;
        private IProductoPedidoRepo _unionRepo;
        public UnitOfWork(DatabaseContext context)
        {
            _context = context;
        }

        public IProductoRepo Productos
        {
            get { return _productoRepo = _productoRepo ?? new ProductoRepo(_context); }
        }

        public IPedidoRepo Pedidos
        {
            get { return _pedidoRepo = _pedidoRepo ?? new PedidoRepo(_context); }
        }

        public IProductoPedidoRepo Uniones
        {
            get { return _unionRepo = _unionRepo ?? new ProductoPedidoRepo(_context); }
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public async void CommitAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Rollback()
        {
            _context.Dispose();
        }
    }
}
