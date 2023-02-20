using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

using Delivery.Data;
using Delivery.Repositories.Interfaces;

namespace Delivery.Repositories
{
    internal sealed class UnitOfWork : IUnitOfWork
    {
        private readonly DeliveryDbContext _dbcontext;

        public UnitOfWork(DeliveryDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public void SaveChangesAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task SaveChanguesAsync(CancellationToken cancellationToken = default)
        {
            UpdateAuditableEntites();
            return _dbcontext.SaveChangesAsync(cancellationToken);
        }
        private void UpdateAuditableEntites()
        {
            IEnumerable<EntityEntry<IAuditableEntity>> entries =
                _dbcontext
                    .ChangeTracker
                    .Entries<IAuditableEntity>();
            foreach (EntityEntry<IAuditableEntity> entityEntry in entries) 
            {
            if(entityEntry.State == EntityState.Added)
                {
                    entityEntry.Property(a => a.CreatedOnUtc)
                        .CurrentValue = DateTime.UtcNow;
                }
            if(entityEntry.State == EntityState.Modified)
                {
                    entityEntry.Property(a => a.ModifiedOnUtc)
                        .CurrentValue = DateTime.UtcNow;
                }
            }
        }
    }
}
