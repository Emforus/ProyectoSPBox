using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using spbox.data;
using spbox.business;
using spbox.business.Shared;
using spbox.data.Repos;
using spbox.data.Repos.Shared;
using spbox.core.Models;
using spbox.core.Models.DTOs;
using spbox.root.Profiles;
using AutoMapper;

namespace spbox.root
{
    public class CompositionRoot
    {
        public CompositionRoot()
        {
        }

        public static void injectDependencies(IServiceCollection services)
        {
            string DatabaseConnectionStr = "server=localhost; port=3306; database=spbox; user=root; password=205321896; Connect Timeout=300";
            services.AddDbContextPool<DatabaseContext>(options => options.UseMySql(DatabaseConnectionStr, ServerVersion.AutoDetect(DatabaseConnectionStr)));
            services.AddAutoMapper(typeof(PerfilProducto), typeof(PerfilPedido), typeof(PerfilDetalle), typeof(PerfilComprador), typeof(PerfilProveedor), typeof(PerfilUnion));
            services.AddScoped<DatabaseContext>();
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IProductoRepo, ProductoRepo>();
            services.AddScoped<IProductoServicio, ProductoServicio>();
            services.AddScoped<IPedidoRepo, PedidoRepo>();
            services.AddScoped<IPedidoServicio, PedidoServicio>();
            services.AddScoped<IProductoPedidoRepo, ProductoPedidoRepo>();
            services.AddScoped<IUnionServicio, UnionServicio>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}
