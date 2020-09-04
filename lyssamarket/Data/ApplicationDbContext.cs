using System;
using System.Collections.Generic;
using System.Text;
using lyssamarket.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace lyssamarket.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Category> Categorys{get;set;}
        public DbSet<Provider> Providers{get;set;}
        public DbSet<Product> Products{get;set;}
        public DbSet<Promotion> Promotions{get;set;}
        public DbSet<Stock> Stocks{get;set;}
        public DbSet<Output> Outputs{get;set;}
        public DbSet<Sale> Sales{get;set;}

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}
