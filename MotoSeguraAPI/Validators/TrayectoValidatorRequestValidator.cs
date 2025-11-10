
using FluentValidation;
using MotoSeguraApi.Dtos;

namespace MotoSeguraAPI.Validators
{
    public class TrayectoValidator : AbstractValidator<TrayectoDto>
    {
        public TrayectoValidator()
        {
            RuleFor(x => x.FechaInicio).NotEmpty();
            RuleFor(x => x.FechaFin).GreaterThan(x => x.FechaInicio);
            RuleFor(x => x.VelocidadPromedioKmH).GreaterThanOrEqualTo(0);
            RuleFor(x => x.VerificacionCasco.Casco_Detectado)
                .Equal(true).WithMessage("Debe colocarse el casco para iniciar el trayecto.");
        }
    }
}