using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Digital.Data.Models
{
    public partial class ElectronicDbContext : DbContext
    {
        public ElectronicDbContext()
        {
        }

        public ElectronicDbContext(DbContextOptions<ElectronicDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cart> Cart { get; set; }
        public virtual DbSet<Categories> Categories { get; set; }
        public virtual DbSet<OrderDetails> OrderDetails { get; set; }
        public virtual DbSet<Orders> Orders { get; set; }
        public virtual DbSet<Payments> Payments { get; set; }
        public virtual DbSet<Person> Person { get; set; }
        public virtual DbSet<Products> Products { get; set; }
        public virtual DbSet<Reviews> Reviews { get; set; }
        public virtual DbSet<Roles> Roles { get; set; }
        public virtual DbSet<Subcategories> Subcategories { get; set; }
        public virtual DbSet<UserRole> UserRole { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:DefaultSchema", "Electronic");

            modelBuilder.Entity<Cart>(entity =>
            {
                entity.ToTable("Cart", "dbo");

                entity.Property(e => e.CreadtedOn).HasColumnType("datetime");

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Cart)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK__ShoppingC__Produ__4AB81AF0");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Cart)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__ShoppingC__UserI__49C3F6B7");
            });

            modelBuilder.Entity<Categories>(entity =>
            {
                entity.HasKey(e => e.CategoryId)
                    .HasName("PK__Categori__19093A0BB761CFE4");

                entity.ToTable("Categories", "dbo");

                entity.Property(e => e.CategoryDecription)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.CategoryTitle)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CreadtedOn).HasColumnType("datetime");

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");
            });

            modelBuilder.Entity<OrderDetails>(entity =>
            {
                entity.HasKey(e => e.OrderDetailId)
                    .HasName("PK__OrderDet__3C5A40802EB7C826");

                entity.Property(e => e.OrderDetailId).HasColumnName("order_detail_id");

                entity.Property(e => e.OrderId).HasColumnName("order_id");

                entity.Property(e => e.Price)
                    .HasColumnName("price")
                    .HasColumnType("decimal(10, 2)");

                entity.Property(e => e.ProductId).HasColumnName("product_id");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.OrderId)
                    .HasConstraintName("FK__OrderDeta__order__693CA210");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK__OrderDeta__produ__6A30C649");
            });

            modelBuilder.Entity<Orders>(entity =>
            {
                entity.HasKey(e => e.OrderId)
                    .HasName("PK__Orders__46596229BD046042");

                entity.Property(e => e.OrderId).HasColumnName("order_id");

                entity.Property(e => e.BillingAddress)
                    .HasColumnName("billing_address")
                    .HasMaxLength(512);

                entity.Property(e => e.OrderDate)
                    .HasColumnName("order_date")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.OrderStatus)
                    .HasColumnName("order_status")
                    .HasMaxLength(255);

                entity.Property(e => e.ShippingAddress)
                    .HasColumnName("shipping_address")
                    .HasMaxLength(512);

                entity.Property(e => e.TotalAmount)
                    .HasColumnName("total_amount")
                    .HasColumnType("decimal(10, 2)");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__Orders__user_id__656C112C");
            });

            modelBuilder.Entity<Payments>(entity =>
            {
                entity.HasKey(e => e.PaymentId)
                    .HasName("PK__Payments__9B556A381CE4F4E0");

                entity.ToTable("Payments", "dbo");

                entity.Property(e => e.Amount).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.PaymentDate).HasColumnType("datetime");

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Payments)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__Payments__Update__4D94879B");
            });

            modelBuilder.Entity<Person>(entity =>
            {
                entity.ToTable("Person", "dbo");

                entity.HasIndex(e => e.Email)
                    .HasName("UQ__Person__A9D10534284F7BB8")
                    .IsUnique();

                entity.Property(e => e.Address).HasMaxLength(200);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.Disctrict).HasMaxLength(200);

                entity.Property(e => e.Dob)
                    .HasColumnName("DOB")
                    .HasColumnType("datetime");

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");

                entity.Property(e => e.UserId).HasColumnName("User_Id");
            });

            modelBuilder.Entity<Products>(entity =>
            {
                entity.HasKey(e => e.ProductId)
                    .HasName("PK__Products__B40CC6CD4E0D1469");

                entity.ToTable("Products", "dbo");

                entity.Property(e => e.ComparePrice).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.CostPrice).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.CreadtedOn).HasColumnType("datetime");

                entity.Property(e => e.Description)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Price).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.Title)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");

                entity.HasOne(d => d.Subcategory)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.SubcategoryId)
                    .HasConstraintName("FK__Products__Subcat__440B1D61");
            });

            modelBuilder.Entity<Reviews>(entity =>
            {
                entity.HasKey(e => e.ReviewId)
                    .HasName("PK__Reviews__60883D906D6ABC0E");

                entity.Property(e => e.ReviewId).HasColumnName("review_id");

                entity.Property(e => e.ProductId).HasColumnName("product_id");

                entity.Property(e => e.Rating).HasColumnName("rating");

                entity.Property(e => e.ReviewDate)
                    .HasColumnName("review_date")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ReviewText).HasColumnName("review_text");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Reviews)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK__Reviews__product__6FE99F9F");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Reviews)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__Reviews__user_id__70DDC3D8");
            });

            modelBuilder.Entity<Roles>(entity =>
            {
                entity.HasKey(e => e.RoleId)
                    .HasName("PK__Roles__8AFACE1AAE3B8A03");

                entity.ToTable("Roles", "dbo");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.RoleName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Subcategories>(entity =>
            {
                entity.HasKey(e => e.SubcategoryId)
                    .HasName("PK__Subcateg__9C4E705DFCA789A8");

                entity.ToTable("Subcategories", "dbo");

                entity.Property(e => e.CreadetOn).HasColumnType("datetime");

                entity.Property(e => e.Description)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Title)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Subcategories)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK__Subcatego__Categ__412EB0B6");
            });

            modelBuilder.Entity<UserRole>(entity =>
            {
                entity.ToTable("UserRole", "dbo");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.UserRole)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK_UserRole_Roles");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserRole)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_UserRole_UsersLogin");
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK__UsersLog__1788CC4C9F974683");

                entity.ToTable("Users", "dbo");

                entity.HasIndex(e => e.Email)
                    .HasName("UQ__UsersLog__A9D1053439FDB744")
                    .IsUnique();

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Ip)
                    .HasColumnName("IP")
                    .HasMaxLength(200);

                entity.Property(e => e.LastLoginDate).HasColumnType("datetime");

                entity.Property(e => e.LastPasswordChange).HasColumnType("datetime");

                entity.Property(e => e.Password)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.PasswordSalt)
                    .HasMaxLength(200)
                    .IsFixedLength();

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");

                entity.Property(e => e.UserName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Person)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.PersonId)
                    .HasConstraintName("FK_UsersLogin_Person");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
