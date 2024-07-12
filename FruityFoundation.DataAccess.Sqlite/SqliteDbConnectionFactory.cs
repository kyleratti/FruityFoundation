using FruityFoundation.DataAccess.Abstractions;
using FruityFoundation.DataAccess.Core;
using Microsoft.Data.Sqlite;

namespace FruityFoundation.DataAccess.Sqlite;

public class SqliteDbConnectionFactory : IDbConnectionFactory
{
	private readonly IServiceProvider _serviceProvider;
	private readonly Func<IServiceProvider, string> _getReadWriteConnectionString;
	private readonly Func<IServiceProvider, string> _getReadOnlyConnectionString;

	public SqliteDbConnectionFactory(
		IServiceProvider serviceProvider,
		Func<IServiceProvider, string> getReadWriteConnectionString,
		Func<IServiceProvider, string> getReadOnlyConnectionString)
	{
		_serviceProvider = serviceProvider;
		_getReadWriteConnectionString = getReadWriteConnectionString;
		_getReadOnlyConnectionString = getReadOnlyConnectionString;
	}

	/// <inheritdoc />
	public INonTransactionalDbConnection<ReadWrite> CreateConnection()
	{
		var connectionString = _getReadWriteConnectionString(_serviceProvider);
		var connection = new SqliteConnection(connectionString);

		return new NonTransactionalDbConnection<ReadWrite>(connection);
	}

	/// <inheritdoc />
	public INonTransactionalDbConnection<ReadOnly> CreateReadOnlyConnection()
	{
		var connectionString = _getReadOnlyConnectionString(_serviceProvider);
		var connection = new SqliteConnection(connectionString);

		return new NonTransactionalDbConnection<ReadOnly>(connection);
	}
}
