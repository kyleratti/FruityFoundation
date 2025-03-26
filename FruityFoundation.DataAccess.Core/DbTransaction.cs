using System.Data.Common;
using System.Runtime.CompilerServices;
using Dapper;
using FruityFoundation.Base.Structures;
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
	public DbConnection RawDbConnection
	{
		get
		{
			if (_transaction.Connection is not { } tx)
				throw new InvalidOperationException("Transaction connection cannot be null");

			return tx;
		}
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

		return await conn.QueryAsync<T>(command).ConfigureAwait(false);
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

		await foreach (var item in query.ConfigureAwait(false))
			yield return item;
	}

	/// <inheritdoc />
	public async Task<T> QuerySingle<T>(string sql, object? param = null, CancellationToken cancellationToken = default)
	{
		if (_transaction.Connection is not { } conn)
			throw new InvalidOperationException("Transaction connection cannot be null");

		var command = new CommandDefinition(sql, param, transaction: _transaction, cancellationToken: cancellationToken);

		return await conn.QuerySingleAsync<T>(command).ConfigureAwait(false);
	}

	/// <inheritdoc />
	public async Task<Maybe<T>> TryQueryFirst<T>(string sql, object? param = null, CancellationToken cancellationToken = default)
	{
		if (_transaction.Connection is not { } conn)
			throw new InvalidOperationException("Transaction connection cannot be null");

		return await conn.QueryUnbufferedAsync<T>(sql, param, transaction: _transaction)
			.FirstOrEmptyAsync(cancellationToken).ConfigureAwait(false);
	}

	/// <inheritdoc />
	public async Task<int> Execute(string sql, object? param = null, CancellationToken cancellationToken = default)
	{
		if (_transaction.Connection is not { } conn)
			throw new InvalidOperationException("Transaction connection cannot be null");

		var command = new CommandDefinition(sql, param, transaction: _transaction, cancellationToken: cancellationToken);

		return await conn.ExecuteAsync(command).ConfigureAwait(false);
	}

	/// <inheritdoc />
	public async Task<T?> ExecuteScalar<T>(string sql, object? param = null, CancellationToken cancellationToken = default)
	{
		if (_transaction.Connection is not { } conn)
			throw new InvalidOperationException("Transaction connection cannot be null");

		var command = new CommandDefinition(sql, param, transaction: _transaction, cancellationToken: cancellationToken);

		return await conn.ExecuteScalarAsync<T>(command).ConfigureAwait(false);
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

		return await conn.ExecuteReaderAsync(command).ConfigureAwait(false);
	}

	/// <inheritdoc />
	public async Task Commit(CancellationToken cancellationToken)
	{
		await _transaction.CommitAsync(cancellationToken).ConfigureAwait(false);
	}

	/// <inheritdoc />
	public async Task Rollback(CancellationToken cancellationToken)
	{
		await _transaction.RollbackAsync(cancellationToken).ConfigureAwait(false);
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
		await _transaction.DisposeAsync().ConfigureAwait(false);
#pragma warning restore IDISP007
	}

	/// <inheritdoc />
	public async ValueTask DisposeAsync()
	{
		await DisposeAsyncCore().ConfigureAwait(false);
		GC.SuppressFinalize(this);
	}
}
