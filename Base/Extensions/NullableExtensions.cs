using FruityFoundation.Base.Structures;

namespace FruityFoundation.Base.Extensions;

public static class NullableExtensions
{
	public static Maybe<T> ToMaybe<T>(this T? item) where T : struct =>
		item ?? Maybe<T>.Empty();

	public static Maybe<T> ToMaybe<T>(this T? item) where T : class =>
		item ?? Maybe<T>.Empty();
}