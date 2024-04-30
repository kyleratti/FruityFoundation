namespace FruityFoundation.Base.Structures;

using System;

public static class Maybe
{
	public static Maybe<T> Create<T>(T value) => new(value, hasValue: true);
	public static Maybe<T> Create<T>(T value, Func<T, bool> hasValue) => new(value, hasValue: hasValue(value));
	public static Maybe<T> Empty<T>() => new(val: default!, hasValue: false);
}

public readonly record struct Maybe<T>
{
	private readonly T _value;
	public readonly bool HasValue;

	internal Maybe(T val, bool hasValue)
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
		HasValue ? Maybe.Create(transformer(Value)) : Maybe.Empty<TOutput>();

	public Maybe<TOutput> Bind<TOutput>(Func<T, Maybe<TOutput>> binder) =>
		HasValue ? binder(Value) : Maybe.Empty<TOutput>();

	public Maybe<T> EmptyBind(Func<Maybe<T>> maybeFactory) =>
		HasValue ? this : maybeFactory();

	public Maybe<T> EmptyBind(Maybe<T> maybe) =>
		HasValue ? this : maybe;

	public Maybe<TOutput> Cast<TOutput>()
	{
		if (!HasValue)
			return Maybe.Empty<TOutput>();

		try
		{
			var t = typeof(TOutput);
			t = Nullable.GetUnderlyingType(t) ?? t;

			var output = Value == null
				? default
				: (TOutput)Convert.ChangeType(Value, t);

			return Maybe.Create(output, hasValue: _ => output != null)!;
		}
		catch (InvalidCastException)
		{
			return Maybe.Empty<TOutput>();
		}
	}

	public static implicit operator Maybe<T>(T val) => Maybe.Create(val);

	public static explicit operator T(Maybe<T> val) => val.Value;

	public override string ToString()
	{
		return (Try(out var val)
			? val?.ToString()
			: base.ToString())!;
	}
}
