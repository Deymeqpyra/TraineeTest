using Infrastructure.Persistence;

namespace Presentation.Modules;

public static class DbModule
{
    public static async Task InitalizeDb(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        var initializer = scope.ServiceProvider.GetRequiredService<ApplicationDbContextInitializer>();
        await initializer.InitializeAsync();
    }
}