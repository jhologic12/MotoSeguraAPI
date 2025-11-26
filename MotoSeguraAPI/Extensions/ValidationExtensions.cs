using FluentValidation;
using FluentValidation.AspNetCore;
using MotoSeguraAPI.Validators;

public static class ValidationExtensions
{
    public static void ConfigureFluentValidation(this WebApplicationBuilder builder)
    {
        builder.Services.AddFluentValidationAutoValidation();
        builder.Services.AddFluentValidationClientsideAdapters();
        builder.Services.AddValidatorsFromAssemblyContaining<TrayectoValidator>();
    }
}
