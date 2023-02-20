namespace Delivery.Repositories.Interfaces
{
    public interface IUnitOfWork
    {
        void SaveChangesAsync(CancellationToken cancellationToken);
    }
}
