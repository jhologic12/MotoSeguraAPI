public static class CorsExtensions
{
    public static void ConfigureCors(this WebApplicationBuilder builder)
    {
        builder.Services.AddCors(options =>
        {
            options.AddPolicy("FrontendPolicy", policy =>
            {
                policy.WithOrigins(
                    "https://192.168.1.1:4173",
                    "http://10.0.2.2:4173",
                    "http://192.168.1.1:4173",
                    "https://192.168.1.1:5173",
                    "https://localhost:5086"
                )
                .AllowAnyHeader()
                .AllowAnyMethod()
                .AllowCredentials();
            });
        });
    }
}
