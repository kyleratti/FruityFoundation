﻿using System.Data.Common;
using FruityFoundation.Base.Structures;

namespace FruityFoundation.DataAccess.Abstractions;

// ReSharper disable once UnusedTypeParameter
public interface IDatabaseConnection<out TConnectionType> where TConnectionType : ConnectionType
{
	public Task<IEnumerable<T>> Query<T>(string sql, object? param = null, CancellationToken cancellationToken = default);
	public IAsyncEnumerable<T> QueryUnbuffered<T>(string sql, object? param = null, CancellationToken cancellationToken = default);
	public Task<T> QuerySingle<T>(string sql, object? param = null, CancellationToken cancellationToken = default);
	public Task<Maybe<T>> TryQueryFirst<T>(string sql, object? param = null, CancellationToken cancellationToken = default);
	public Task Execute(string sql, object? param = null, CancellationToken cancellationToken = default);
	public Task<T?> ExecuteScalar<T>(string sql, object? param = null, CancellationToken cancellationToken = default);
	public Task<DbDataReader> ExecuteReader(string sql, object? param = null, CancellationToken cancellationToken = default);
}
