using FluentValidation;
using MotoSeguraApi.Dtos;

namespace MotoSeguraApi.Validators {
    public class GpsDtoValidator : AbstractValidator<GpsDto>
    {
        public GpsDtoValidator()
        {
            RuleFor(x => x.Velocidad)
                .GreaterThanOrEqualTo(0)
                .WithMessage("La velocidad no puede ser negativa.");

            RuleFor(x => x.Altitud)
                .GreaterThanOrEqualTo(0)
                .WithMessage("La altitud no puede ser negativa.");

            RuleFor(x => x.Direccion)
                .InclusiveBetween(0, 360)
                .WithMessage("La dirección debe estar entre 0 y 360 grados.");

            RuleFor(x => x.Ubicacion)
                .NotNull()
                .SetValidator(new CoordenadasDtoValidator());
        }
    }

}