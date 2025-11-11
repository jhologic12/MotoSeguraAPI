

using FluentValidation;
using MotoSeguraApi.Dtos;
namespace MotoSeguraApi.Validators;

public class AcelerometroDtoValidator : AbstractValidator<AcelerometroDto>
{
    public AcelerometroDtoValidator()
    {
        RuleFor(x => x.Aceleracion)
            .InclusiveBetween(-100, 100); // Ajusta según tu rango esperado

        RuleFor(x => x.FrenadoBrusco)
            .NotNull(); // Aunque bool no puede ser null, esto asegura que el campo esté presente
    }
}