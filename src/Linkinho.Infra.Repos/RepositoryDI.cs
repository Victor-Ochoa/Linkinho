using Linkinho.Domain.Core.Contracts;
using Linkinho.Infra.Repos.Data;
using Linkinho.Infra.Repos.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Linkinho.Infra.Repos;

public static class RepositoryDI
{
    public static IHostApplicationBuilder AddRepository(this IHostApplicationBuilder builder)
    {

        builder.AddSqlServerDbContext<LinkinhoDbContext>("database");

        builder.Services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));

        return builder;
    }

    public static async Task UseRepository(this IHost app)
    {
        using (var scope = app.Services.CreateScope())
        {
            var dbContext = scope.ServiceProvider.GetRequiredService<LinkinhoDbContext>();
            await dbContext.Database.EnsureCreatedAsync();
        }
    }
}
