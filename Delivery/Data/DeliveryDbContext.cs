using Delivery.Entity;
using Microsoft.EntityFrameworkCore;

namespace Delivery.Data
{
    public class DeliveryDbContext : DbContext
    {
        public DeliveryDbContext(DbContextOptions<DeliveryDbContext>options) : base(options)
        {

        }

        public DbSet<Customer> Customers { get; set; }
        public DbContextOptions<DeliveryDbContext> Options { get; }
    }
}
