using FluentValidation;
using MotoSeguraAPI.Dtos;

namespace MotoSeguraApi.Validators {
    public class GiroscopioDtoValidator : AbstractValidator<GiroscopioDto>
    {
        public GiroscopioDtoValidator()
        {
            RuleFor(x => x.CambioBruscoDireccion).NotNull();
        }
    }

}