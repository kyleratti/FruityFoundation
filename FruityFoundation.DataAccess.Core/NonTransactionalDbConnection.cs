using System.Data;
using System.Data.Common;
using System.Runtime.CompilerServices;
using Dapper;
using FruityFoundation.Base.Structures;
using FruityFoundation.DataAccess.Abstractions;

namespace FruityFoundation.DataAccess.Core;

// ReSharper disable once ClassWithVirtualMembersNeverInherited.Global
public class NonTransactionalDbConnection<TConnectionType> : INonTransactionalDbConnection<TConnectionType>
	where TConnectionType : ConnectionType
{
	private readonly DbConnection _connection;

	/// <summary>
	/// C'tor
	/// </summary>
	public NonTransactionalDbConnection(DbConnection connection)
	{
		_connection = connection;
	}

	/// <inheritdoc />
	public async Task<IEnumerable<T>> Query<T>(
		string sql,
		object? param = null,
		CancellationToken cancellationToken = default
	) => await _connection.QueryAsync<T>(new CommandDefinition(sql, param, cancellationToken: cancellationToken));

	/// <inheritdoc />
	public async IAsyncEnumerable<T> QueryUnbuffered<T>(
		string sql,
		object? param = null,
		[EnumeratorCancellation] CancellationToken cancellationToken = default
	)
	{
		var query = _connection.QueryUnbufferedAsync<T>(sql, param, transaction: null)
			.WithCancellation(cancellationToken);

		await foreach (var item in query)
			yield return item;
	}

	/// <inheritdoc />
	public async Task<T> QuerySingle<T>(
		string sql,
		object? param = null,
		CancellationToken cancellationToken = default
	) => await _connection.QuerySingleAsync<T>(new CommandDefinition(sql, param, cancellationToken: cancellationToken));

	/// <inheritdoc />
	public async Task<Maybe<T>> TryQueryFirst<T>(
		string sql,
		object? param = null,
		CancellationToken cancellationToken = default
	) =>
		await _connection.QueryUnbufferedAsync<T>(sql, param, transaction: null)
			.FirstOrEmptyAsync(cancellationToken);

	/// <inheritdoc />
	public async Task Execute(
		string sql,
		object? param = null,
		CancellationToken cancellationToken = default
	) => await _connection.ExecuteAsync(new CommandDefinition(sql, param, cancellationToken: cancellationToken));

	/// <inheritdoc />
	public async Task<T?> ExecuteScalar<T>(
		string sql,
		object? param = null,
		CancellationToken cancellationToken = default
	) => await _connection.ExecuteScalarAsync<T>(new CommandDefinition(sql, param, cancellationToken: cancellationToken));

	/// <inheritdoc />
	public async Task<DbDataReader> ExecuteReader(
		string sql,
		object? param = null,
		CancellationToken cancellationToken = default
	) => await _connection.ExecuteReaderAsync(new CommandDefinition(sql, param, cancellationToken: cancellationToken));

	/// <inheritdoc />
	public async Task<IDatabaseTransactionConnection<TConnectionType>> CreateTransaction(CancellationToken cancellationToken)
	{
		if (!_connection.State.HasFlag(ConnectionState.Open))
			await _connection.OpenAsync(cancellationToken);

		var tx = await _connection.BeginTransactionAsync(cancellationToken);

		return new DbTransaction<TConnectionType>(tx);
	}

	/// <inheritdoc />
	public async Task<IDatabaseTransactionConnection<TConnectionType>> CreateTransaction(IsolationLevel isolationLevel, CancellationToken cancellationToken)
	{
		if (!_connection.State.HasFlag(ConnectionState.Open))
			await _connection.OpenAsync(cancellationToken);

		var tx = await _connection.BeginTransactionAsync(isolationLevel, cancellationToken);

		return new DbTransaction<TConnectionType>(tx);
	}

	protected virtual void Dispose(bool disposing)
	{
		if (disposing)
		{
#pragma warning disable IDISP007
			_connection.Dispose();
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
		await _connection.DisposeAsync();
#pragma warning restore IDISP007
	}

	/// <inheritdoc />
	public async ValueTask DisposeAsync()
	{
		await DisposeAsyncCore();
		GC.SuppressFinalize(this);
	}
}
