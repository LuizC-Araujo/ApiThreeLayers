using DevIO.Business.Interfaces;
using DevIO.Business.Models;
using DevIO.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace DevIO.Data.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(DevIODbContext db) : base(db) { }

        public async Task<IEnumerable<Product>> GetProductsBySupplier(Guid supplierId)
        {
            return await Search(p =>  p.SupplierId == supplierId);
        }

        public async Task<Product> GetProductSupplierById(Guid id)
        {
            return await Db.Products
                .AsNoTracking()
                .Include(p => p.Supplier)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<Product>> GetSupplierProducts()
        {
            return await Db.Products
                .AsNoTracking()
                .Include(f => f.Supplier)
                .OrderBy(p => p.Name)
                .ToListAsync();
        }
    }
}
