namespace WarehouseManagement.Repositories
{
    public interface IPersistence
    {
        Task SaveChangesAsync();
        Task BeginTransactionAsync();
        Task CommitTransactionAsync();
        Task RollbackTransactionAsync();
    }
}
