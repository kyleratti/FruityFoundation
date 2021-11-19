using CommonCore.Base.Extensions;
using CommonCore.Base.Structures;
using NUnit.Framework;

namespace Base.Tests.Extensions;

public class StringExtensionTests
{
	[Test]
	[TestCase("banana", "banana", ExpectedResult = true)]
	[TestCase("banana", "baNAnA", ExpectedResult = true)]
	[TestCase("tuckerIsMyDog", "tuckerisMYdog", ExpectedResult = true)]
	[TestCase("if I were a dog, I'd go insane", "how do dogs not get bored", ExpectedResult = false)]
	public bool EqualsIgnoreCaseTests(string inputOne, string inputTwo) =>
		inputOne.EqualsIgnoreCase(inputTwo);

	[Test]
	[TestCase("bananas have potassium", "banana", ExpectedResult = true)]
	[TestCase("you can't spell trucker without ucker", "UCKER", ExpectedResult = true)]
	public bool ContainsIgnoreCaseTests(string haystack, string needle) =>
		haystack.ContainsIgnoreCase(needle);

	[Test]
	public void StringToCouldBeTests()
	{
#pragma warning disable CS8604
		Assert.AreEqual(CouldBe<string>.Empty(), (null as string).ToCouldBe());
#pragma warning restore CS8604
		Assert.AreEqual(CouldBe<string>.Create("banana"), "banana".ToCouldBe());
	}

	[Test]
	[TestCase("banana", 1, ExpectedResult = "b")]
	[TestCase("This is a longer sentence. I would like it capped at 30 characters.", 30, ExpectedResult = "This is a longer sentence. I w")]
	public string StringTruncateTests(string str, int maxLength) =>
		str.Truncate(maxLength);

	[Test]
	[TestCase("Bob has a hat", ExpectedResult = "Bob has a hat")]
	[TestCase("This string *has formatting*", ExpectedResult = @"This string \*has formatting\*")]
	[TestCase("This string [has a hyperlink to insta](https://instagram.com)", ExpectedResult = @"This string \[has a hyperlink to insta\]\(https://instagram.com\)")]
	public string EscapeMarkdownTests(string str) =>
		str.EscapeMarkdown();
}