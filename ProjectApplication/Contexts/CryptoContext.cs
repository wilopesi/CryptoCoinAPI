using Microsoft.EntityFrameworkCore;
using ProjectApplication.Contexts.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectApplication.Contexts
{
    public partial class CryptoContext : DbContext
    {

        public CryptoContext()
        {
        }

        public CryptoContext(DbContextOptions<CryptoContext> options)
            : base(options)
        {
        }

        public DbSet<Coin> Coins { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(!optionsBuilder.IsConfigured)
            {
                throw new NotImplementedException();
            }
        }
        
        protected  override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Coin>(entity =>
            {
                entity.ToTable("Coin", "guest");

                entity.Property(e => e.Id).HasColumnName("Id");

                entity.Property(e => e.Name).HasColumnName("Name");

                entity.Property(e => e.Symbol).HasColumnName("Symbol");

                entity.Property(e => e.Market_Cap).HasColumnName("Market_Cap");

                entity.Property(e => e.Current_Price).HasColumnName("Current_Price");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);



    }
}
