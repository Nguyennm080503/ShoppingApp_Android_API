using BussinessObject;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DAO
{
    public class ShoppingAppDBContext : DbContext
    {
        public ShoppingAppDBContext()
        {
        }

        public ShoppingAppDBContext(DbContextOptions<ShoppingAppDBContext> options) : base(options)
        {

        }

        public DbSet<Account> Account { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Cart> Cart { get; set; }
        public DbSet<CartDetail> CartDetail { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(GetConnectionString());
            }
        }


        private static string GetConnectionString()
        {
            IConfigurationRoot config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", true, true)
                .Build();

            var strConn = config["ConnectionStrings:SQLClient"];
            return strConn;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Account>()
                .HasKey(a => a.AccountID);

            modelBuilder.Entity<Account>()
                .Property(a => a.AccountID)
                .ValueGeneratedOnAdd()
                .UseIdentityColumn();

            modelBuilder.Entity<Product>()
               .HasKey(p => p.ProductID);


            modelBuilder.Entity<Category>()
               .HasKey(cate => cate.CategoryID);

            modelBuilder.Entity<Category>()
                .Property(cate => cate.CategoryID)
                .ValueGeneratedOnAdd()
                .UseIdentityColumn();

            modelBuilder.Entity<Cart>()
              .HasKey(c => c.CartID);

            modelBuilder.Entity<Cart>()
                .Property(c => c.CartID)
                .ValueGeneratedOnAdd()
                .UseIdentityColumn();

            modelBuilder.Entity<CartDetail>()
              .HasKey(c => c.CartDetailID);

            modelBuilder.Entity<CartDetail>()
                .Property(c => c.CartDetailID)
                .ValueGeneratedOnAdd()
                .UseIdentityColumn();



            //one account have many cart
            modelBuilder.Entity<Cart>()
                .HasOne(a => a.Account)
                .WithMany(c => c.Carts)
                .HasForeignKey(a => a.AccountID)
                .OnDelete(DeleteBehavior.Restrict);

            // one cart have many detail
            modelBuilder.Entity<CartDetail>()
                .HasOne(cart => cart.Cart)
                .WithMany(cart => cart.Details)
                .HasForeignKey(cart => cart.CartID)
                .OnDelete(DeleteBehavior.Restrict);

            // one product have many detail
            modelBuilder.Entity<CartDetail>()
               .HasOne(cart => cart.Product)
               .WithMany(p => p.Details)
               .HasForeignKey(m => m.ProductID)
               .OnDelete(DeleteBehavior.Restrict);

            // one category have many product
            modelBuilder.Entity<Product>()
               .HasOne(p => p.Category)
               .WithMany(c => c.Products)
               .HasForeignKey(p => p.CategoryID)
               .OnDelete(DeleteBehavior.Restrict);

        }

    }
}
