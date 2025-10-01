namespace Product.Service.Domain.Products.Interfaces
{  
    public interface IUnitOfWork
    {
        void Dispose();
        Task<bool> SaveAsync();
    }
}
