using System.Data.Common;
using FruityFoundation.DataAccess.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace FruityFoundation.DataAccess.Core;

public class DbConnectionFactory : IDbConnectionFactory
{
	private readonly IServiceProvider _serviceProvider;

	public DbConnectionFactory(IServiceProvider serviceProvider)
	{
		_serviceProvider = serviceProvider;
	}

	public INonTransactionalDbConnection<ReadWrite> CreateConnection()
	{
		var nonTxConnection = _serviceProvider.GetRequiredService<INonTransactionalDbConnection<ReadWrite>>();
		return nonTxConnection;
	}

	public INonTransactionalDbConnection<ReadOnly> CreateReadOnlyConnection()
	{
		var nonTxConnection = _serviceProvider.GetRequiredService<INonTransactionalDbConnection<ReadOnly>>();
		return nonTxConnection;
	}
}
