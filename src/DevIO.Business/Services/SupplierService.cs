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

            if (_supplierRepository.Search(s => s.Document == supplier.Document).Result.Any())
            {
                Notification("Já existe um fornecedor com este documento informado!");
                return;
            }

            await _supplierRepository.Add(supplier);
        }

        public async Task Update(Supplier supplier)
        {
            if (!ExecuteValidation(new SupplierValidation(), supplier)) return;

            if(_supplierRepository.Search(s => s.Document == supplier.Document && s.Id != supplier.Id).Result.Any())
            {
                Notification("Já existe um fornecedor com este documento informado!");
                return;
            }

            await _supplierRepository.Update(supplier);
        }

        public async Task Remove(Guid id)
        {
            var supplier = await _supplierRepository.GetSupplierProductAddress(id);

            if (supplier == null)
            {
                Notification("O fornecedor não existe!");
                return;
            }

            if (supplier.Products.Any())
            {
                Notification("O fornecedor possui produtos cadastrados!");
                return;
            }

            var address = await _supplierRepository.GetAddressBySupplier(id);

            if (address != null) 
            {
                await _supplierRepository.DeleteSupplierAddress(address);
            }

            await _supplierRepository.Delete(id);
        }

        public void Dispose()
        {
            _supplierRepository?.Dispose();
        }
    }
}
