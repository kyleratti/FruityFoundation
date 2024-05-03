using System;
using FruityFoundation.Base.Structures;
using NUnit.Framework;

namespace Base.Tests.Structures;

public class ResultTests
{
	[Test]
	public void Result_CreateSuccess_ReturnsSuccess()
	{
		// Arrange
		var value = Result<int, string>.CreateSuccess(25);

		// Act
		var mergeResult = value.Merge(
			onSuccess: _ => "onSuccess",
			onFailure: _ => "onFailure");

		// Assert
		Assert.That(value, Is.InstanceOf<Result<int, string>>());
		Assert.That(value.IsSuccess, Is.True);
		Assert.That(value.IsFailure, Is.False);
		Assert.That(value.SuccessVal, Is.EqualTo(25));
		var failureValException = Assert.Throws<InvalidOperationException>(() => _ = value.FailureVal);
		Assert.That(failureValException.Message, Is.EqualTo("Maybe value is empty"));

		Assert.That(mergeResult, Is.EqualTo("onSuccess"));

		Assert.That(value.TrySuccess(out var successVal), Is.True);
		Assert.That(successVal, Is.EqualTo(25));

		Assert.That(value.TryFailure(out var failureVal), Is.False);
		Assert.That(failureVal, Is.Default);
	}

	[Test]
	public void Result_CreateFailure_ReturnsFailure()
	{
		// Arrange
		var value = Result<int, string>.CreateFailure("bananas aren't numbers");

		// Act
		var mergeResult = value.Merge(
			onSuccess: _ => "onSuccess",
			onFailure: _ => "onFailure");

		// Assert
		Assert.That(value, Is.InstanceOf<Result<int, string>>());
		Assert.That(value.IsSuccess, Is.False);
		Assert.That(value.IsFailure, Is.True);
		Assert.That(value.FailureVal, Is.EqualTo("bananas aren't numbers"));

		var successValException = Assert.Throws<InvalidOperationException>(() => _ = value.SuccessVal);
		Assert.That(successValException.Message, Is.EqualTo("Maybe value is empty"));

		Assert.That(mergeResult, Is.EqualTo("onFailure"));

		Assert.That(value.TrySuccess(out var successVal), Is.False);
		Assert.That(successVal, Is.Default);

		Assert.That(value.TryFailure(out var failureVal), Is.True);
		Assert.That(failureVal, Is.EqualTo("bananas aren't numbers"));
	}
}
