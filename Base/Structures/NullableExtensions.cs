namespace FruityFoundation.Base.Structures;

public static class NullableExtensions
{
	public static Maybe<T> ToMaybe<T>(this T? item) where T : struct =>
		item ?? Maybe.Empty<T>();

	public static Maybe<T> AsMaybe<T>(this T? item) where T : class =>
		item ?? Maybe.Empty<T>();
}
