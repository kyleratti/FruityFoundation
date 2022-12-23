﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace FruityFoundation.Base.Extensions;

public static class EnumerableExtensions
{
	public static IEnumerable<T> ConditionalConcat<T>(this IEnumerable<T> enumerable, bool isConditionValid, IEnumerable<T> second) =>
		!isConditionValid ? enumerable : enumerable.Concat(second);

	public static IEnumerable<T> ConditionalWhere<T>(this IEnumerable<T> enumerable, bool isConditionValid, Func<T, bool> pred) =>
		!isConditionValid ? enumerable : enumerable.Where(pred);

	public static IEnumerable<TOutput> Choose<TInput, TOutput>(this IEnumerable<TInput> enumerable, Func<TInput, TOutput?> mapper) =>
		enumerable
			.Select(mapper)
			.Where(x => x is not null)
			.Cast<TOutput>();
}