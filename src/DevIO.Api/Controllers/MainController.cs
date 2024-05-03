using DevIO.Business.Interfaces;
using DevIO.Business.Notifications;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Net;

namespace DevIO.Api.Controllers
{
    [ApiController]
    public abstract class MainController : ControllerBase
    {
        private readonly INotifier _notifier;

        public MainController(INotifier notifier)
        {
            _notifier = notifier;
        }

        protected bool ValidOperation()
        {
            return !_notifier.HasNotification();
        }

        protected ActionResult CustomResponse(HttpStatusCode statusCode = HttpStatusCode.OK, object result = null)
        {
            if (ValidOperation()) 
            {
                return new ObjectResult(result)
                {
                    StatusCode = Convert.ToInt32(statusCode),
                };

            }

            return BadRequest(new
            {
                errors = _notifier.GetNotifications().Select(n => n.Message)
            });

        }

        protected ActionResult CustomResponse(ModelStateDictionary modelState)
        {
            if (!ModelState.IsValid) InvalidModelErrorNotifier(modelState);
            return CustomResponse();
        }

        protected void InvalidModelErrorNotifier(ModelStateDictionary modelState)
        {
            var errors = modelState.Values.SelectMany(x => x.Errors);

            foreach (var error in errors)
            {
                var errorMsg = error.Exception == null ? error.ErrorMessage : error.Exception.Message;
                ErrorNotifier(errorMsg);
            }
        }

        protected void ErrorNotifier(string message)
        {
            _notifier.Handle(new Notification(message));
        }
    }
}
