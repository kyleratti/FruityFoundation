namespace FruityFoundation.Base.Structures;

using System;

public delegate bool TryParseDelegate<in TInput, TOutput>(TInput input, out TOutput output);

public static class Maybe
{
	public static Maybe<T> Create<T>(T value) => new(value);

	public static Maybe<T> Create<T>(T value, Func<bool> evalIsEmpty)
	{
		if (evalIsEmpty())
			return Maybe.Empty<T>();

		return new Maybe<T>(value);
	}

	public static Maybe<T> Create<T>(T value, Func<T, bool> evalIsEmpty)
	{
		if (evalIsEmpty(value))
			return Maybe.Empty<T>();

		return new Maybe<T>(value);
	}

	public static Maybe<TOutput> TryParse<TInput, TOutput>(TInput value, TryParseDelegate<TInput, TOutput> tryParse)
	{
		if (!tryParse(value, out var output))
			return Empty<TOutput>();

		return new Maybe<TOutput>(output);
	}

	public static Maybe<T> Empty<T>() => new();
}

public readonly record struct Maybe<T>
{
	private readonly T _value;
	public bool HasValue { get; }

	internal Maybe(T val) : this()
	{
		_value = val;
		HasValue = true;
	}

	/// <summary>
	/// The unwrapped value.
	/// </summary>
	/// <exception cref="InvalidOperationException">Thrown when the Maybe does not have a value.</exception>
	public T Value
	{
		get
		{
			if (!HasValue)
				throw new InvalidOperationException($"{nameof(Maybe<T>)} value is empty");

			return _value;
		}
	}

	public T OrValue(T orVal)
	{
		if (!HasValue)
			return orVal;

		return Value;
	}

	public T OrEval(Func<T> valueFactory)
	{
		if (!HasValue)
			return valueFactory();

		return Value;
	}

	public bool Try(out T val)
	{
		val = HasValue ? Value : default!;

		return HasValue;
	}

	public T OrThrow(string msg)
	{
		if (!HasValue)
			throw new ApplicationException(msg);

		return Value;
	}

	public T OrThrow(Func<string> messageFactory)
	{
		if (!HasValue)
			throw new ApplicationException(messageFactory());

		return Value;
	}

	public T OrThrow(Func<Exception> exFactory)
	{
		if (!HasValue)
			throw exFactory();

		return Value;
	}

	public Maybe<TOutput> Map<TOutput>(Func<T, TOutput> transformer)
	{
		if (!HasValue)
			return Maybe.Empty<TOutput>();

		var newValue = transformer(Value);
		return new Maybe<TOutput>(newValue);
	}

	public Maybe<TOutput> Bind<TOutput>(Func<T, Maybe<TOutput>> binder)
	{
		if (!HasValue)
			return Maybe.Empty<TOutput>();

		return binder(Value);
	}

	public Maybe<T> EmptyBind(Func<Maybe<T>> maybeFactory)
	{
		if (!HasValue)
			return maybeFactory();

		return this;
	}

	public Maybe<T> EmptyBind(Maybe<T> maybe)
	{
		if (!HasValue)
			return maybe;

		return this;
	}

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

			if (output == null)
				return Maybe.Empty<TOutput>();

			return Maybe.Create(output);
		}
		catch (InvalidCastException)
		{
			return Maybe.Empty<TOutput>();
		}
	}

	/// <summary>
	/// Filters the value contained in the Maybe.
	/// </summary>
	/// <param name="predicate">A function that evaluates whether the value contained in the Maybe should remain, or be filtered out.</param>
	/// <returns>The input if the predicate evaluates to true; otherwise, Empty.</returns>
	public Maybe<T> Filter(Func<T, bool> predicate)
	{
		if (!HasValue || !predicate(Value))
			return Maybe.Empty<T>();

		return this;
	}

	/// <summary>
	/// Tries to parse the current value into the specified type.
	/// </summary>
	/// <param name="tryParse">The delegate to use when trying to parse.</param>
	/// <typeparam name="TOutput">The target type</typeparam>
	/// <returns>
	/// If the maybe is already empty, an empty maybe of <typeparamref name="TOutput"/> is returned.
	/// If the try parse fails, an empty maybe of <typeparamref name="TOutput"/> is returned.
	/// If the try parse succeeds, a maybe with the parsed value of <typeparamref name="TOutput"/> is returned.
	/// </returns>
	public Maybe<TOutput> TryParse<TOutput>(TryParseDelegate<T, TOutput> tryParse)
	{
		if (!HasValue)
			return Maybe.Empty<TOutput>();

		if (!tryParse(Value, out var output))
			return Maybe.Empty<TOutput>();

		return new Maybe<TOutput>(output);
	}

	public static implicit operator Maybe<T>(T val) => Maybe.Create(val);

	public override string ToString()
	{
		if (!HasValue)
			return "<empty>";

		return _value?.ToString() ?? "<null>";
	}
}
