using Microsoft.FSharp.Collections;

namespace CommonCore.Base.Extensions;

public static class FSharpDataTypeExtensions
{
	public static FSharpList<T> ToFSharpList<T>(this IEnumerable<T> list) =>
		ListModule.OfArray(list.ToArray());
}