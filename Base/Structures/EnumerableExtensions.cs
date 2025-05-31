using System;
using System.Collections.Generic;
using System.Linq;

namespace FruityFoundation.Base.Structures;

public static class EnumerableExtensions
{
	public static IEnumerable<T> ConditionalConcat<T>(this IEnumerable<T> enumerable, bool condition, IEnumerable<T> second)
	{
		if (!condition)
			return enumerable;

		return enumerable.Concat(second);
	}

	public static IEnumerable<T> ConditionalAppend<T>(this IEnumerable<T> enumerable, bool condition, T second)
	{
		if (!condition)
			return enumerable;

		return enumerable.Append(second);
	}

	public static IEnumerable<T> ConditionalAppend<T>(this IEnumerable<T> enumerable, Maybe<T> item)
	{
		if (!item.Try(out var value))
			return enumerable;

		return enumerable.Append(value);
	}

	public static IEnumerable<T> ConditionalWhere<T>(this IEnumerable<T> enumerable, bool condition, Func<T, bool> pred)
	{
		if (!condition)
			return enumerable;

		return enumerable.Where(pred);
	}

	public static IEnumerable<TOutput> Choose<TInput, TOutput>(
		this IEnumerable<TInput> enumerable,
		Func<TInput, Maybe<TOutput>> chooser
	)
	{
		return enumerable
			.Select(chooser)
			.Where(x => x.HasValue)
			.Select(x => x.Value);
	}
}
