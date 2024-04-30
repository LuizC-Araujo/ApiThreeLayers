using FluentValidation;

namespace DevIO.Business.Models.Validations
{
    public class ProductValidation : AbstractValidator<Product>
    {
        public ProductValidation() 
        {
            RuleFor(r => r.Name)
                .NotEmpty()
                .WithMessage("O campo {PropertyName} deve ser fornecido!")
                .Length(2, 200)
                .WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres!");

            RuleFor(r => r.Description)
                .NotEmpty()
                .WithMessage("O campo {PropertyName} deve ser fornecido!")
                .Length(2, 1000)
                .WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres!");

            RuleFor(r => r.Value)
                .GreaterThan(0).WithMessage("O campo {PropertyName} precisa ser maior que {ComparisonValue}!");
        }
    }
}
