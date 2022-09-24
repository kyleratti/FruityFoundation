namespace FruityFoundation.Base.Extensions;

public static class EnumerableExtensions
{
	public static IEnumerable<T> ConditionalConcat<T>(this IEnumerable<T> enumerable, bool isConditionValid, IEnumerable<T> second) =>
		!isConditionValid ? enumerable : enumerable.Concat(second);
}