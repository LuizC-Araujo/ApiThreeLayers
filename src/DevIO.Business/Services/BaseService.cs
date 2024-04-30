using DevIO.Business.Models;
using FluentValidation;

namespace DevIO.Business.Services
{
    public abstract class BaseService
    {
        protected void Notification(string message) 
        { 
        }

        protected bool ExecuteValidation<V, E>(V validation, E entity) where V : AbstractValidator<E> where E : Entity
        {
            var validator = validation.Validate(entity);

            if (validator.IsValid) return true;

            // notifications

            return false;
        }
    }
}
