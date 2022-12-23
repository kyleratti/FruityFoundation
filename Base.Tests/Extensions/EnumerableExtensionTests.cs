using System.Linq;
using FruityFoundation.Base.Extensions;
using NUnit.Framework;

namespace Base.Tests.Extensions;

public class EnumerableExtensionTests
{
	[TestCase(new object[] { 0, 1, 2 }, true, new object[] { 85 }, ExpectedResult = new object[] { 0, 1, 2, 85 })]
	[TestCase(new object[] { "hi" }, false, new object[] { "there" }, ExpectedResult = new object[] { "hi" })]
	public object[] TestConditionalConcat(object[] input, bool isConditionValid, object[] second) =>
		input.ConditionalConcat(isConditionValid, second).ToArray();

	[TestCase(new object[] { 0, 1, 2 }, true, 85, ExpectedResult = new object[0])]
	[TestCase(new object[] { "hi", "there" }, false, "there", ExpectedResult = new object[] { "hi", "there" })]
	public object[] TestConditionalWhere(object[] input, bool isConditionValid, object valueToKeep) =>
		input.ConditionalWhere(isConditionValid, x => x.Equals(valueToKeep)).ToArray();

	[Test]
	public void TestChooseWithRefType()
	{
		var input = new [] { "one", null, "two" };

		var result = input.Choose(x => x).ToArray();

		Assert.That(result.GetType(), Is.EqualTo(typeof(string[])));
		Assert.That(result.Length, Is.EqualTo(2));
		Assert.That(result[0], Is.EqualTo("one"));
		Assert.That(result[1], Is.EqualTo("two"));
	}

	[Test]
	public void TestChooseWithValueType()
	{
		var input = new int?[] { 1, null, 2 };

		var result = input.Choose(x => x).ToArray();

		Assert.That(result.GetType(), Is.EqualTo(typeof(int[])));
		Assert.That(result.GetType(), Is.Not.EqualTo(typeof(int?[])));
		Assert.That(result.Length, Is.EqualTo(2));
		Assert.That(result[0], Is.EqualTo(1));
		Assert.That(result[1], Is.EqualTo(2));
	}
}