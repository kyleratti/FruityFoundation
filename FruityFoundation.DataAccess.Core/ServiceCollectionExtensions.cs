using System.Diagnostics.CodeAnalysis;
using FruityFoundation.DataAccess.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace FruityFoundation.DataAccess.Core;

[ExcludeFromCodeCoverage(Justification = "Dependency injection helpers")]
public static class ServiceCollectionExtensions
{
	public static void AddDataAccessCore(
		this IServiceCollection services,
		Func<IServiceProvider, INonTransactionalDbConnection<ReadWrite>> readWriteConnectionImplementationFactory,
		Func<IServiceProvider, INonTransactionalDbConnection<ReadOnly>> readOnlyConnectionImplementationFactory
	)
	{
		services.AddTransient<INonTransactionalDbConnection<ReadWrite>>(readWriteConnectionImplementationFactory);
		services.AddTransient<INonTransactionalDbConnection<ReadOnly>>(readOnlyConnectionImplementationFactory);
		services.AddSingleton<IDbConnectionFactory, DbConnectionFactory>();
	}
}
