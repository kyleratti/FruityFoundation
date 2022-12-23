using System;
using System.Collections.Generic;
using System.Linq;

namespace FruityFoundation.Base.Structures;

public static class MaybeExtensions
{
	public static Maybe<T> FirstOrEmpty<T>(this IEnumerable<T> collection)
	{
		using var enumerator = collection.GetEnumerator();
		
		return !enumerator.MoveNext() ? Maybe<T>.Empty() : enumerator.Current;
	}

	public static Maybe<T> FirstOrEmpty<T>(this IEnumerable<T> collection, Func<T, bool> pred)
	{
		foreach (var item in collection)
			if (pred(item))
				return item;
		
		return Maybe<T>.Empty();
	}

	public static T? ToNullable<T>(this Maybe<T> item) where T : struct =>
		item.HasValue ? item.Value : null;

	public static IEnumerable<TOutput> Choose<TInput, TOutput>(this IEnumerable<TInput> enumerable, Func<TInput, Maybe<TOutput>> mapper) =>
		enumerable
			.Select(mapper)
			.Where(x => x.HasValue)
			.Select(x => x.Value);
}