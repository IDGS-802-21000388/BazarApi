using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace BazarUniversal.Models;

public partial class BazarUniversalContext : DbContext
{
    public BazarUniversalContext()
    {
    }

    public BazarUniversalContext(DbContextOptions<BazarUniversalContext> options)
        : base(options)
    {
    }

    public virtual DbSet<ImagenesProducto> ImagenesProductos { get; set; }

    public virtual DbSet<Producto> Productos { get; set; }

    public virtual DbSet<Venta> Ventas { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Server=tcp:bazar-universal.database.windows.net,1433;Initial Catalog=BazarUniversal;Persist Security Info=False;User ID=jmorales;Password=BazarUniversal10;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ImagenesProducto>(entity =>
        {
            entity.HasKey(e => e.Idimagen).HasName("PK__Imagenes__462D392081212296");

            entity.ToTable("ImagenesProducto");

            entity.Property(e => e.Idimagen).HasColumnName("IDImagen");
            entity.Property(e => e.Idproducto).HasColumnName("IDProducto");
            entity.Property(e => e.ImagenUrl).HasMaxLength(255);

            entity.HasOne(d => d.IdproductoNavigation).WithMany(p => p.ImagenesProductos)
                .HasForeignKey(d => d.Idproducto)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__ImagenesP__IDPro__398D8EEE");
        });

        modelBuilder.Entity<Producto>(entity =>
        {
            entity.HasKey(e => e.Idproducto).HasName("PK__Producto__ABDAF2B46DA1E37B");

            entity.ToTable("Producto");

            entity.Property(e => e.Idproducto)
                .ValueGeneratedNever()
                .HasColumnName("IDProducto");
            entity.Property(e => e.Categoria).HasMaxLength(100);
            entity.Property(e => e.Clasificacion).HasColumnType("decimal(3, 2)");
            entity.Property(e => e.Descuento).HasColumnType("decimal(5, 2)");
            entity.Property(e => e.Fondo).HasMaxLength(255);
            entity.Property(e => e.Marca).HasMaxLength(100);
            entity.Property(e => e.Precio).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Titulo).HasMaxLength(255);
        });

        modelBuilder.Entity<Venta>(entity =>
        {
            entity.HasKey(e => e.Idventa).HasName("PK__Ventas__27134B82BD2F1A4E");

            entity.Property(e => e.Idventa).HasColumnName("IDVenta");
            entity.Property(e => e.FechaVenta).HasColumnType("datetime");
            entity.Property(e => e.Idproducto).HasColumnName("IDProducto");

            entity.HasOne(d => d.IdproductoNavigation).WithMany(p => p.Venta)
                .HasForeignKey(d => d.Idproducto)
                .HasConstraintName("FK_Ventas_Producto");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
