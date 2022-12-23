using System;

namespace FruityFoundation.Base.Extensions;

public static class StringExtensions
{
	public static bool EqualsIgnoreCase(this string str, string otherString) =>
		str.Equals(otherString, StringComparison.OrdinalIgnoreCase);

	public static bool ContainsIgnoreCase(this string str, string otherString) =>
		str.IndexOf(otherString, StringComparison.OrdinalIgnoreCase) != -1;

	/// <summary>
	/// Truncate a string to exactly <paramref name="maxLength"/> characters.
	/// </summary>
	/// <param name="str"></param>
	/// <param name="maxLength">The maximum number of characters. If <paramref name="str"/> has fewer characters, it will be truncated to the length of <paramref name="str"/>.</param>
	public static string Truncate(this string str, int maxLength) =>
		str.Substring(0, Math.Min(str.Length, maxLength));
}