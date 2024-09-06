using System.Data;
using FruityFoundation.Base.Structures;

namespace FruityFoundation.DataAccess.Abstractions;

public interface INonTransactionalDbConnection<TConnectionType> : IDatabaseConnection<TConnectionType>, IDisposable, IAsyncDisposable
	where TConnectionType : ConnectionType
{
	public Task<IDatabaseTransactionConnection<TConnectionType>> CreateTransaction(CancellationToken cancellationToken);
	public Task<IDatabaseTransactionConnection<TConnectionType>> CreateTransaction(IsolationLevel isolationLevel, CancellationToken cancellationToken);
}
