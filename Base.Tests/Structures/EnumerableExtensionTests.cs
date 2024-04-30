using System.Linq;
using FruityFoundation.Base.Structures;
using NUnit.Framework;

namespace Base.Tests.Structures;

public class EnumerableExtensionTests
{
	[TestCase(new object[] { 0, 1, 2 }, true, new object[] { 85 }, ExpectedResult = new object[] { 0, 1, 2, 85 })]
	[TestCase(new object[] { "hi" }, false, new object[] { "there" }, ExpectedResult = new object[] { "hi" })]
	public object[] TestConditionalConcat(object[] input, bool condition, object[] second) =>
		input.ConditionalConcat(condition, second).ToArray();

	[TestCase(new object[] { 0, 1, 2 }, true, 3, ExpectedResult = new object[] { 0, 1, 2, 3 })]
	[TestCase(new object[] { 0, 1, 2 }, false, 3, ExpectedResult = new object[] { 0, 1, 2 })]
	public object[] TestConditionalAppend(object[] input, bool condition, object second) =>
		input.ConditionalAppend(condition, second).ToArray();

	[TestCase(new object[] { 0, 1, 2 }, true, 85, ExpectedResult = new object[0])]
	[TestCase(new object[] { "hi", "there" }, false, "there", ExpectedResult = new object[] { "hi", "there" })]
	public object[] TestConditionalWhere(object[] input, bool condition, object valueToKeep) =>
		input.ConditionalWhere(condition, x => x.Equals(valueToKeep)).ToArray();

	[Test]
	public void TestConditionalAppendWithMaybe_HasAppendedItem_WhenMaybeHasValue()
	{
		var baseArray = new[] { 0, 1, 2 };

		var result = baseArray
			.ConditionalAppend(Maybe.Create(3))
			.ToArray();

		Assert.That(result, Has.Length.EqualTo(4));
		Assert.That(result, Is.EquivalentTo(new[] { 0, 1, 2, 3 }));
	}

	[Test]
	public void TestConditionalAppendWithMaybe_DoesNotHaveAppendedItem_WhenMaybeIsEmpty()
	{
		var baseArray = new[] { 0, 1, 2 };

		var result = baseArray
			.ConditionalAppend(Maybe.Empty<int>())
			.ToArray();

		Assert.That(result, Has.Length.EqualTo(3));
		Assert.That(result, Is.EquivalentTo(new[] { 0, 1, 2 }));
	}
}
