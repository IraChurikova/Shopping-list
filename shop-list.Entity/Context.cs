using shopList.Entity.Models;
using Microsoft.EntityFrameworkCore;
namespace shopList.Entity;
public class Context:DbContext
{
    public DbSet<Admin>? Admin{get;set;}
    public DbSet<Buyer>? Buyers{get;set;}
    public DbSet<Description>?  Descriptions{get;set;}
    public DbSet<User>? Users{get;set;}
    public DbSet<Product>? Products{get;set;}
    public DbSet<ProductInStock>? ProductInStocks{get;set;}
    public DbSet<ProductList>? ProductLists{get;set;}
    public DbSet<Salesmen>? Salesmens{get;set;}
    public Context  (DbContextOptions<Context> options): base(options){}

    protected override void OnModelCreating(ModelBuilder builder)
    {
        #region Admin

        builder.Entity<Admin>().ToTable("admin");
        builder.Entity<Admin>().HasKey(x => x.Id);

        #endregion
        #region Users
        builder.Entity<User>().ToTable("users");
        builder.Entity<User>().HasKey(x => x.Id);

        #endregion

        #region Description

        builder.Entity<User>().ToTable("descriptions");
        builder.Entity<User>().HasKey(x => x.Id);

        #endregion
         #region ProductInStock

        builder.Entity<User>().ToTable("productInStocks");
        builder.Entity<User>().HasKey(x => x.Id);

        #endregion

        #region Salesmen

        builder.Entity<Salesmen>().ToTable("Salesmens");
        builder.Entity<Salesmen>().HasKey(x => x.Id);
        builder.Entity<Salesmen>().HasOne(x=>x.User)
                                    .WithMany(x => x.SalesmensList)
                                    .HasForeignKey(x => x.UserId)
                                    .OnDelete(DeleteBehavior.Cascade);
        #endregion

          #region Buyer

        builder.Entity<Buyer>().ToTable("Buyers");
        builder.Entity<Buyer>().HasKey(x => x.Id);
        builder.Entity<Buyer>().HasOne(x=>x.User)
                                    .WithMany(x => x.BuyersList)
                                    .HasForeignKey(x => x.UserId)
                                    .OnDelete(DeleteBehavior.Cascade);
        #endregion

        #region ProductList

        builder.Entity<ProductList>().ToTable("ProductLists");
        builder.Entity<ProductList>().HasKey(x => x.Id);
        builder.Entity<ProductList>().HasOne(x => x.Buyer)
                                    .WithMany(x => x.ProductLists)
                                .HasForeignKey(x => x.BuyerId)
                            .OnDelete(DeleteBehavior.Cascade);
        builder.Entity<ProductList>().HasOne(x => x.Product)
                                    .WithMany(x => x.Products)
                                .HasForeignKey(x => x.ProductId)
                            .OnDelete(DeleteBehavior.Cascade);                    
        
        #endregion
        #region Product

        builder.Entity<Product>().ToTable("Products");
        builder.Entity<Product>().HasKey(x => x.Id);
        builder.Entity<Product>().HasOne(x => x.Salesmen)
                                    .WithMany(x => x.Products1)
                                .HasForeignKey(x => x.SalesmenId)
                            .OnDelete(DeleteBehavior.Cascade);
        builder.Entity<Product>().HasOne(x => x.ProductInStock)
                                    .WithMany(x => x.Products2)
                                .HasForeignKey(x => x.ProductInStocksId)
                            .OnDelete(DeleteBehavior.Cascade);   
        builder.Entity<Product>().HasOne(x => x.Description)
                                    .WithMany(x => x.Products3)
                                .HasForeignKey(x => x.DescriptionId)
                            .OnDelete(DeleteBehavior.Cascade);                                        
        
        #endregion

    }
}


