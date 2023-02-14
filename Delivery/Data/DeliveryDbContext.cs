using Microsoft.EntityFrameworkCore;

using Delivery.Entity;
using Delivery.Data.Configurations;

namespace Delivery.Data
{
    public class DeliveryDbContext : DbContext
    {
        public DeliveryDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Customer> Customers { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            ModelBuilder modelBuilder1 = modelBuilder.ApplyConfiguration(new CustomerConfigurations());
        }
    }
}
