using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

	[Test]
	public void IDictionaryTests_TryGetValue_ReturnsMaybeWithValue_ForValidKey()
	{
		var dict = new Dictionary<string, int>
		{
			{ "one", 1 },
			{ "two", 2 },
			{ "three", 3 }
		};

		var result = dict.TryGetValue("one");

		Assert.That(result, Is.InstanceOf<Maybe<int>>());
		Assert.That(result.HasValue, Is.True);
		Assert.That(result.Value, Is.EqualTo(1));
	}

	[Test]
	public void IDictionaryTests_TryGetValue_ReturnsEmptyMaybe_ForInvalidKey()
	{
		var dict = new Dictionary<string, int>
		{
			{ "one", 1 },
			{ "two", 2 },
			{ "three", 3 }
		};

		var result = dict.TryGetValue("eight");

		Assert.That(result, Is.InstanceOf<Maybe<int>>());
		Assert.That(result.HasValue, Is.False);
	}

	[Test]
	public void IReadOnlyDictionaryTests_TryGetValue_ReturnsMaybeWithValue_ForValidKey()
	{
		var baseDict = new Dictionary<string, int>
		{
			{ "one", 1 },
			{ "two", 2 },
			{ "three", 3 }
		};
		IReadOnlyDictionary<string, int> dict = new ReadOnlyDictionary<string, int>(baseDict);

		var result = dict.TryGet("one");

		Assert.That(result, Is.InstanceOf<Maybe<int>>());
		Assert.That(result.HasValue, Is.True);
		Assert.That(result.Value, Is.EqualTo(1));
	}

	[Test]
	public void IIReadOnlyDictionaryTests_TryGetValue_ReturnsEmptyMaybe_ForInvalidKey()
	{
		var baseDict = new Dictionary<string, int>
		{
			{ "one", 1 },
			{ "two", 2 },
			{ "three", 3 }
		};
		IReadOnlyDictionary<string, int> dict = new ReadOnlyDictionary<string, int>(baseDict);

		var result = dict.TryGet("eight");

		Assert.That(result, Is.InstanceOf<Maybe<int>>());
		Assert.That(result.HasValue, Is.False);
	}
}
