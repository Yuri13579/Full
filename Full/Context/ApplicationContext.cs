﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Configuration;
using Back.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SharedAll.Models;

namespace Back.Context
{
    public class ApplicationContext : IdentityDbContext<User>
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<DocEnterProduct> DocEnterProducts { get; set; }
        public DbSet<Provider> Providers { get; set; }
        public DbSet<Shop> Shops { get; set; }
        public DbSet<DocEnterProductDetail> DocEnterProductDetails { get; set; }
        public DbSet<SaleOrder> SaleOrders { get; set; }
        public DbSet<SaleOrderDetail> SaleOrderDetails { get; set; }
        public DbSet<SalePriseDoc> SalePriseDocs { get; set; }
        public DbSet<Profile> Profile { get; set; }
        public DbSet<ShopProduct> ShopProduct { get; set; }
        public DbSet<ShopBalanceGood> ShopBalanceGood { get; set; }
        
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-TH6PGTN;Initial Catalog=1UT2;Integrated Security=True;Connect Timeout=60;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
          // optionsBuilder.UseSqlServer(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.ProductId);

                entity.Property(e => e.Deleted)
                    .HasDefaultValue(false);
                
                entity.HasMany(c => c.SaleOrderDetails)
                    .WithOne(e => e.Product)
                    .HasForeignKey(c => c.ProductId);
                
                entity.HasMany(c => c.SalePriseDocs)
                    .WithOne(e => e.Product)
                    .HasForeignKey(c => c.ProductId);

                entity.HasData(
                    new Product { ProductId = 1, Barcode = 4802221111, Name = "Fairy", Description = "500ml"},
                    new Product { ProductId = 2, Barcode = 4802221222, Name = "Fairy", Description = "250ml" },
                    new Product { ProductId = 3, Barcode = 4802221333, Name = "Gala", Description = "500ml" }
                );
            });
            
            modelBuilder.Entity<Shop>(entity =>
            {
                entity.HasKey(e => e.ShopId);

                entity.Property(e => e.Deleted)
                    .HasDefaultValue(false);

                entity.HasMany(c => c.SaleOrders)
                    .WithOne(e => e.Shop)
                    .HasForeignKey(c => c.SaleOrderID); ;

                entity.HasData(
                    new Shop {ShopId = 1, Address = "Holovna 100", Name = "EcoShop1"},
                    new Shop {ShopId = 2, Address = "Shevchenka ", Name = "EcoShop2"}
                );
            });

            modelBuilder.Entity<ShopProduct>(entity =>
            {
                entity.HasKey(e => e.ShopProductId);

                entity.Property(e => e.Deleted)
                    .HasDefaultValue(false);

                entity.HasOne(c => c.Shop)
                    .WithMany(e => e.ShopProducts)
                    .HasForeignKey(c => c.ShopId); ;

                entity.HasOne(c => c.Product)
                    .WithMany(e => e.ShopProducts)
                    .HasForeignKey(c => c.ProductId); ;

                entity.HasData(
                    new ShopProduct {ShopProductId = 1, ShopId = 1, ProductId = 1},
                    new ShopProduct { ShopProductId = 2, ShopId = 1, ProductId = 2 },
                    new ShopProduct { ShopProductId = 3, ShopId = 1, ProductId = 3 },
                    new ShopProduct { ShopProductId = 4, ShopId = 2, ProductId = 1 },
                    new ShopProduct { ShopProductId = 5, ShopId = 2, ProductId = 2 },
                    new ShopProduct { ShopProductId = 6, ShopId = 2, ProductId = 3 }
                );
            });
            

            modelBuilder.Entity<SaleOrder>(entity =>
            {
                entity.HasKey(e => e.SaleOrderID);
                
                entity.Property(e => e.Deleted)
                    .HasDefaultValue(false);
                
                entity.HasMany(c => c.SaleOrderDetails)
                    .WithOne(e => e.SaleOrder)
                    .HasForeignKey(c => c.SaleOrderDetailId);

                entity.HasData(
                    new SaleOrder {SaleOrderID = 1, DataTime = DateTime.Now, ShopId = 1},
                    new SaleOrder { SaleOrderID = 2, DataTime = DateTime.Now, ShopId = 2 }
                );
            });

            modelBuilder.Entity<SaleOrderDetail>(entity =>
            {
                entity.HasKey(e => e.SaleOrderDetailId);

                entity.HasOne(c => c.SaleOrder)
                    .WithMany(e => e.SaleOrderDetails)
                    .HasForeignKey(c => c.SaleOrderId);


                entity.HasData(
                    new SaleOrderDetail { SaleOrderDetailId = 1, SaleOrderId = 1, Count = 3, ProductId =1, PriceCost = 12.5, PriseSale = 15},
                    new SaleOrderDetail { SaleOrderDetailId = 2, SaleOrderId = 1, Count = 2, ProductId = 2, PriceCost = 14.3, PriseSale = 17 },
                    new SaleOrderDetail { SaleOrderDetailId = 3, SaleOrderId = 2, Count = 5, ProductId = 1, PriceCost = 12.5, PriseSale = 15 },
                    new SaleOrderDetail { SaleOrderDetailId = 4, SaleOrderId = 2, Count = 4, ProductId = 2, PriceCost = 14.3, PriseSale = 17 },
                    new SaleOrderDetail { SaleOrderDetailId = 5, SaleOrderId = 2, Count = 1, ProductId = 3, PriceCost = 16, PriseSale = 19.5 }
                    );
            });
            
            modelBuilder.Entity<DocEnterProduct>(entity =>
            {
                entity.HasKey(e => e.DocEnterProductId);

                entity.Property(e => e.Deleted)
                    .HasDefaultValue(false);

                entity.HasMany(c => c.DocEnterProductDetails)
                    .WithOne(e => e.DocEnterProduct)
                   .HasForeignKey(c => c.DocEnterProductDetailId);
                });

            modelBuilder.Entity<Provider>(entity =>
            {
                entity.HasKey(e => e.ProviderId);

                entity.Property(e => e.Deleted)
                    .HasDefaultValue(false);

                entity.HasMany(c => c.DocEnterProducts)
                    .WithOne(e => e.Provider)
                    .HasForeignKey(c => c.ProviderId);
                
            });

            modelBuilder.Entity<ShopBalanceGood>(entity =>
            {
                entity.HasKey(e => e.ShopBalanceGoodId);

                entity.Property(e => e.Deleted)
                    .HasDefaultValue(false);

                entity.HasOne(c => c.DocEnterProduct)
                    .WithMany(e => e.ShopBalanceGood)
                    .HasForeignKey(c => c.DocEnterProductId);

                entity.HasOne(c => c.Product)
                    .WithMany(e => e.ShopBalanceGood)
                    .HasForeignKey(c => c.ProductId);

                entity.HasOne(c => c.Shop)
                    .WithMany(e => e.ShopBalanceGood)
                    .HasForeignKey(c => c.ShopId);

            });

            modelBuilder.Entity<Provider>(entity =>
            {
                entity.HasKey(e => e.ProviderId);

                entity.Property(e => e.Deleted)
                    .HasDefaultValue(false);

                entity.HasMany(c => c.DocEnterProducts)
                    .WithOne(e => e.Provider)
                    .HasForeignKey(c => c.DocEnterProductId);

           });



        }






    }
}
