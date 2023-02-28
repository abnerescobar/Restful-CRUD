using Delivery.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;

namespace Delivery.Repositories.Interfaces
{
    public class CachedCustomerRepository : ICustomerRepository
    {
        private readonly ICustomerRepository _decorated;

        public CachedCustomerRepository(ICustomerRepository decorated, IMemoryCache memoryCache)
        {
            _decorated = decorated;
            _memoryCache = memoryCache;
        }

        private readonly IMemoryCache _memoryCache;
        public void Add(Customer customer)
        {
            _decorated.Add(customer);
            _memoryCache.Remove("GetAllCustomers");
        }

        public Task<Customer> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IReadOnlyCollection<Customer>> GetAll()
        {
            string key = $"GetAllCustomers";
            
             return await _memoryCache.GetOrCreateAsync(key, async entry => { return await _decorated.GetAll(); });
    
        }

        public Task<Customer> GetCustomerById(int id, CancellationToken cancellationToken = default)
        {
            string key = $"Customer-{id}";
            return _memoryCache.GetOrCreateAsync(
                key,
                entry =>
                {
                    entry.SetAbsoluteExpiration(TimeSpan.FromMinutes(2));
                    return _decorated.GetCustomerById(id, cancellationToken);
                });
        }

        public void Update(Customer customer)
        {
            _decorated.Update(customer);
        }
    }
}
