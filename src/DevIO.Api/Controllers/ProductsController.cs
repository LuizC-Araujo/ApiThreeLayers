using DevIO.Api.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace DevIO.Api.Controllers
{
    [Route("api/products")]
    public class ProductsController : MainController
    {
        public ProductsController()
        {           
        }

        [HttpGet]
        public async Task<IEnumerable<ProductViewModel>> Getall()
        {

        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<ProductViewModel>> GetById(Guid id)
        {

        }

        [HttpPost]
        public async Task<ActionResult<ProductViewModel>> Add(ProductViewModel productViewModel)
        {

        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update(Guid id, ProductViewModel productViewModel)
        {

        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<ProductViewModel>> Delete(Guid id)
        {

        }
    }
}
