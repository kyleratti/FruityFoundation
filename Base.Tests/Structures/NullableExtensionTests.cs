using FruityFoundation.Base.Structures;
using NUnit.Framework;

namespace Base.Tests.Structures;

public class NullableExtensionTests
{
	[Test]
	public void TestNullableStructOfNullToMaybe() =>
		Assert.AreEqual(Maybe.Empty<int>(), ((int?)null).ToMaybe());
	
	[Test]
	public void TestNullableStructOfValueToMaybe() =>
		Assert.AreEqual(Maybe.Just(25), ((int?)25).ToMaybe());
}
