using DevIO.Api.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace DevIO.Api.Controllers
{
    [Route("api/suppliers")]
    public class SuppliersController : MainController
    {
        public SuppliersController()
        {
            
        }

        [HttpGet]
        public async Task<IEnumerable<SupplierViewModel>> GetAll()
        {

        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<SupplierViewModel>> GetById(Guid id)
        {

        }

        [HttpPost]
        public async Task<ActionResult<SupplierViewModel>> Add(SupplierViewModel supplierViewModel)
        {

        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<SupplierViewModel>> Update(Guid id, SupplierViewModel supplierViewModel)
        {

        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<SupplierViewModel>> Delete(Guid id)
        {

        }
    }
}
