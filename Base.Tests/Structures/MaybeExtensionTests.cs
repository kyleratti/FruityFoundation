using System;
using FruityFoundation.Base.Structures;
using NUnit.Framework;

namespace Base.Tests.Structures;

public class MaybeExtensionTests
{
	[Test]
	public void EnumerableFirstOrEmptyTests()
	{
		Assert.AreEqual(Maybe.Empty<string>(), Array.Empty<string>().FirstOrEmpty());
		Assert.AreEqual(Maybe.Just<string>("banana"), new[] { "banana" }.FirstOrEmpty());
	}

	[Test]
	public void TestToMaybe()
	{
		Assert.AreEqual(Maybe.Empty<int>(), Maybe.Empty<int>());
		Assert.AreNotEqual(Maybe.Just(293921), Maybe.Just(2));
	}

	[Test]
	public void MaybeNullableTests()
	{
		Assert.IsNull(Maybe.Empty<int>().ToNullable());
		Assert.IsNull(Maybe.Just(0, hasValue: _ => false).ToNullable());
	}
}
