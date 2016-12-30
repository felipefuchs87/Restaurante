using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using BuildRest.Modelo;

namespace BuildRest.Entity
{
    public class BuildRestContexto : DbContext
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            var mapRestaurante = modelBuilder.Entity<Restaurante>();
            mapRestaurante.Property(x => x.RestauranteId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            mapRestaurante.Property(x => x.RestauranteNome)
                             .IsRequired();
            mapRestaurante.HasKey(x => x.RestauranteId);
            mapRestaurante.HasMany(x => x.Pratos);

            mapRestaurante.ToTable("Restaurante");

            var mapPrato = modelBuilder.Entity<Prato>();
            mapPrato.Property(x => x.PratoId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            mapPrato.Property(x => x.PratoNome)
                             .IsRequired();
            mapPrato.Property(x => x.RestauranteId)
                .IsRequired();

            mapPrato.HasKey(x => x.PratoId);
            mapPrato.ToTable("Prato");

        }

        public DbSet<Restaurante> Empresas { get; set; }
        public DbSet<Prato> Pratos { get; set; }
    }
}
