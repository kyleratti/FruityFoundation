using FruityFoundation.DataAccess.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace FruityFoundation.DataAccess.Sqlite;

public static class ServiceCollectionExtensions
{
	public static IServiceCollection AddSqliteConnectionFactory(this IServiceCollection services)
	{
		services.AddSingleton<IDbConnectionFactory, DbConnectionFactory>();
		return services;
	}
}
