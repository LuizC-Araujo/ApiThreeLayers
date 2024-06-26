﻿using DevIO.Business.Models;

namespace DevIO.Business.Interfaces
{
    public interface IProductRepository : IRepository<Product>
    {
        Task<IEnumerable<Product>> GetProductsBySupplier(Guid supplierId);
        Task<IEnumerable<Product>> GetSupplierProducts();
        Task<Product> GetProductSupplierById(Guid id);
    }
}
