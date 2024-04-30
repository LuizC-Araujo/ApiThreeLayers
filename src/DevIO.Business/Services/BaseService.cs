using DevIO.Business.Interfaces;
using DevIO.Business.Models;
using DevIO.Business.Notifications;
using FluentValidation;
using FluentValidation.Results;

namespace DevIO.Business.Services
{
    public abstract class BaseService
    {
        private readonly INotifier _notifier;

        public BaseService(INotifier notifier)
        {
            _notifier = notifier;
        }

        protected void Notification(ValidationResult validationResult)
        {
            foreach (var item in validationResult.Errors)
            {
                Notification(item.ErrorMessage);
            }
        }

        protected void Notification(string message) 
        {
            _notifier.Handle(new Notification(message));
        }

        protected bool ExecuteValidation<V, E>(V validation, E entity) where V : AbstractValidator<E> where E : Entity
        {
            var validator = validation.Validate(entity);

            if (validator.IsValid) return true;

            Notification(validator);

            return false;
        }
    }
}
