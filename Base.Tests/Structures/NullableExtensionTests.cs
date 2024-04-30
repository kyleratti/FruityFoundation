using System.Linq;
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
		Assert.AreEqual(Maybe.Create(25), ((int?)25).ToMaybe());

	[Test]
	public void TestNullableReferenceOfNullAsMaybe()
	{
		string? nullableString = null;

		var result = nullableString.AsMaybe();

		Assert.That(result, Is.InstanceOf<Maybe<string>>());
		Assert.That(result.HasValue, Is.False);
	}

	[Test]
	public void TestNullableReferenceOfValueAsMaybe()
	{
		string? nullableString = "banana";

		var result = nullableString.AsMaybe();

		Assert.That(result, Is.InstanceOf<Maybe<string>>());
		Assert.That(result.HasValue, Is.True);
		Assert.That(result.Value, Is.EqualTo("banana"));
	}

	[Test]
	public void TestNullableReferenceAsMaybeWorksWithChoose()
	{
		string?[] stringCollection =
		[
			"banana",
			"bob",
			null
		];

		var result = stringCollection
			.Choose(x => x.AsMaybe())
			.ToArray();

		Assert.That(result, Is.InstanceOf<string[]>());
		Assert.That(result, Has.Length.EqualTo(2));
		Assert.That(result[0], Is.EqualTo("banana"));
		Assert.That(result[1], Is.EqualTo("bob"));
	}
}
