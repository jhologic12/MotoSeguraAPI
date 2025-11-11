using FluentValidation;
using MotoSeguraApi.Dtos;

namespace MotoSeguraApi.Validators{
    public class CoordenadasDtoValidator : AbstractValidator<CoordenadasDto>
    {
        public CoordenadasDtoValidator()
        {
            RuleFor(x => x.Lat)
                .InclusiveBetween(-90, 90)
                .WithMessage("La latitud debe estar entre -90 y 90.");

            RuleFor(x => x.Lng)
                .InclusiveBetween(-180, 180)
                .WithMessage("La longitud debe estar entre -180 y 180.");
        }
    }
}