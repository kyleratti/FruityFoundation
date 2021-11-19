using CommonCore.Base.Extensions;
using CommonCore.Base.Structures;
using Microsoft.FSharp.Core;
using NUnit.Framework;

namespace Base.Tests.Extensions;

public class FSharpExtensionTests
{
	[Test]
	public void TestNoneIntToMaybe() =>
		Assert.AreEqual(Maybe<int>.Empty(), FSharpOption<int>.None.ToMaybe());

	[Test]
	public void TestSomeIntToMaybe() =>
		Assert.AreEqual(Maybe<int>.Create(25), FSharpOption<int>.Some(25).ToMaybe());
}