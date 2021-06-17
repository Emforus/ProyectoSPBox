using Microsoft.EntityFrameworkCore;
using spbox.core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace spbox.data
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<DetallePedido> DetallePedidos { get; set; }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Proveedor> Proveedores { get; set; }
        public DbSet<Comprador> Compradores { get; set; }
        public DbSet<ProductoPedido> ProductoPedidos { get; set; }

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }

        /*protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseMySql(
            "server=localhost;user=root;port=3306;Connect Timeout=5;",
            new MySqlServerVersion(new Version(8, 0, 25)),
                    o => o.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery));
        }*/

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Entidades a tablas  
            modelBuilder.Entity<Pedido>().ToTable("Pedidos");
            modelBuilder.Entity<DetallePedido>().ToTable("DetallePedidos");
            modelBuilder.Entity<Producto>().ToTable("Productos");
            modelBuilder.Entity<Proveedor>().ToTable("Proveedores");
            modelBuilder.Entity<Comprador>().ToTable("Compradores");

            // Configuracion de llaves primarias  
            modelBuilder.Entity<Pedido>().HasKey(pe => pe.IDPedido).HasName("PK_Pedidos");
            modelBuilder.Entity<DetallePedido>().HasKey(dp => dp.IDDetalle).HasName("PK_DetallePedidos");
            modelBuilder.Entity<Producto>().HasKey(pr => pr.IDProducto).HasName("PK_Productos");
            modelBuilder.Entity<Proveedor>().HasKey(p => p.IDProveedor).HasName("PK_Proveedores");
            modelBuilder.Entity<Comprador>().HasKey(c => c.IDComprador).HasName("PK_Compradores");

            // Configuracion de columnas  
            modelBuilder.Entity<Pedido>().Property(pe => pe.IDPedido).HasColumnType("int").UseMySqlIdentityColumn().IsRequired();
            modelBuilder.Entity<Pedido>().Property(pe => pe.fechaPedido).HasColumnType("datetime").IsRequired();

            modelBuilder.Entity<DetallePedido>().Property(dp => dp.IDDetalle).HasColumnType("int").UseMySqlIdentityColumn().IsRequired();
            modelBuilder.Entity<DetallePedido>().Property(dp => dp.notasDetalle).HasColumnType("nvarchar(200)").IsRequired(false);

            modelBuilder.Entity<Producto>().Property(pr => pr.IDProducto).HasColumnType("int").UseMySqlIdentityColumn().IsRequired();
            modelBuilder.Entity<Producto>().Property(pr => pr.nomProducto).HasColumnType("nvarchar(40)").IsRequired();
            modelBuilder.Entity<Producto>().Property(pr => pr.precioProducto).HasColumnType("int").IsRequired();
            modelBuilder.Entity<Producto>().Property(pr => pr.descProducto).HasColumnType("nvarchar(200)").IsRequired(false);

            modelBuilder.Entity<Proveedor>().Property(p => p.IDProveedor).HasColumnType("int").UseMySqlIdentityColumn().IsRequired();
            modelBuilder.Entity<Proveedor>().Property(p => p.nomProveedor).HasColumnType("nvarchar(40)").IsRequired();
            modelBuilder.Entity<Proveedor>().Property(p => p.dirProveedor).HasColumnType("nvarchar(40)").IsRequired();
            modelBuilder.Entity<Proveedor>().Property(p => p.cuidadProveedor).HasColumnType("nvarchar(40)").IsRequired();
            modelBuilder.Entity<Proveedor>().Property(p => p.paisProveedor).HasColumnType("nvarchar(40)").IsRequired();
            modelBuilder.Entity<Proveedor>().Property(p => p.paisProveedor).HasColumnType("nvarchar(40)").IsRequired();

            modelBuilder.Entity<Comprador>().Property(p => p.IDComprador).HasColumnType("int").UseMySqlIdentityColumn().IsRequired();
            modelBuilder.Entity<Comprador>().Property(p => p.nomComprador).HasColumnType("nvarchar(40)").IsRequired();
            modelBuilder.Entity<Comprador>().Property(p => p.dirComprador).HasColumnType("nvarchar(40)").IsRequired();
            modelBuilder.Entity<Comprador>().Property(p => p.cuidadComprador).HasColumnType("nvarchar(40)").IsRequired();
            modelBuilder.Entity<Comprador>().Property(p => p.paisComprador).HasColumnType("nvarchar(40)").IsRequired();
            modelBuilder.Entity<Comprador>().Property(p => p.paisComprador).HasColumnType("nvarchar(40)").IsRequired();

            // Configuracion de relaciones  
            modelBuilder.Entity<DetallePedido>().HasOne<Pedido>().WithOne(x => x.DetallePedido).HasForeignKey<Pedido>(p => p.FKDetalle);
            //modelBuilder.Entity<Comprador>().HasMany<DetallePedido>().WithOne(dp => dp.Comprador).HasForeignKey(dp => dp.IDComprador);
            //modelBuilder.Entity<Comprador>().Navigation(c => c.Detalles).UsePropertyAccessMode(PropertyAccessMode.Property);
            //modelBuilder.Entity<DetallePedido>().HasOne<Proveedor>().WithMany().HasPrincipalKey(c => c.IDProveedor).HasForeignKey(dp => dp.IDProveedor);
            modelBuilder.Entity<Pedido>().HasMany(p => p.Productos).WithMany(p => p.Pedidos).UsingEntity<ProductoPedido>(
                x => x.HasOne(pp => pp.Producto).WithMany(p => p.ProductosPorPedido).HasForeignKey(pp => pp.IDProducto),
                x => x.HasOne(pp => pp.Pedido).WithMany(p => p.ProductosPorPedido).HasForeignKey(pp => pp.IDPedido),
                x =>
                {
                    x.Property(pp => pp.cantidadProducto).HasDefaultValue(0);
                    x.HasKey(pp => new { pp.IDPedido, pp.IDProducto });
                });
            //modelBuilder.Entity<ProductoPedido>().HasKey(pp => new { pp.IDProducto, pp.IDPedido });
            //modelBuilder.Entity<ProductoPedido>().HasOne(pp => pp.Pedido).WithMany(pe => pe.ProductoPedidos).HasForeignKey(pp => pp.IDPedido);
            //modelBuilder.Entity<ProductoPedido>().HasOne(pp => pp.Producto).WithMany(pr => pr.ProductoPedidos).HasForeignKey(pp => pp.IDProducto);
        }
    }
}
