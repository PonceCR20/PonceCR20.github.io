using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;

namespace PatrimonioInventario.Models.Data
{
    public class EntityPatrimonioDB : DbContext
    {
        public DbSet<Altas> Altas { get; set; }
        public DbSet<Secretarias> Secretarias { get; set; }

        public DbSet<Areas> Areas { get; set; }

        public DbSet<Estados> Estados { get; set; }

        public DbSet<Inventarios> Inventarios { get; set; }

        public DbSet<Inmuebles> Inmuebles { get; set; }

        public DbSet<Inventario> Inventario { get; set; }

        public DbSet<Ubicacion> Ubicacion { get; set; }

        public EntityPatrimonioDB()
            : base("name=EntityPatrimonioDB")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            #region Areas

            modelBuilder.Entity<Areas>()
                .Property(x => x.TipoArea)
                .HasMaxLength(300)
                .IsRequired();

            #endregion

            #region Secretarias

            modelBuilder.Entity<Secretarias>()
                .Property(x => x.TipoSecretaria)
                .HasMaxLength(100)
                .IsRequired();

            #endregion

            #region Altas

            modelBuilder.Entity<Altas>()
                .Property(x => x.TipoAlta)
                .HasMaxLength(50)
                .IsRequired();

            #endregion

            #region Estados

            modelBuilder.Entity<Estados>()
                .Property(x => x.TipoEstado)
                .HasMaxLength(50)
                .IsRequired();

            #endregion

            #region Inventarios

            modelBuilder.Entity<Inventarios>()
               .Property(x => x.Ubicacion)
               .HasMaxLength(4000)
               .IsRequired();

            modelBuilder.Entity<Inventarios>()
               .Property(x => x.Imagen)
               .HasMaxLength(4000);

            modelBuilder.Entity<Inventarios>()
               .Property(x => x.Clave)
               .HasMaxLength(50)
               .IsRequired();

            modelBuilder.Entity<Inventarios>()
               .Property(x => x.Marca)
               .HasMaxLength(100)
               .IsRequired();

            modelBuilder.Entity<Inventarios>()
               .Property(x => x.Modelo)
               .HasMaxLength(50)
               .IsRequired();

            modelBuilder.Entity<Inventarios>()
               .Property(x => x.Serie)
               .HasMaxLength(50)
               .IsRequired();

            modelBuilder.Entity<Inventarios>()
               .Property(x => x.Descripcion)
               .HasMaxLength(1000)
               .IsRequired();

            #endregion

            #region Inmuebles

            modelBuilder.Entity<Inmuebles>()
               .Property(x => x.Colonia)
               .HasMaxLength(4000);

            modelBuilder.Entity<Inmuebles>()
               .Property(x => x.Ubicacion)
               .HasMaxLength(4000);

            modelBuilder.Entity<Inmuebles>()
               .Property(x => x.SuperficieTotal)
               .HasMaxLength(4000);

            modelBuilder.Entity<Inmuebles>()
               .Property(x => x.Destinado)
               .HasMaxLength(4000);

            modelBuilder.Entity<Inmuebles>()
               .Property(x => x.EstadoActualPredio)
               .HasMaxLength(4000);

            modelBuilder.Entity<Inmuebles>()
               .Property(x => x.Permuta)
               .HasMaxLength(4000);

            modelBuilder.Entity<Inmuebles>()
               .Property(x => x.Actas)
               .HasMaxLength(4000);

            modelBuilder.Entity<Inmuebles>()
               .Property(x => x.DonadaPermutaCons)
               .HasMaxLength(4000);

            modelBuilder.Entity<Inmuebles>()
               .Property(x => x.AreaDisponible)
               .HasMaxLength(4000);

            modelBuilder.Entity<Inmuebles>()
               .Property(x => x.Finca)
               .HasMaxLength(4000);

            modelBuilder.Entity<Inmuebles>()
               .Property(x => x.Escritura)
               .HasMaxLength(4000);

            modelBuilder.Entity<Inmuebles>()
               .Property(x => x.ValorCatastral)
               .HasMaxLength(4000);

            modelBuilder.Entity<Inmuebles>()
               .Property(x => x.Total)
               .HasMaxLength(4000);

            modelBuilder.Entity<Inmuebles>()
               .Property(x => x.TotalC_Donacion_Permuta)
               .HasMaxLength(4000);

            modelBuilder.Entity<Inmuebles>()
               .Property(x => x.ClaveCatastral)
               .HasMaxLength(4000);

            #endregion

            #region Inventario

            modelBuilder.Entity<Inventario>()
                .Property(x => x.NoControl)
                .HasMaxLength(4000);

            modelBuilder.Entity<Inventario>()
                .Property(x => x.Descripcion)
                .HasMaxLength(4000);

            modelBuilder.Entity<Inventario>()
                .Property(x => x.Marca)
                .HasMaxLength(4000);

            modelBuilder.Entity<Inventario>()
                .Property(x => x.Modelo)
                .HasMaxLength(4000);

            modelBuilder.Entity<Inventario>()
                .Property(x => x.Serie)
                .HasMaxLength(4000);

            modelBuilder.Entity<Inventario>()
                .Property(x => x.Resguardante)
                .HasMaxLength(4000);

            modelBuilder.Entity<Inventario>()
                .Property(x => x.Color)
                .HasMaxLength(4000);

            modelBuilder.Entity<Inventario>()
                .Property(x => x.Placas)
                .HasMaxLength(4000);

            modelBuilder.Entity<Inventario>()
                .Property(x => x.Observaciones)
                .HasMaxLength(4000);

            #endregion

            #region Ubicacion

            modelBuilder.Entity<Ubicacion>()
                .Property(x => x.NombreUbicacion)
                .HasMaxLength(4000);

            #endregion
        }
    }

}