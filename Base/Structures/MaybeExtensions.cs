using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace FruityFoundation.Base.Structures;

public static class MaybeExtensions
{
	public static Maybe<T> FirstOrEmpty<T>(this IEnumerable<T> collection)
	{
		if (collection is IList<T> list)
		{
			if (list.Count == 0)
				return Maybe.Empty<T>();

			return list[0];
		}

		using var enumerator = collection.GetEnumerator();

		if (!enumerator.MoveNext())
			return Maybe.Empty<T>();

		return enumerator.Current;
	}

	public static Maybe<T> FirstOrEmpty<T>(this IEnumerable<T> collection, Func<T, bool> pred)
	{
		foreach (var item in collection)
			if (pred(item))
				return item;
		
		return Maybe.Empty<T>();
	}

	public static async ValueTask<Maybe<T>> FirstOrEmptyAsync<T>(this IAsyncEnumerable<T> source, CancellationToken cancellationToken = default)
	{
		if (source is IList<T> { Count: > 0 } list)
			return Maybe.Create(list[0]);

		await using var e = source
			.ConfigureAwait(false)
			.WithCancellation(cancellationToken)
			.GetAsyncEnumerator();

		if (await e.MoveNextAsync())
			return e.Current;

		return Maybe.Empty<T>();
	}

	public static async ValueTask<Maybe<T>> FirstOrEmptyAsync<T>(this IAsyncEnumerable<T> source, Func<T, bool> predicate, CancellationToken cancellationToken = default)
	{
		if (source is IList<T> { Count: > 0 } list)
			return list[0];

		await using var e = source
			.ConfigureAwait(false)
			.WithCancellation(cancellationToken)
			.GetAsyncEnumerator();

		while (await e.MoveNextAsync())
		{
			var value = e.Current;

			if (predicate(value))
				return value;
		}

		return Maybe.Empty<T>();
	}

	public static async ValueTask<Maybe<T>> FirstOrEmptyAsync<T>(this IAsyncEnumerable<T> source, Func<T, ValueTask<bool>> asyncPredicate, CancellationToken cancellationToken = default)
	{
		if (source is IList<T> { Count: > 0 } list)
			return list[0];

		await using var e = source
			.ConfigureAwait(false)
			.WithCancellation(cancellationToken)
			.GetAsyncEnumerator();

		while (await e.MoveNextAsync())
		{
			var value = e.Current;

			if (await asyncPredicate(value).ConfigureAwait(false))
				return value;
		}

		return Maybe.Empty<T>();
	}

	public static Maybe<TValue> TryGetValue<TKey, TValue>(this IDictionary<TKey, TValue> dict, TKey key) =>
		dict.TryGetValue(key, out var value) ? Maybe.Create(value) : Maybe.Empty<TValue>();

	public static Maybe<TValue> TryGet<TKey, TValue>(this IReadOnlyDictionary<TKey, TValue> dict, TKey key) =>
		dict.TryGetValue(key, out var value) ? Maybe.Create(value) : Maybe.Empty<TValue>();

	public static T? ToNullable<T>(this Maybe<T> item) where T : struct =>
		item.HasValue ? item.Value : null;
}
