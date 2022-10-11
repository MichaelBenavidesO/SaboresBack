using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Sabores_Backend.Models
{
    public partial class SABORESContext : DbContext
    {
        public SABORESContext()
        {
        }

        public SABORESContext(DbContextOptions<SABORESContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Preguntum> Pregunta { get; set; } = null!;
        public virtual DbSet<Producto> Productos { get; set; } = null!;
        public virtual DbSet<ProductoReserva> ProductoReservas { get; set; } = null!;
        public virtual DbSet<ProductoVentum> ProductoVenta { get; set; } = null!;
        public virtual DbSet<Reserva> Reservas { get; set; } = null!;
        public virtual DbSet<Sede> Sedes { get; set; } = null!;
        public virtual DbSet<Usuario> Usuarios { get; set; } = null!;
        public virtual DbSet<Ventum> Venta { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=MICHAEL-BENAVID\\SQLEXPRESS; Database=SABORES; Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Preguntum>(entity =>
            {
                entity.HasKey(e => e.IdPregunta)
                    .HasName("PK__Pregunta__623EEC4280495D91");

                entity.Property(e => e.IdPregunta).HasColumnName("idPregunta");

                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

                entity.Property(e => e.Pregunta)
                    .HasMaxLength(95)
                    .IsUnicode(false)
                    .HasColumnName("pregunta");

                entity.Property(e => e.Respuesta)
                    .HasMaxLength(95)
                    .IsUnicode(false)
                    .HasColumnName("respuesta");

              
            });

            modelBuilder.Entity<Producto>(entity =>
            {
                entity.HasKey(e => e.IdProducto)
                    .HasName("PK__Producto__07F4A1326367E3F4");

                entity.ToTable("Producto");

                entity.Property(e => e.IdProducto).HasColumnName("idProducto");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(95)
                    .IsUnicode(false)
                    .HasColumnName("descripcion");

                entity.Property(e => e.Estado).HasColumnName("estado");

                entity.Property(e => e.Imagen)
                    .HasMaxLength(512)
                    .IsUnicode(false)
                    .HasColumnName("imagen");

                entity.Property(e => e.NombreProducto)
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasColumnName("nombre_producto");

                entity.Property(e => e.Precio).HasColumnName("precio");
            });

            modelBuilder.Entity<ProductoReserva>(entity =>
            {
                entity.HasKey(e => e.IdProductoReserva)
                    .HasName("PK__Producto__8530B205EC8578D4");

                entity.ToTable("Producto_Reserva");

                entity.Property(e => e.IdProductoReserva).HasColumnName("idProductoReserva");

                entity.Property(e => e.Cantidad).HasColumnName("cantidad");

                entity.Property(e => e.IdProducto).HasColumnName("idProducto");

                entity.Property(e => e.IdReserva).HasColumnName("idReserva");

                entity.Property(e => e.Nota)
                    .HasMaxLength(95)
                    .IsUnicode(false)
                    .HasColumnName("nota");

               

               
            });

            modelBuilder.Entity<ProductoVentum>(entity =>
            {
                entity.HasKey(e => e.IdProductoVenta)
                    .HasName("PK__Producto__5062143EC01F5337");

                entity.ToTable("Producto_Venta");

                entity.Property(e => e.IdProductoVenta).HasColumnName("idProductoVenta");

                entity.Property(e => e.Cantidad).HasColumnName("cantidad");

                entity.Property(e => e.Fecha)
                    .HasColumnType("date")
                    .HasColumnName("fecha");

                entity.Property(e => e.IdProducto).HasColumnName("idProducto");

                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

                entity.Property(e => e.Valor).HasColumnName("valor");

               

           
            });

            modelBuilder.Entity<Reserva>(entity =>
            {
                entity.HasKey(e => e.IdReserva)
                    .HasName("PK__Reserva__94D104C85371AD37");

                entity.ToTable("Reserva");

                entity.Property(e => e.IdReserva).HasColumnName("idReserva");

                entity.Property(e => e.Activo).HasColumnName("activo");

                entity.Property(e => e.Evento)
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasColumnName("evento");

                entity.Property(e => e.FechaReserva)
                    .HasColumnType("date")
                    .HasColumnName("fechaReserva");

                entity.Property(e => e.Hora)
                    .HasColumnType("time(0)")
                    .HasColumnName("hora");

                entity.Property(e => e.IdSede).HasColumnName("idSede");

                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");


             
            });

            modelBuilder.Entity<Sede>(entity =>
            {
                entity.HasKey(e => e.IdSede)
                    .HasName("PK__Sede__C5AF63D0724366BB");

                entity.ToTable("Sede");

                entity.Property(e => e.IdSede).HasColumnName("idSede");

                entity.Property(e => e.Activo).HasColumnName("activo");

                entity.Property(e => e.Direccion)
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasColumnName("direccion");

                entity.Property(e => e.NombreSede)
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasColumnName("nombre_sede");

                entity.Property(e => e.Parqueaderos).HasColumnName("parqueaderos");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario)
                    .HasName("PK__Usuario__645723A624EAB5A1");

                entity.ToTable("Usuario");

                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

                entity.Property(e => e.Apellido)
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasColumnName("apellido");

                entity.Property(e => e.ContraseÃA)
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasColumnName("contraseÃ±a");

                entity.Property(e => e.CorreoElectronico)
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasColumnName("correo_electronico");

                entity.Property(e => e.DocumentoIdentidad)
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasColumnName("documento_identidad");

                entity.Property(e => e.Imagen)
                    .HasMaxLength(512)
                    .IsUnicode(false)
                    .HasColumnName("imagen");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasColumnName("nombre");

                entity.Property(e => e.OlvidarContrasena)
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasColumnName("olvidar_contrasena");

                entity.Property(e => e.Rol)
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasColumnName("rol");
            });

            modelBuilder.Entity<Ventum>(entity =>
            {
                entity.HasKey(e => e.IdVenta);

                entity.Property(e => e.IdVenta).HasColumnName("idVenta");

                entity.Property(e => e.IdProducto).HasColumnName("idProducto");

                entity.Property(e => e.IdProductoVenta).HasColumnName("idProductoVenta");


                entity.HasOne(d => d.IdProductoVentaNavigation)
                    .WithMany(p => p.Venta)
                    .HasForeignKey(d => d.IdProductoVenta)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Venta__idProduct__440B1D61");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
