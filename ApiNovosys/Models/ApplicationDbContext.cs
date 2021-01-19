using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace ApiNovosys
{
    public partial class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Producto> Productos { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Producto>(entity =>
            {
                entity.HasKey(e => e.CveProductoInt);

                entity.Property(e => e.CveProductoInt).HasColumnName("CVE_PRODUCTO_INT");

                entity.Property(e => e.AltImagenVar)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("ALT_IMAGEN_VAR");

                entity.Property(e => e.ClaseVar)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("CLASE_VAR");

                entity.Property(e => e.DescripcionLargaVar)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("DESCRIPCION_LARGA_VAR");

                entity.Property(e => e.EstatusInt).HasColumnName("ESTATUS_INT");

                entity.Property(e => e.MetaTagProdVar)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("META_TAG_PROD_VAR");

                entity.Property(e => e.NombreVar)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("NOMBRE_VAR");

                entity.Property(e => e.OrdenInt).HasColumnName("ORDEN_INT");

                entity.Property(e => e.RutaImagenVar)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("RUTA_IMAGEN_VAR");

                entity.Property(e => e.SubclaseVar)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("SUBCLASE_VAR");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
