using System.Text.RegularExpressions;
using CommonCore.Base.Structures;

namespace CommonCore.Base.Extensions;

public static class StringExtensions
{
	public static bool EqualsIgnoreCase(this string str, string otherString) =>
		str.Equals(otherString, StringComparison.OrdinalIgnoreCase);

	public static bool ContainsIgnoreCase(this string str, string otherString) =>
		str.IndexOf(otherString, StringComparison.OrdinalIgnoreCase) != -1;

	public static CouldBe<string> ToCouldBe(this string str) =>
		CouldBe<string>.Create(str, _ => string.IsNullOrEmpty(str));

	/// <summary>
	/// Truncate a string to exactly <paramref name="maxLength"/> characters.
	/// </summary>
	/// <param name="str"></param>
	/// <param name="maxLength">The maximum number of characters. If <paramref name="str"/> has fewer characters, it will be truncated to the length of <paramref name="str"/>.</param>
	public static string Truncate(this string str, int maxLength) =>
		str[..Math.Min(str.Length, maxLength)];

	public static string EscapeMarkdown(this string str) =>
		Regex.Replace(str, @"[*_#>\[\]\(\)\\]", matchedChar => $"\\{matchedChar.Value}");
}