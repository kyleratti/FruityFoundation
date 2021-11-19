namespace CommonCore.Base.Extensions;

using Structures;
using Microsoft.FSharp.Core;

public static class CouldBeExtensions
{
	public static CouldBe<T> FirstOrEmpty<T>(this IEnumerable<T> col) =>
		col.FirstOrDefault() ?? CouldBe<T>.Empty();

	public static CouldBe<T> ToCouldBe<T>(this T? obj) where T : struct =>
		obj.HasValue
			? CouldBe<T>.Create(obj.Value)
			: CouldBe<T>.Empty();

	public static T? ToNullable<T>(this CouldBe<T> cb) where T : struct =>
		cb.HasValue ? cb.Value : null;

	public static FSharpOption<T> ToOption<T>(this CouldBe<T> cb) =>
		cb.HasValue ? FSharpOption<T>.Some(cb.Value) : FSharpOption<T>.None;
}