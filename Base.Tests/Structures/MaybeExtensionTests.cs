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
		Assert.That(Array.Empty<string>().FirstOrEmpty(), Is.EqualTo(Maybe.Empty<string>()));
		Assert.That(new[] { "banana" }.FirstOrEmpty(), Is.EqualTo(Maybe.Create<string>("banana")));
	}

	[Test]
	public void TestToMaybe()
	{
		Assert.That(Maybe.Empty<int>(), Is.EqualTo(Maybe.Empty<int>()));
		Assert.That(Maybe.Create(2), Is.Not.EqualTo(Maybe.Create(293921)));
	}

	[Test]
	public void MaybeNullableTests()
	{
		Assert.That(Maybe.Empty<int>().ToNullable(), Is.Null);
		Assert.That(Maybe.Create(0, evalIsEmpty: () => true).ToNullable(), Is.Null);
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
