using System;

namespace FruityFoundation.Base.Structures;

public readonly struct Result<TSuccess, TFailure>
{
	private readonly Maybe<TSuccess> _successVal;
	private readonly Maybe<TFailure> _failureVal;

	private Result(Maybe<TSuccess> successVal, Maybe<TFailure> failureVal)
	{
		_successVal = successVal;
		_failureVal = failureVal;
	}

	public static Result<TSuccess, TFailure> CreateSuccess(TSuccess val) =>
		new(successVal: val, failureVal: Maybe.Empty<TFailure>());

	public static Result<TSuccess, TFailure> CreateFailure(TFailure val) =>
		new(successVal: Maybe.Empty<TSuccess>(), failureVal: val);

	public bool IsSuccess => _successVal.HasValue;
	public bool IsFailure => _failureVal.HasValue;

	public TSuccess SuccessVal => _successVal.Value;

	public TFailure FailureVal => _failureVal.Value;

	public bool TrySuccess(out TSuccess output)
	{
		if (!_successVal.Try(out output))
		{
			output = default!;
			return false;
		}

		return true;
	}

	public bool TryFailure(out TFailure output)
	{
		if (!_failureVal.Try(out output))
		{
			output = default!;
			return false;
		}

		return true;
	}

	public T Merge<T>(Func<TSuccess, T> onSuccess, Func<TFailure, T> onFailure) =>
		IsSuccess ? onSuccess(_successVal.Value) : onFailure(_failureVal.Value);
}
