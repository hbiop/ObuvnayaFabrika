using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace ObuvnayaFabrika.Model
{
    public partial class ObuvnajaFabrikaEntity : DbContext
    {
        public ObuvnajaFabrikaEntity()
            : base("name=ObuvnajaFabrikaEntity")
        {
        }

        public virtual DbSet<Authorizacia> Authorizacia { get; set; }
        public virtual DbSet<Brigadi> Brigadi { get; set; }
        public virtual DbSet<Ceh> Ceh { get; set; }
        public virtual DbSet<CehPartia> CehPartia { get; set; }
        public virtual DbSet<Clienti> Clienti { get; set; }
        public virtual DbSet<Cvet> Cvet { get; set; }
        public virtual DbSet<Etapi> Etapi { get; set; }
        public virtual DbSet<Gorod> Gorod { get; set; }
        public virtual DbSet<Kategorii> Kategorii { get; set; }
        public virtual DbSet<Materiali> Materiali { get; set; }
        public virtual DbSet<MaterialNakladnaya> MaterialNakladnaya { get; set; }
        public virtual DbSet<MaterialNaSklade> MaterialNaSklade { get; set; }
        public virtual DbSet<Nakladnaya> Nakladnaya { get; set; }
        public virtual DbSet<Otzivi> Otzivi { get; set; }
        public virtual DbSet<Partia> Partia { get; set; }
        public virtual DbSet<Postavshiki> Postavshiki { get; set; }
        public virtual DbSet<Prodaji> Prodaji { get; set; }
        public virtual DbSet<Sklad> Sklad { get; set; }
        public virtual DbSet<Sotrudniki> Sotrudniki { get; set; }
        public virtual DbSet<Status> Status { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<Tovar> Tovar { get; set; }
        public virtual DbSet<TovarMaterial> TovarMaterial { get; set; }
        public virtual DbSet<TovarNaSklade> TovarNaSklade { get; set; }
        public virtual DbSet<TovarRazmer> TovarRazmer { get; set; }
        public virtual DbSet<Ulici> Ulici { get; set; }
        public virtual DbSet<Zakaz> Zakaz { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Brigadi>()
                .HasMany(e => e.Sotrudniki)
                .WithRequired(e => e.Brigadi)
                .HasForeignKey(e => e.Brigada)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Ceh>()
                .HasMany(e => e.Brigadi)
                .WithRequired(e => e.Ceh1)
                .HasForeignKey(e => e.Ceh)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Ceh>()
                .HasMany(e => e.CehPartia)
                .WithRequired(e => e.Ceh1)
                .HasForeignKey(e => e.Ceh)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Clienti>()
                .HasMany(e => e.Otzivi)
                .WithRequired(e => e.Clienti)
                .HasForeignKey(e => e.Magazine)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Clienti>()
                .HasMany(e => e.Zakaz)
                .WithRequired(e => e.Clienti)
                .HasForeignKey(e => e.Zakazchik)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Cvet>()
                .HasMany(e => e.Tovar)
                .WithRequired(e => e.Cvet1)
                .HasForeignKey(e => e.Cvet)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Etapi>()
                .HasMany(e => e.CehPartia)
                .WithRequired(e => e.Etapi)
                .HasForeignKey(e => e.Etap)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Gorod>()
                .HasMany(e => e.Ulici)
                .WithRequired(e => e.Gorod1)
                .HasForeignKey(e => e.Gorod)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Kategorii>()
                .Property(e => e.Naimenovanie)
                .IsFixedLength();

            modelBuilder.Entity<Kategorii>()
                .HasMany(e => e.Tovar)
                .WithRequired(e => e.Kategorii)
                .HasForeignKey(e => e.Kategoria)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Materiali>()
                .HasMany(e => e.MaterialNakladnaya)
                .WithRequired(e => e.Materiali)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Materiali>()
                .HasMany(e => e.MaterialNaSklade)
                .WithRequired(e => e.Materiali)
                .HasForeignKey(e => e.Material)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Materiali>()
                .HasMany(e => e.TovarMaterial)
                .WithRequired(e => e.Materiali)
                .HasForeignKey(e => e.Material)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Nakladnaya>()
                .HasMany(e => e.MaterialNakladnaya)
                .WithRequired(e => e.Nakladnaya)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Partia>()
                .HasMany(e => e.TovarNaSklade)
                .WithRequired(e => e.Partia1)
                .HasForeignKey(e => e.Partia)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Postavshiki>()
                .HasMany(e => e.Nakladnaya)
                .WithRequired(e => e.Postavshiki)
                .HasForeignKey(e => e.KodPostavshiaka)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Sklad>()
                .HasMany(e => e.MaterialNaSklade)
                .WithRequired(e => e.Sklad1)
                .HasForeignKey(e => e.Sklad)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Sklad>()
                .HasMany(e => e.TovarNaSklade)
                .WithRequired(e => e.Sklad1)
                .HasForeignKey(e => e.Sklad)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Sotrudniki>()
                .HasMany(e => e.Authorizacia)
                .WithRequired(e => e.Sotrudniki)
                .HasForeignKey(e => e.Sotrudnik)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Sotrudniki>()
                .HasMany(e => e.Nakladnaya)
                .WithRequired(e => e.Sotrudniki)
                .HasForeignKey(e => e.KodSotrudnikaPrinivshego)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Status>()
                .HasMany(e => e.CehPartia)
                .WithRequired(e => e.Status1)
                .HasForeignKey(e => e.Status)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Status>()
                .HasMany(e => e.Zakaz)
                .WithRequired(e => e.Status)
                .HasForeignKey(e => e.StatusZakaza)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Tovar>()
                .Property(e => e.CenaTovara)
                .IsFixedLength();

            modelBuilder.Entity<Tovar>()
                .HasMany(e => e.CehPartia)
                .WithRequired(e => e.Tovar)
                .HasForeignKey(e => e.Partia)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Tovar>()
                .HasMany(e => e.Partia)
                .WithRequired(e => e.Tovar1)
                .HasForeignKey(e => e.Tovar)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Tovar>()
                .HasMany(e => e.TovarMaterial)
                .WithRequired(e => e.Tovar1)
                .HasForeignKey(e => e.Tovar)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Tovar>()
                .HasMany(e => e.TovarRazmer)
                .WithRequired(e => e.Tovar1)
                .HasForeignKey(e => e.Tovar)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Ulici>()
                .HasMany(e => e.Clienti)
                .WithRequired(e => e.Ulici)
                .HasForeignKey(e => e.Ulica)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Ulici>()
                .HasMany(e => e.Postavshiki)
                .WithRequired(e => e.Ulici)
                .HasForeignKey(e => e.Ulica)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Ulici>()
                .HasMany(e => e.Sklad)
                .WithRequired(e => e.Ulici)
                .HasForeignKey(e => e.Ulica)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Zakaz>()
                .HasMany(e => e.Prodaji)
                .WithRequired(e => e.Zakaz1)
                .HasForeignKey(e => e.Zakaz)
                .WillCascadeOnDelete(false);
        }
    }
}
