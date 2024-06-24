using System.Data.Common;
using FruityFoundation.DataAccess.Abstractions;

namespace FruityFoundation.DataAccess.Core;

public class DbConnectionFactory : IDbConnectionFactory
{
	private readonly Func<DbConnection> _readWriteConnectionFactory;
	private readonly Func<DbConnection> _readOnlyConnectionFactory;

	public DbConnectionFactory(Func<DbConnection> readWriteConnectionFactory, Func<DbConnection> readOnlyConnectionFactory)
	{
		_readWriteConnectionFactory = readWriteConnectionFactory;
		_readOnlyConnectionFactory = readOnlyConnectionFactory;
	}

	public INonTransactionalDbConnection<ReadWrite> CreateConnection()
	{
		var connection = _readWriteConnectionFactory();
		var nonTxConnection = new NonTransactionalDbConnection<ReadWrite>(connection);
		return nonTxConnection;
	}

	public INonTransactionalDbConnection<ReadOnly> CreateReadOnlyConnection()
	{
		var connection = _readOnlyConnectionFactory();
		var nonTxConnection = new NonTransactionalDbConnection<ReadOnly>(connection);
		return nonTxConnection;
	}
}
