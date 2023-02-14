using Microsoft.EntityFrameworkCore;

using Delivery.Entity;
using Delivery.Data;
using Delivery.Repositories.Interfaces;
using System.Threading;

namespace Delivery.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly DeliveryDbContext _dbContex;

        public CustomerRepository(DeliveryDbContext dbContex) =>
            _dbContex = dbContex;
        

        public void Add(Customer customer)=>
            _dbContex.Set<Customer>().Add(customer);
        

        public async Task<IReadOnlyCollection<Customer>> GetAll() =>
            await _dbContex
            .Set<Customer>()
            .ToListAsync();



        public async Task<Customer?> GetCustomerById(int id, CancellationToken cancellationToken = default) =>
            await _dbContex
            .Set<Customer>()
            .FirstOrDefaultAsync(Customer => Customer.Id== id, cancellationToken);
        

        public void Update(Customer customer) =>
            _dbContex.Set<Customer>().Update(customer);

        public async  Task<Customer>Delete(int id)
        {
            var result = await _dbContex.Customers
                 .FirstOrDefaultAsync(Id => Id.Id == id);
            if(result != null)
            {
                _dbContex.Customers.Remove(result);
                await _dbContex.SaveChangesAsync();
                return result;
            }
            return null;
        }
            
           

     
    }
   
}
