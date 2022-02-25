using System;
using FruityFoundation.Base.Extensions;
using FruityFoundation.Base.Structures;
using NUnit.Framework;

namespace Base.Tests.Extensions;

public class MaybeExtensionTests
{
	[Test]
	public void EnumerableFirstOrEmptyTests()
	{
		Assert.AreEqual(Maybe<string>.Empty(), Array.Empty<string>().FirstOrEmpty());
		Assert.AreEqual(Maybe<string>.Create("banana"), new[] { "banana" }.FirstOrEmpty());
	}

	[Test]
	public void TestToMaybe()
	{
		Assert.AreEqual(Maybe<int>.Empty(), Maybe<int>.Empty());
		Assert.AreEqual(Maybe<string>.Create("banana"), "banana".ToMaybe());
		Assert.AreNotEqual(Maybe<int>.Create(293921), Maybe<int>.Create(2));
	}

	[Test]
	public void MaybeNullableTests()
	{
		Assert.IsNull(Maybe<int>.Empty().ToNullable());
		Assert.IsNull(Maybe<int>.Create(0, _ => false).ToNullable());
	}
}