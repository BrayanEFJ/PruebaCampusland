using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace PruebaBrayanFigueroa.Models;

public partial class PruebaBfContext : DbContext
{
    public PruebaBfContext()
    {
    }

    public PruebaBfContext(DbContextOptions<PruebaBfContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<Pedido> Pedidos { get; set; }

    public virtual DbSet<PedidoProducto> PedidoProductos { get; set; }

    public virtual DbSet<Producto> Productos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-SCDL4EU\\SQLEXPRESS;Initial Catalog=PruebaBF;Integrated Security=True;Trust Server Certificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Clientes__3213E83F9C0D8837");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Pedido>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Pedidos__3213E83F5C27CC48");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.FechaPedido).HasColumnType("datetime");
            entity.Property(e => e.Total).HasColumnType("decimal(18, 0)");

            entity.HasOne(d => d.Client).WithMany(p => p.Pedidos)
                .HasForeignKey(d => d.ClientId)
                .HasConstraintName("FK__Pedidos__Total__52593CB8");
        });

        modelBuilder.Entity<PedidoProducto>(entity =>
        {
            entity.HasNoKey();

            entity.HasOne(d => d.Pedido).WithMany()
                .HasForeignKey(d => d.PedidoId)
                .HasConstraintName("FK__PedidoPro__Pedid__5441852A");

            entity.HasOne(d => d.Producto).WithMany()
                .HasForeignKey(d => d.ProductoId)
                .HasConstraintName("FK__PedidoPro__Produ__5535A963");
        });

        modelBuilder.Entity<Producto>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Producto__3213E83F50C49A2A");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Precio).HasColumnType("decimal(18, 0)");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
