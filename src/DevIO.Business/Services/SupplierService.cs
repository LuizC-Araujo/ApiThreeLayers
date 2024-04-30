using DevIO.Business.Interfaces;
using DevIO.Business.Models;
using DevIO.Business.Models.Validations;

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
            if (!ExecuteValidation(new SupplierValidation(), supplier) 
                || !ExecuteValidation(new AddressValidation(), supplier.Address)) return;

            // validar se hjá não existe outro fornecedor com o mesmo documento

            await _supplierRepository.Add(supplier);
        }

        public async Task Update(Supplier supplier)
        {
            if (!ExecuteValidation(new SupplierValidation(), supplier)) return;
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
