using DevIO.Business.Interfaces;
using DevIO.Business.Models;

namespace DevIO.Business.Services
{
    public class SupplierService : BaseService, ISupplierService
    {
        private readonly ISupplierRepository _supplierRepository;

        public SupplierService(ISupplierRepository supplierRepository)
        {
            _supplierRepository = supplierRepository;
        }

        public async Task Add(Supplier supplier)
        {
            // validar se a entidade é consistente
            // validar se hjá não existe outro fornecedor com o mesmo documento

            await _supplierRepository.Add(supplier);
        }

        public async Task Update(Supplier supplier)
        {
            await _supplierRepository.Update(supplier);
        }

        public async Task Remove(Guid id)
        {
            await _supplierRepository.Delete(id);
        }

        public void Dispose()
        {
            _supplierRepository?.Dispose();
        }
    }
}
