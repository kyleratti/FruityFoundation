using CommonCore.Base.Structures;
using Microsoft.FSharp.Core;

namespace CommonCore.Base.Extensions;

public static class FSharpExtensions
{
	public static Maybe<T> ToMaybe<T>(this FSharpOption<T> option) =>
		FSharpOption<T>.get_IsSome(option)
			? Maybe<T>.Create(option.Value)
			: Maybe<T>.Empty();
}