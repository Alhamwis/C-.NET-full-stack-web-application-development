using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace association.Models
{
    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }
 
        public virtual DbSet<Adherent> Adherents { get; set; }
        public virtual DbSet<association> associations { get; set; }
        public virtual DbSet<description> descriptions { get; set; }
        public virtual DbSet<organisateur> organisateurs { get; set; }
        public virtual DbSet<role> roles { get; set; }
        public virtual DbSet<ville> villes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Adherent>()
                .Property(e => e.sexe)
                .IsUnicode(false);

            modelBuilder.Entity<Adherent>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Adherent>()
                .Property(e => e.paid)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Adherent>()
                .Property(e => e.Paye)
                .IsUnicode(false);

            modelBuilder.Entity<Adherent>()
                .HasMany(e => e.associations)
                .WithOptional(e => e.Adherent)
                .HasForeignKey(e => e.code_adherent);

           

            modelBuilder.Entity<organisateur>()
                .Property(e => e.key_CHEF)
                .IsUnicode(false);

            modelBuilder.Entity<organisateur>()
                .Property(e => e.key_Treasurer)
                .IsUnicode(false);

            modelBuilder.Entity<organisateur>()
                .Property(e => e.key_Redacteur)
                .IsUnicode(false);

            modelBuilder.Entity<role>()
                .HasMany(e => e.Adherents)
                .WithRequired(e => e.role1)
                .HasForeignKey(e => e.role)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ville>()
                .HasMany(e => e.Adherents)
                .WithRequired(e => e.ville)
                .HasForeignKey(e => e.Villes)
                .WillCascadeOnDelete(false);
        }
    }
}
