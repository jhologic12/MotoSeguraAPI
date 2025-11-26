using FluentValidation;
using MotoSeguraAPI.Dtos;
namespace MotoSeguraApi.Validators
{
    public class ConectividadDtoValidator : AbstractValidator<ConectividadDto>
    {
        public ConectividadDtoValidator()
        {
            RuleFor(x => x.RedMovil).NotNull();
            RuleFor(x => x.Wifi).NotNull();
        }
    }
}