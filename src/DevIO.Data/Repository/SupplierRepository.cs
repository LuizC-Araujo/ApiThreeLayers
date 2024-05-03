using DevIO.Business.Interfaces;
using DevIO.Business.Models;
using DevIO.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace DevIO.Data.Repository
{
    public class SupplierRepository : Repository<Supplier>, ISupplierRepository
    {
        public SupplierRepository(DevIODbContext db) : base(db)
        {
        }

        public async Task<Supplier> GetSupplierAddress(Guid id)
        {
            return await Db.Suppliers
                .AsNoTracking()
                .Include(s => s.Address)
                .FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<Supplier> GetSupplierProductAddress(Guid id)
        {
            return await Db.Suppliers
                .AsNoTracking()
                .Include(s => s.Products)
                .Include(s => s.Address)
                .FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<Address> GetAddressBySupplier(Guid supplierId)
        {
            return await Db.Addresses
                .AsNoTracking()
                .FirstOrDefaultAsync(s => s.SupplierId == supplierId);
        }

        public async Task DeleteSupplierAddress(Address address)
        {
            Db.Addresses.Remove(address);
            await SaveChanges();
        }
    }
}
