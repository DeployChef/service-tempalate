using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Template.Common.Data.Extensions;

public static class NpgSqlServiceCollectionExtensions
{
    public static IServiceCollection AddNpgSql<T>(this IServiceCollection services, string connectionString) where T : DbContext
    {
        services.AddDbContext<T>(options =>
        {
            options
                .UseNpgsql(connectionString)
                .UseSnakeCaseNamingConvention();
        });

        return services;
    }
}