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
}