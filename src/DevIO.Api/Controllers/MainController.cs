using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace DevIO.Api.Controllers
{
    [ApiController]
    public abstract class MainController : ControllerBase
    {
        protected bool ValidOperation()
        {
            return true;
        }

        protected ActionResult CustomResponse(object result = null)
        {
            if (ValidOperation()) return new ObjectResult(result);

            return BadRequest(new 
            {
                // errors
            });

        }

        protected ActionResult CustomResponse(ModelStateDictionary modelState)
        {
            if (!ModelState.IsValid) { } // notificar erros
            return CustomResponse();
        }

        protected void ErrorNotifier(string message)
        {

        }
    }
}
