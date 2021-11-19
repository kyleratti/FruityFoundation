// Normally we wouldn't want to disable Nullable references, but in this case we want to.
// We're assuming that if you're following CouldBe conventions, you won't be hitting null ref exceptions.
#pragma warning disable CS8601
namespace CommonCore.Base.Structures;

[Serializable]
public struct CouldBe<T>
{
	private readonly T _value { get; init; }

	private CouldBe(T val = default!, bool hasValue = true)
	{
		_value = val;
		HasValue = hasValue;
	}

	public T Value
	{
		get
		{
			if (!HasValue)
				throw new InvalidOperationException("CouldBe value is empty");

			return _value;
		}
	}

	public bool HasValue { get; }

	public T Or(T orVal) =>
		HasValue ? Value : orVal;

	public bool Try(out T val)
	{
		val = HasValue ? Value : default;

		return HasValue;
	}

	public T ValueOrThrow(string msg) =>
		HasValue
			? Value
			: throw new Exception(msg);

	public CouldBe<TL> CouldTransform<TL>(Func<T, TL> transformer) =>
		HasValue
			? CouldBe<TL>.Create(transformer(Value))
			: CouldBe<TL>.Empty();

	public TL Transform<TL>(Func<T, TL> transformer) =>
		transformer(Value);

	public object ToDbValue() =>
		HasValue && Value is not null ? Value! : DBNull.Value;

	public static CouldBe<T> Create(T val) =>
		new(val, hasValue: true);

	public static CouldBe<T> Create(T val, Func<T, bool> isEmpty) =>
		new(val, hasValue: !isEmpty(val));

	public static CouldBe<T> Empty() =>
		new(default!, hasValue: false);

	public static implicit operator CouldBe<T>(T val) =>
		Create(val);

	public static explicit operator T(CouldBe<T> val) =>
		val.Value;

	public override string ToString()
	{
		return (Try(out var val)
			? val?.ToString()
			: base.ToString())!;
	}
}
