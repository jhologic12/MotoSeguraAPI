using FluentValidation;
using MotoSeguraAPI.DTOs;

namespace MotoSeguraAPI.Validators
{
    public class HelmetValidationRequestValidator : AbstractValidator<HelmetValidationRequest>
    {
        public HelmetValidationRequestValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("El nombre es obligatorio.")
                .MaximumLength(100);

            RuleFor(x => x.HelmetType)
                .NotEmpty().WithMessage("El tipo de casco es obligatorio.")
                .Must(type => type.ToLower() == "integral" || type.ToLower() == "certificado")
                .WithMessage("El tipo de casco debe ser 'Integral' o 'Certificado'.");
        }
    }
}