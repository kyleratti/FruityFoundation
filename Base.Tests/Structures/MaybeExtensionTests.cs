using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using FruityFoundation.Base.Structures;
using NUnit.Framework;

namespace Base.Tests.Structures;

public class MaybeExtensionTests
{
	[Test]
	public void Enumerable_FirstOrEmpty_WithEmptyEnumerable_ReturnsEmptyMaybe()
	{
		// Arrange
		var data = Array.Empty<int>();

		// Act
		var result = data.FirstOrEmpty();

		// Assert
		Assert.That(result, Is.InstanceOf<Maybe<int>>());
		Assert.That(result.HasValue, Is.False);
	}

	[Test]
	public void Enumerable_FirstOrEmpty_WithMatchingPredicate_ReturnsMaybeWithValue()
	{
		// Arrange
		var data = new[] { 1, 2, 3, 4 };

		// Act
		var result = data.FirstOrEmpty(x => x > 1);

		// Assert
		Assert.That(result, Is.InstanceOf<Maybe<int>>());
		Assert.That(result.HasValue, Is.True);
		Assert.That(result.Value, Is.EqualTo(2));
	}

	[Test]
	public void Enumerable_FirstOrEmpty_WithNonMatchingPredicate_ReturnsEmptyMaybe()
	{
		// Arrange
		var data = new[] { 1, 2, 3, 4 };

		// Act
		var result = data.FirstOrEmpty(x => x > 100);

		// Assert
		Assert.That(result, Is.InstanceOf<Maybe<int>>());
		Assert.That(result.HasValue, Is.False);
	}

	[Test]
	public async Task Enumerable_FirstOrEmptyAsync_WithEmptyEnumerable_ReturnsEmptyMaybe()
	{
		// Arrange
		var data = ToAsyncEnumerable(Array.Empty<int>());

		// Act
		var result = await data.FirstOrEmptyAsync();

		// Assert
		Assert.That(result, Is.InstanceOf<Maybe<int>>());
		Assert.That(result.HasValue, Is.False);
	}

	[Test]
	public async Task Enumerable_FirstOrEmptyAsync_WithMatchingPredicate_ReturnsMaybeWithValue()
	{
		// Arrange
		var data = ToAsyncEnumerable([1, 2, 3, 4]);

		// Act
		var result = await data.FirstOrEmptyAsync(x => x > 1);

		// Assert
		Assert.That(result, Is.InstanceOf<Maybe<int>>());
		Assert.That(result.HasValue, Is.True);
		Assert.That(result.Value, Is.EqualTo(2));
	}

	[Test]
	public async Task Enumerable_FirstOrEmptyAsync_WithMatchingAsyncPredicate_ReturnsMaybeWithValue()
	{
		// Arrange
		var data = ToAsyncEnumerable([1, 2, 3, 4]);

		// Act
		var result = await data.FirstOrEmptyAsync(async x =>
		{
			await Task.Yield();
			return x > 1;
		});

		// Assert
		Assert.That(result, Is.InstanceOf<Maybe<int>>());
		Assert.That(result.HasValue, Is.True);
		Assert.That(result.Value, Is.EqualTo(2));
	}

	[Test]
	public async Task Enumerable_FirstOrEmptyAsync_WithNonMatchingPredicate_ReturnsEmptyMaybe()
	{
		// Arrange
		var data = ToAsyncEnumerable([1, 2, 3, 4]);

		// Act
		var result = await data.FirstOrEmptyAsync(x => x > 100);

		// Assert
		Assert.That(result, Is.InstanceOf<Maybe<int>>());
		Assert.That(result.HasValue, Is.False);
	}

	[Test]
	public async Task Enumerable_FirstOrEmptyAsync_WithNonMatchingAsyncPredicate_ReturnsEmptyMaybe()
	{
		// Arrange
		var data = ToAsyncEnumerable([1, 2, 3, 4]);

		// Act
		var result = await data.FirstOrEmptyAsync(async x =>
		{
			await Task.Yield();
			return x > 100;
		});

		// Assert
		Assert.That(result, Is.InstanceOf<Maybe<int>>());
		Assert.That(result.HasValue, Is.False);
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

	private static async IAsyncEnumerable<T> ToAsyncEnumerable<T>(IEnumerable<T> enumerable)
	{
		foreach (var item in enumerable)
			yield return item;

		await Task.Yield();
	}
}
