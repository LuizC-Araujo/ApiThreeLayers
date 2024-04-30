using FluentValidation;

namespace DevIO.Business.Models.Validations
{
    public class AddressValidation : AbstractValidator<Address>
    {
        public AddressValidation() 
        {
            RuleFor(r => r.Logradouro)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido!")
                .Length(2, 200).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres!");

            RuleFor(r => r.Neighborhood)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido!")
                .Length(2, 100).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres!");

            RuleFor(r => r.Cep)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido!")
                .Length(8).WithMessage("O campo {PropertyName} precisa ter {MaxLength} caracteres!");

            RuleFor(r => r.City)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido!")
                .Length(2, 50).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres!");

            RuleFor(r => r.State)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido!")
                .Length(2, 50).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres!");

            RuleFor(r => r.Number)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido!")
                .Length(2, 50).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres!");
        }
    }
}
