// Normally we wouldn't want to disable Nullable references, but in this case we want to.
// We're assuming that if you're following Maybe conventions, you won't be hitting null ref exceptions.
#pragma warning disable CS8601
namespace CommonCore.Base.Structures;

[Serializable]
public struct Maybe<T>
{
	private readonly T _value;
	public readonly bool HasValue;

	private Maybe(T val = default!, bool hasValue = true)
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

	public T OrValue(T orVal) =>
		HasValue ? Value : orVal;

	public bool Try(out T val)
	{
		val = HasValue ? Value : default;

		return HasValue;
	}

	public T OrThrow(string msg) =>
		HasValue ? Value : throw new Exception(msg);

	public Maybe<TOutput> Map<TOutput>(Func<T, TOutput> transformer) =>
		HasValue
			? Maybe<TOutput>.Create(transformer(Value))
			: Maybe<TOutput>.Empty();

	public object ToDbValue() =>
		HasValue && Value is not null
			? Value
			: DBNull.Value;

	public static Maybe<T> Create(T val, bool hasValue = true) => new(val, hasValue);

	public static Maybe<T> Create(T val, Func<T, bool> hasValue) => new(val, hasValue(val));

	public static Maybe<T> Empty() => new(default!, hasValue: false);

	public static implicit operator Maybe<T>(T val) => Create(val);

	public static explicit operator T(Maybe<T> val) => val.Value;

	public override string ToString()
	{
		return (Try(out var val)
			? val?.ToString()
			: base.ToString())!;
	}
}
