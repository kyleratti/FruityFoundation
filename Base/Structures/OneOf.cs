using System;

namespace FruityFoundation.Base.Structures;

public readonly record struct OneOf<T1, T2>
{
	private readonly Maybe<T1> _itemOne;
	private readonly Maybe<T2> _itemTwo;

	public T1 ItemOne => _itemOne.OrThrow($"{nameof(ItemOne)} must have a value in order to be accessed");
	public T2 ItemTwo => _itemTwo.OrThrow($"{nameof(ItemTwo)} must have a value in order to be accessed");

	/// <summary>
	/// Exposes the underlying object as an object.
	/// This is useful for pattern matching from C#.
	/// </summary>
	public object? RawItem
	{
		get
		{
			if (_itemOne.HasValue)
				return _itemOne.Value;
			else if (_itemTwo.HasValue)
				return _itemTwo.Value;

			// This is specifically a null and not a Maybe<object> so we can pattern match on it
			return null;
		}
	}

	public T Map<T>(Func<T1, T> itemOneMap, Func<T2, T> itemTwoMap)
	{
		if (_itemOne.Try(out var itemOne))
			return itemOneMap(itemOne);
		else if (_itemTwo.Try(out var itemTwo))
			return itemTwoMap(itemTwo);

		throw new NotImplementedException("Map condition not handled");
	}

	private OneOf(Maybe<T1> one, Maybe<T2> two)
	{
		_itemOne = one;
		_itemTwo = two;
	}

	public static implicit operator OneOf<T1, T2>(T1 oneOf) => new(oneOf, default);
	public static implicit operator OneOf<T1, T2>(T2 oneOf) => new(default, oneOf);
}

public class OneOf<T1, T2, T3>
{
	private readonly Maybe<T1> _itemOne;
	private readonly Maybe<T2> _itemTwo;
	private readonly Maybe<T3> _itemThree;

	public T1 ItemOne => _itemOne.OrThrow($"{nameof(ItemOne)} must have a value in order to be accessed");
	public T2 ItemTwo => _itemTwo.OrThrow($"{nameof(ItemTwo)} must have a value in order to be accessed");
	public T3 ItemThree => _itemThree.OrThrow($"{nameof(ItemThree)} must have a value in order to be accessed");

	/// <summary>
	/// Exposes the underlying object as an object.
	/// This is useful for pattern matching from C#.
	/// </summary>
	public object? RawItem
	{
		get
		{
			if (_itemOne.HasValue)
				return _itemOne.Value;
			else if (_itemTwo.HasValue)
				return _itemTwo.Value;
			else if (_itemThree.HasValue)
				return _itemThree.Value;

			// This is specifically a null and not a Maybe<object> so we can pattern match on it
			return null;
		}
	}

	public T Map<T>(Func<T1, T> itemOneMap, Func<T2, T> itemTwoMap, Func<T3, T> itemThreeMap)
	{
		if (_itemOne.Try(out var itemOne))
			return itemOneMap(itemOne);
		else if (_itemTwo.Try(out var itemTwo))
			return itemTwoMap(itemTwo);
		else if (_itemThree.Try(out var itemThree))
			return itemThreeMap(itemThree);

		throw new NotImplementedException("Map condition not handled");
	}

	public Type? ItemType
	{
		get
		{
			if (_itemOne.HasValue)
				return typeof(T1);
			else if (_itemTwo.HasValue)
				return typeof(T2);
			else if (_itemThree.HasValue)
				return typeof(T3);

			// This is specifically a null and not a Maybe<Type> so we can pattern match on it
			return null;
		}
	}

	private OneOf(Maybe<T1> one, Maybe<T2> two, Maybe<T3> three)
	{
		_itemOne = one;
		_itemTwo = two;
		_itemThree = three;
	}

	public static implicit operator OneOf<T1, T2, T3>(T1 oneOf) => new(oneOf, default, default);
	public static implicit operator OneOf<T1, T2, T3>(T2 oneOf) => new(default, oneOf, default);
	public static implicit operator OneOf<T1, T2, T3>(T3 oneOf) => new(default, default, oneOf);
}
