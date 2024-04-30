using DevIO.Business.Interfaces;
using DevIO.Business.Models;

namespace DevIO.Business.Services
{
    public class ProductService : BaseService, IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task Add(Product product)
        {
            await _productRepository.Add(product);
        }

        public async Task Update(Product product)
        {
            await _productRepository.Update(product);
        }

        public async Task Remove(Guid id)
        {
            await _productRepository.Delete(id);
        } 

        public void Dispose()
        {
            _productRepository.Dispose();
        }
    }
}
