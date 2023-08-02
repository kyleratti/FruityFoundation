namespace FruityFoundation.Base.Structures;

using System;

public static class Maybe
{
	public static Maybe<T> Just<T>(T value) => new(value, hasValue: true);
	public static Maybe<T> Just<T>(T value, Func<T, bool> hasValue) => new(value, hasValue: hasValue(value));
	public static Maybe<T> Empty<T>() => new(val: default!, hasValue: false);
}

public readonly struct Maybe<T>
{
	private readonly T _value;
	public readonly bool HasValue;

	internal Maybe(T val = default!, bool hasValue = true)
	{
		_value = val;
		HasValue = hasValue;
	}

	public T Value
	{
		get
		{
			if (!HasValue)
				throw new InvalidOperationException($"{nameof(Maybe<T>)} value is empty");

			return _value;
		}
	}

	public T OrValue(T orVal) => HasValue ? Value : orVal;

	public T OrEval(Func<T> valueFactory) => HasValue ? Value : valueFactory();

	public bool Try(out T val)
	{
		val = HasValue ? Value : default!;

		return HasValue;
	}

	public T OrThrow(string msg) =>
		HasValue ? Value : throw new Exception(msg);

	public T OrThrow(Func<string> messageFactory) =>
		HasValue ? Value : throw new Exception(messageFactory());

	public T OrThrow(Func<Exception> exFactory) =>
		HasValue ? Value : throw exFactory();

	public Maybe<TOutput> Map<TOutput>(Func<T, TOutput> transformer) =>
		HasValue ? Maybe.Just(transformer(Value)) : Maybe.Empty<TOutput>();

	public Maybe<TOutput> Bind<TOutput>(Func<T, TOutput> binder) =>
		HasValue ? binder(Value) : Maybe.Empty<TOutput>();

	public Maybe<TOutput> Cast<TOutput>()
	{
		if (!HasValue)
			return Maybe.Empty<TOutput>();

		try
		{
			return (TOutput)Convert.ChangeType(Value, typeof(TOutput))!;
		}
		catch (InvalidCastException)
		{
			return Maybe.Empty<TOutput>();
		}
	}

	public static implicit operator Maybe<T>(T val) => Maybe.Just(val);

	public static explicit operator T(Maybe<T> val) => val.Value;

	public override string ToString()
	{
		return (Try(out var val)
			? val?.ToString()
			: base.ToString())!;
	}
}
