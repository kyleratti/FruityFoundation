using System.Diagnostics.CodeAnalysis;
using FruityFoundation.DataAccess.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace FruityFoundation.DataAccess.Sqlite;

[ExcludeFromCodeCoverage(Justification = "Dependency injection helpers")]
public static class ServiceCollectionExtensions
{
	public static void AddSqliteDataAccess(
		this IServiceCollection services,
		Func<IServiceProvider, string> getReadWriteConnectionString,
		Func<IServiceProvider, string> getReadOnlyConnectionString
	)
	{
		services.AddScoped<INonTransactionalDbConnection<ReadWrite>>(serviceProvider =>
		{
			var connectionFactory = serviceProvider.GetRequiredService<IDbConnectionFactory>();

			return connectionFactory.CreateConnection();
		});

		services.AddScoped<INonTransactionalDbConnection<ReadOnly>>(serviceProvider =>
		{
			var connectionFactory = serviceProvider.GetRequiredService<IDbConnectionFactory>();

			return connectionFactory.CreateReadOnlyConnection();
		});

		services.AddSingleton<IDbConnectionFactory, SqliteDbConnectionFactory>(serviceProvider =>
			new SqliteDbConnectionFactory(
				serviceProvider,
				getReadOnlyConnectionString: getReadOnlyConnectionString,
				getReadWriteConnectionString: getReadWriteConnectionString));
	}
}
