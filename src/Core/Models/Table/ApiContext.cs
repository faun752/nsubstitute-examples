using Core.EfModels;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Core.Models.Table
{
    public partial class ApiContext : DbContext
    {
        public ApiContext()
        {
        }

        public ApiContext(DbContextOptions<ApiContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<CustomerStaff> CustomerStaffs { get; set; }
        public virtual DbSet<Shop> Shops { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Japanese_CI_AS");

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("Customer");

                entity.Property(e => e.CustomerCode)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Gender).HasMaxLength(50);

                entity.Property(e => e.ShopCode).HasMaxLength(50);
            });

            modelBuilder.Entity<CustomerStaff>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("CustomerStaff");

                entity.HasIndex(e => new { e.CustomerCode, e.ShopCode }, "UQ__Customer__7126B9D20721C6F7")
                    .IsUnique();

                entity.Property(e => e.CustomerCode)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.CustomerStaffId).ValueGeneratedOnAdd();

                entity.Property(e => e.ShopCode).HasMaxLength(50);

                entity.Property(e => e.StaffName).IsRequired();

                entity.HasOne(d => d.ShopCodeNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.ShopCode)
                    .HasConstraintName("FK_CustomerStaff_ShopCode");
            });

            modelBuilder.Entity<Shop>(entity =>
            {
                entity.HasKey(e => e.ShopCode)
                    .HasName("PK__Shop__7413CF369A74B918");

                entity.ToTable("Shop");

                entity.Property(e => e.ShopCode).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
