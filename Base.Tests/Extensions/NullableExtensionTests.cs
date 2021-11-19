using CommonCore.Base.Extensions;
using CommonCore.Base.Structures;
using NUnit.Framework;

namespace Base.Tests.Extensions;

public class NullableExtensionTests
{
	[Test]
	public void TestNullableStructOfNullToMaybe() =>
		Assert.AreEqual(Maybe<int>.Empty(), ((int?)null).ToMaybe());
	
	[Test]
	public void TestNullableStructOfValueToMaybe() =>
		Assert.AreEqual(Maybe<int>.Create(25), ((int?)25).ToMaybe());

	[Test]
	public void TestNullableRefOfNullToMaybe() =>
		Assert.AreEqual(Maybe<object>.Empty(), ((object?)null).ToMaybe());
	
	[Test]
	public void TestNullableRefOfValueToMaybe() =>
		Assert.AreEqual(Maybe<object>.Create(new {}), ((object?)new {}).ToMaybe());
}