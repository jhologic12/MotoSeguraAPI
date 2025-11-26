using FluentValidation;
using MotoSeguraAPI.Dtos;

namespace MotoSeguraAPI.Validators
{
    public class TrayectoValidator : AbstractValidator<TrayectoDto>
    {
        public TrayectoValidator()
        {
            RuleFor(x => x.FechaInicio).NotEmpty();
            RuleFor(x => x.FechaFin).GreaterThan(x => x.FechaInicio);
            RuleFor(x => x.VelocidadPromedioKmH).GreaterThanOrEqualTo(0);
            
            // ✅ CAMBIA ESTA LÍNEA - Elimina la validación que obliga el casco
            // RuleFor(x => x.VerificacionCasco.Casco_Detectado)
            //     .Equal(true).WithMessage("Debe colocarse el casco para iniciar el trayecto.");
            
            // ✅ OPCIONAL: Agrega una validación más flexible
            RuleFor(x => x.VerificacionCasco)
                .NotNull().WithMessage("La verificación de casco es requerida");
        }
    }
}