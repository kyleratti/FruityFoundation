using System.Data.Common;
using System.Runtime.CompilerServices;
using Dapper;
using FruityFoundation.DataAccess.Abstractions;

namespace FruityFoundation.DataAccess.Core;

// ReSharper disable once ClassWithVirtualMembersNeverInherited.Global
public class DbTransaction<TConnectionType> : IDatabaseTransactionConnection<TConnectionType>
	where TConnectionType : ConnectionType
{
	private readonly DbTransaction _transaction;

	internal DbTransaction(DbTransaction transaction)
	{
		_transaction = transaction;
	}

	/// <inheritdoc />
	public async Task<IEnumerable<T>> Query<T>(
		string sql,
		object? param = null,
		CancellationToken cancellationToken = default
	)
	{
		if (_transaction.Connection is not { } conn)
			throw new InvalidOperationException("Transaction connection cannot be null");

		var command = new CommandDefinition(sql, param, transaction: _transaction, cancellationToken: cancellationToken);

		return await conn.QueryAsync<T>(command);
	}

	/// <inheritdoc />
	public async IAsyncEnumerable<T> QueryUnbuffered<T>(
		string sql,
		object? param = null,
		[EnumeratorCancellation] CancellationToken cancellationToken = default
	)
	{
		if (_transaction.Connection is not { } conn)
			throw new InvalidOperationException("Transaction connection cannot be null");

		var query = conn.QueryUnbufferedAsync<T>(sql, param, transaction: _transaction)
			.WithCancellation(cancellationToken);

		await foreach (var item in query)
			yield return item;
	}

	/// <inheritdoc />
	public async Task<T> QuerySingle<T>(string sql, object? param = null, CancellationToken cancellationToken = default)
	{
		if (_transaction.Connection is not { } conn)
			throw new InvalidOperationException("Transaction connection cannot be null");

		var command = new CommandDefinition(sql, param, transaction: _transaction, cancellationToken: cancellationToken);

		return await conn.QuerySingleAsync<T>(command);
	}

	/// <inheritdoc />
	public async Task Execute(string sql, object? param = null, CancellationToken cancellationToken = default)
	{
		if (_transaction.Connection is not { } conn)
			throw new InvalidOperationException("Transaction connection cannot be null");

		var command = new CommandDefinition(sql, param, transaction: _transaction, cancellationToken: cancellationToken);

		await conn.ExecuteAsync(command);
	}

	/// <inheritdoc />
	public async Task<T?> ExecuteScalar<T>(string sql, object? param = null, CancellationToken cancellationToken = default)
	{
		if (_transaction.Connection is not { } conn)
			throw new InvalidOperationException("Transaction connection cannot be null");

		var command = new CommandDefinition(sql, param, transaction: _transaction, cancellationToken: cancellationToken);

		return await conn.ExecuteScalarAsync<T>(command);
	}

	/// <inheritdoc />
	public async Task<DbDataReader> ExecuteReader(
		string sql,
		object? param = null,
		CancellationToken cancellationToken = default
	)
	{
		if (_transaction.Connection is not { } conn)
			throw new InvalidOperationException("Transaction connection cannot be null");

		var command = new CommandDefinition(sql, param, transaction: _transaction, cancellationToken: cancellationToken);

		return await conn.ExecuteReaderAsync(command);
	}

	/// <inheritdoc />
	public async Task Commit(CancellationToken cancellationToken)
	{
		await _transaction.CommitAsync(cancellationToken);
	}

	/// <inheritdoc />
	public async Task Rollback(CancellationToken cancellationToken)
	{
		await _transaction.RollbackAsync(cancellationToken);
	}

	protected virtual void Dispose(bool disposing)
	{
		if (disposing)
		{
#pragma warning disable IDISP007
			_transaction.Dispose();
#pragma warning restore IDISP007
		}
	}

	/// <inheritdoc />
	public void Dispose()
	{
		Dispose(true);
		GC.SuppressFinalize(this);
	}

	protected virtual async ValueTask DisposeAsyncCore()
	{
#pragma warning disable IDISP007
		await _transaction.DisposeAsync();
#pragma warning restore IDISP007
	}

	/// <inheritdoc />
	public async ValueTask DisposeAsync()
	{
		await DisposeAsyncCore();
		GC.SuppressFinalize(this);
	}
}
