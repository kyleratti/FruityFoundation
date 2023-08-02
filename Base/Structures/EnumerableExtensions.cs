using System;
using System.Collections.Generic;
using System.Linq;

namespace FruityFoundation.Base.Structures;

public static class EnumerableExtensions
{
	public static IEnumerable<T> ConditionalConcat<T>(this IEnumerable<T> enumerable, bool condition, IEnumerable<T> second) =>
		!condition ? enumerable : enumerable.Concat(second);

	public static IEnumerable<T> ConditionalAppend<T>(this IEnumerable<T> enumerable, bool condition, T second) =>
		condition ? enumerable.Append(second) : enumerable;
	
	public static IEnumerable<T> ConditionalWhere<T>(this IEnumerable<T> enumerable, bool condition, Func<T, bool> pred) =>
		!condition ? enumerable : enumerable.Where(pred);

	public static IEnumerable<TOutput> Choose<TInput, TOutput>(this IEnumerable<TInput> enumerable, Func<TInput, Maybe<TOutput>> chooser) =>
		enumerable.Select(chooser).Where(x => x.HasValue).Select(x => x.Value);
}
