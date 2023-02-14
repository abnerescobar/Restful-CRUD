using Delivery.Entity;

namespace Delivery.Repositories.Interfaces
{
    public interface ICustomerRepository
    {
        Task<IReadOnlyCollection<Customer>> GetAll();
        Task<Customer> GetCustomerById(int id, CancellationToken cancellationToken = default);
        void Add(Customer customer);
        void Update(Customer customer);
        Task<Customer> Delete(int id);
    }
}
