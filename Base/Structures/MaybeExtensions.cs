using Microsoft.FSharp.Core;

namespace FruityFoundation.Base.Structures;

public static class MaybeExtensions
{
	public static Maybe<T> FirstOrEmpty<T>(this IEnumerable<T> col) =>
		col.FirstOrDefault() ?? Maybe<T>.Empty();

	public static T? ToNullable<T>(this Maybe<T> item) where T : struct =>
		item.HasValue ? item.Value : null;

	public static FSharpOption<T> ToFSharpOption<T>(this Maybe<T> cb) =>
		cb.HasValue
			? FSharpOption<T>.Some(cb.Value)
			: FSharpOption<T>.None;
}