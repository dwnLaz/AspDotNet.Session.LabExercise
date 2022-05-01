using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using ToyData.Models;
using System.Collections.Generic;


#nullable disable

namespace ToyData.Data
{
    public partial class ToyUniverseContext : DbContext
    {
        public ToyUniverseContext()
        {
        }

        public ToyUniverseContext(DbContextOptions<ToyUniverseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Applicant> Applicants { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderDetail> OrderDetails { get; set; }
        public virtual DbSet<PickOfMonth> PickOfMonths { get; set; }
        public virtual DbSet<Recipient> Recipients { get; set; }
        public virtual DbSet<Shipment> Shipments { get; set; }
        public virtual DbSet<ShippingMode> ShippingModes { get; set; }
        public virtual DbSet<ShippingRate> ShippingRates { get; set; }
        public virtual DbSet<Shopper> Shoppers { get; set; }
        public virtual DbSet<ShoppingCart> ShoppingCarts { get; set; }
        public virtual DbSet<Toy> Toys { get; set; }
        public virtual DbSet<ToyBrand> ToyBrands { get; set; }
        public virtual DbSet<VwOrderWrapper> VwOrderWrappers { get; set; }
        public virtual DbSet<Wrapper> Wrappers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=3LMBQG3;Database=ToyUniverse;User Id=sa;Password=edwin9598");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Applicant>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.FirstName).IsUnicode(false);

                entity.Property(e => e.LastName).IsUnicode(false);
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasKey(e => e.CCategoryId)
                    .HasName("ct_pk");

                entity.Property(e => e.CCategoryId)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.CCategory)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.VDescription).IsUnicode(false);
            });

            modelBuilder.Entity<Country>(entity =>
            {
                entity.HasKey(e => e.CCountryId)
                    .HasName("c_pk");

                entity.Property(e => e.CCountryId)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.CCountry)
                    .IsUnicode(false)
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasKey(e => e.COrderNo)
                    .HasName("CO_PK");

                entity.Property(e => e.COrderNo)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.CCartId)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.COrderProcessed)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.CShippingModeId)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.CShopperId)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.HasOne(d => d.CShippingMode)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.CShippingModeId)
                    .HasConstraintName("FK__Orders__cShippin__3D5E1FD2");

                entity.HasOne(d => d.CShopper)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.CShopperId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Orders__cShopper__3C69FB99");
            });

            modelBuilder.Entity<OrderDetail>(entity =>
            {
                entity.HasKey(e => new { e.COrderNo, e.CToyId })
                    .HasName("z_key");

                entity.Property(e => e.COrderNo)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.CToyId)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.CGiftWrap)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.CWrapperId)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.VMessage).IsUnicode(false);

                entity.HasOne(d => d.COrderNoNavigation)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.COrderNo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__OrderDeta__cOrde__403A8C7D");

                entity.HasOne(d => d.CToy)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.CToyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__OrderDeta__cToyI__412EB0B6");

                entity.HasOne(d => d.CWrapper)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.CWrapperId)
                    .HasConstraintName("FK__OrderDeta__cWrap__4222D4EF");
            });

            modelBuilder.Entity<PickOfMonth>(entity =>
            {
                entity.HasKey(e => new { e.CToyId, e.SiMonth, e.IYear })
                    .HasName("POM_PK");

                entity.Property(e => e.CToyId)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.HasOne(d => d.CToy)
                    .WithMany(p => p.PickOfMonths)
                    .HasForeignKey(d => d.CToyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PickOfMon__cToyI__4CA06362");
            });

            modelBuilder.Entity<Recipient>(entity =>
            {
                entity.HasKey(e => e.COrderNo)
                    .HasName("RCP_PK");

                entity.Property(e => e.COrderNo)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.CCity)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.CCountryId)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.CPhone)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.CState)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.CZipCode)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.VAddress).IsUnicode(false);

                entity.Property(e => e.VFirstName).IsUnicode(false);

                entity.Property(e => e.VLastName).IsUnicode(false);

                entity.HasOne(d => d.CCountry)
                    .WithMany(p => p.Recipients)
                    .HasForeignKey(d => d.CCountryId)
                    .HasConstraintName("FK__Recipient__cCoun__48CFD27E");

                entity.HasOne(d => d.COrderNoNavigation)
                    .WithOne(p => p.Recipient)
                    .HasForeignKey<Recipient>(d => d.COrderNo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Recipient__cOrde__47DBAE45");
            });

            modelBuilder.Entity<Shipment>(entity =>
            {
                entity.HasKey(e => e.COrderNo)
                    .HasName("SHP_PK");

                entity.Property(e => e.COrderNo)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.CDeliveryStatus)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.HasOne(d => d.COrderNoNavigation)
                    .WithOne(p => p.Shipment)
                    .HasForeignKey<Shipment>(d => d.COrderNo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Shipment__cOrder__44FF419A");
            });

            modelBuilder.Entity<ShippingMode>(entity =>
            {
                entity.HasKey(e => e.CModeId)
                    .HasName("spm_pk");

                entity.Property(e => e.CModeId)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.CMode)
                    .IsUnicode(false)
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<ShippingRate>(entity =>
            {
                entity.HasKey(e => new { e.CCountryId, e.CModeId })
                    .HasName("SR_PRK");

                entity.Property(e => e.CCountryId)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.CModeId)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.HasOne(d => d.CCountry)
                    .WithMany(p => p.ShippingRates)
                    .HasForeignKey(d => d.CCountryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ShippingR__cCoun__2E1BDC42");

                entity.HasOne(d => d.CMode)
                    .WithMany(p => p.ShippingRates)
                    .HasForeignKey(d => d.CModeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ShippingR__cMode__2F10007B");
            });

            modelBuilder.Entity<Shopper>(entity =>
            {
                entity.HasKey(e => e.CShopperId)
                    .HasName("s_id");

                entity.Property(e => e.CShopperId)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.CCity)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.CCountryId)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.CCreditCardNo)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.CPassword)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.CPhone)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.CState)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.CZipCode)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.VAddress).IsUnicode(false);

                entity.Property(e => e.VCreditCardType).IsUnicode(false);

                entity.Property(e => e.VEmailId).IsUnicode(false);

                entity.Property(e => e.VFirstName).IsUnicode(false);

                entity.Property(e => e.VLastName).IsUnicode(false);

                entity.HasOne(d => d.CCountry)
                    .WithMany(p => p.Shoppers)
                    .HasForeignKey(d => d.CCountryId)
                    .HasConstraintName("FK__Shopper__cCountr__31EC6D26");
            });

            modelBuilder.Entity<ShoppingCart>(entity =>
            {
                entity.HasKey(e => new { e.CCartId, e.CToyId })
                    .HasName("SCHP_PK");

                entity.Property(e => e.CCartId)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.CToyId)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.HasOne(d => d.CToy)
                    .WithMany(p => p.ShoppingCarts)
                    .HasForeignKey(d => d.CToyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ShoppingC__cToyI__398D8EEE");
            });

            modelBuilder.Entity<Toy>(entity =>
            {
                entity.HasKey(e => e.CToyId)
                    .HasName("t_id");

                entity.Property(e => e.CToyId)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.CBrandId)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.CCategoryId)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.VToyDescription).IsUnicode(false);

                entity.Property(e => e.VToyImgPath).IsUnicode(false);

                entity.Property(e => e.VToyName).IsUnicode(false);

                entity.HasOne(d => d.CBrand)
                    .WithMany(p => p.Toys)
                    .HasForeignKey(d => d.CBrandId)
                    .HasConstraintName("FK__Toys__cBrandId__36B12243");

                entity.HasOne(d => d.CCategory)
                    .WithMany(p => p.Toys)
                    .HasForeignKey(d => d.CCategoryId)
                    .HasConstraintName("FK__Toys__cCategoryI__35BCFE0A");
            });

            modelBuilder.Entity<ToyBrand>(entity =>
            {
                entity.HasKey(e => e.CBrandId)
                    .HasName("TB_pk");

                entity.Property(e => e.CBrandId)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.CBrandName)
                    .IsUnicode(false)
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<VwOrderWrapper>(entity =>
            {
                entity.ToView("vwOrderWrapper");

                entity.Property(e => e.COrderNo)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.CToyId)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.VDescription).IsUnicode(false);
            });

            modelBuilder.Entity<Wrapper>(entity =>
            {
                entity.HasKey(e => e.CWrapperId)
                    .HasName("w_id");

                entity.Property(e => e.CWrapperId)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.VDescription).IsUnicode(false);

                entity.Property(e => e.VWrapperImgPath).IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
