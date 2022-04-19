using System;
using GeneralStoreAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace GeneralStoreAPI
{
    public class GeneralStoreDbContext : DbContext
    {
        public GeneralStoreDbContext(DbContextOptions<GeneralStoreDbContext> options) : base (options){}
        public DbSet<ProductEdit> Product { get; set; }
        public DbSet<CustomerEdit> Customer { get; set; }
    }
}