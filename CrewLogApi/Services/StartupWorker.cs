using CrewLogApi.Data;
using OpenIddict.Abstractions;

namespace CrewLogApi.Services
{
    public class StartupWorker : IHostedService
    {
        private readonly IServiceProvider _serviceProvider;

        public StartupWorker(IServiceProvider serviceProvider)
            => _serviceProvider = serviceProvider;

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            using var scope = _serviceProvider.CreateScope();

            var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            await context.Database.EnsureCreatedAsync(cancellationToken);

            var manager = scope.ServiceProvider.GetRequiredService<IOpenIddictApplicationManager>();

            if (await manager.FindByClientIdAsync("console", cancellationToken) is null)
            {
                await manager.CreateAsync(new OpenIddictApplicationDescriptor
                {
                    ClientId = "spa",
                    DisplayName = "Main SPA",
                    Permissions =
                    {
                        OpenIddictConstants.Permissions.Endpoints.Token,
                        OpenIddictConstants.Permissions.GrantTypes.AuthorizationCode
                    }
                }, cancellationToken);
            }
        }

        public Task StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;
    }
}
