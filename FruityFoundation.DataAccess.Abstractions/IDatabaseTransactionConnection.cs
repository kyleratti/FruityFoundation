namespace FruityFoundation.DataAccess.Abstractions;

public interface IDatabaseTransactionConnection<out TConnectionType> : IDatabaseConnection<TConnectionType>, IDisposable, IAsyncDisposable
	where TConnectionType : ConnectionType
{
	public Task Commit(CancellationToken cancellationToken);
	public Task Rollback(CancellationToken cancellationToken);
}
