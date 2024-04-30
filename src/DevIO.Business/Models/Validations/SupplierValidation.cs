using FluentValidation;
using static DevIO.Business.Models.Validations.Documents.DocsValidation;

namespace DevIO.Business.Models.Validations
{
    public class SupplierValidation : AbstractValidator<Supplier>
    {
        public SupplierValidation() 
        {
            RuleFor(r => r.Name)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
                .Length(2, 100).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres!");

            When(s => s.SupplierType == SupplierType.FisicalPerson, () =>
            {
                RuleFor(s => s.Document.Length).Equal(CpfValidation.CpfSize)
                    .WithMessage("O campo {PropertyName} precisa ter {ComparisonValue} caracteres e foi fornecido {PropertyValue}.");

                RuleFor(s => CpfValidation.Validate(s.Document)).Equal(true)
                    .WithMessage("O documento fornecido é inválido");
            });

            When(s => s.SupplierType == SupplierType.LegalPerson, () =>
            {
                RuleFor(s => s.Document.Length).Equal(CnpjValidation.CnpjSize)
                    .WithMessage("O campo {PropertyName} precisa ter {ComparisonValue} caracteres e foi fornecido {PropertyValue}.");

                RuleFor(s => CnpjValidation.Validate(s.Document)).Equal(true)
                    .WithMessage("O documento fornecido é inválido");
            });
        }
    }
}
