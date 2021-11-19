using System;
using CommonCore.Base.Extensions;
using CommonCore.Base.Structures;
using Microsoft.FSharp.Core;
using NUnit.Framework;

namespace Base.Tests.Extensions;

public class CouldBeExtensionTests
{
	[Test]
	public void EnumerableFirstOrEmptyTests()
	{
		Assert.AreEqual(CouldBe<string>.Empty(), Array.Empty<string>().FirstOrEmpty());
		Assert.AreEqual(CouldBe<string>.Create("banana"), new[] { "banana" }.FirstOrEmpty());
	}

	[Test]
	public void ToCouldBeTests()
	{
		Assert.AreEqual(CouldBe<int>.Empty(), CouldBe<int>.Empty());
		Assert.AreEqual(CouldBe<string>.Create("banana"), "banana".ToCouldBe());
		Assert.AreNotEqual(CouldBe<int>.Create(293921), CouldBe<int>.Create(2));
	}

	[Test]
	public void CouldBeToNullableTests()
	{
		Assert.IsNull(CouldBe<int>.Empty().ToNullable());
		Assert.IsNotNull(CouldBe<int>.Create(-1));
		Assert.IsNull(CouldBe<int>.Create(0, _ => true).ToNullable());
	}

	[Test]
	public void CouldBeToFSharpOptionTests()
	{
		Assert.AreEqual(FSharpOption<string>.Some("banana"), CouldBe<string>.Create("banana").ToOption());
		Assert.AreEqual(FSharpOption<string>.None, CouldBe<string>.Empty().ToOption());
	}
}