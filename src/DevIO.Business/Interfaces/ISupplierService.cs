using DevIO.Business.Models;

namespace DevIO.Business.Interfaces
{
    public interface ISupplierService : IDisposable
    {
        Task Add(Supplier supplier);
        Task Update(Supplier supplier);
        Task Remove(Guid id);
    }
}
