using Microsoft.AspNetCore.Hosting;

public static class KestrelExtensions
{
    public static void ConfigureKestrelServer(this WebApplicationBuilder builder)
    {
        builder.WebHost.ConfigureKestrel(options =>
        {
            options.ListenAnyIP(5086); // HTTP
            options.ListenAnyIP(7043, listen =>
            {
                listen.UseHttps("localhost.pfx", "1234");
            });
        });
    }
}
