using FruityFoundation.DataAccess.Abstractions;

namespace FruityFoundation.DataAccess.Sqlite;

public class DbConnectionFactory : IDbConnectionFactory
{
	private readonly string _readWriteConnectionString;
	private readonly string _readOnlyConnectionString;

	public DbConnectionFactory(string readWriteConnectionString, string readOnlyConnectionString)
	{
		_readWriteConnectionString = readWriteConnectionString;
		_readOnlyConnectionString = readOnlyConnectionString;
	}

	public INonTransactionalDbConnection<ReadWrite> CreateConnection()
	{
		if (string.IsNullOrWhiteSpace(_readWriteConnectionString))
			throw new ApplicationException("ReadWrite connection string was not found or empty.");

		var connection = new NonTransactionalDbConnection<ReadWrite>(_readWriteConnectionString);
		return connection;
	}

	public INonTransactionalDbConnection<ReadOnly> CreateReadOnlyConnection()
	{
		if (string.IsNullOrWhiteSpace(_readOnlyConnectionString))
			throw new ApplicationException("ReadOnly connection string was not found or empty.");

		var connection = new NonTransactionalDbConnection<ReadOnly>(_readOnlyConnectionString);
		return connection;
	}
}
