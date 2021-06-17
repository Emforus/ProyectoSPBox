using System;
using System.Collections.Generic;
using System.Text;

namespace spbox.data.Repos.Shared
{
    public interface IUnitOfWork
    {
        IProductoRepo Productos { get; }
        IPedidoRepo Pedidos { get; }
        IProductoPedidoRepo Uniones { get; }
        void Commit();
        void CommitAsync();
        void Rollback();
    }
}
