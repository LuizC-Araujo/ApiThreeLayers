using DevIO.Business.Models;

namespace DevIO.Business.Interfaces
{
    public interface ISupplierRepository : IRepository<Supplier>
    {
        Task<Supplier> GetSupplierAddress(Guid id);
        Task<Supplier> GetSupplierProductAddress(Guid id);
        Task<Address> GetAddressBySupplier(Guid supplierId);
        Task DeleteSupplierAddress(Address address);
    }
}
