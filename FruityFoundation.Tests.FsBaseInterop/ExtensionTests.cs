using FruityFoundation.Base.Structures;
using FruityFoundation.FsBase;
using Microsoft.FSharp.Core;

namespace FruityFoundation.Tests.FsBaseInterop;

public class ExtensionTests
{
	[Test]
	public void Option_OfNone_ToMaybe_ReturnsEmptyMaybe()
	{
		// Arrange
		var option = FSharpOption<int>.None;

		// Act
		var result = option.ToMaybe();

		// Assert
		Assert.That(result, Is.InstanceOf<Maybe<int>>());
		Assert.That(result.HasValue, Is.False);
	}

	[Test]
	public void Option_OfSome_ToMaybe_ReturnsMaybe()
	{
		// Arrange
		var option = FSharpOption<int>.Some(25);

		// Act
		var result = option.ToMaybe();

		// Assert
		Assert.That(result, Is.InstanceOf<Maybe<int>>());
		Assert.That(result.HasValue, Is.True);
		Assert.That(result.Value, Is.EqualTo(25));
	}

	[Test]
	public void ValueOption_OfNone_ToMaybe_ReturnsEmptyMaybe()
	{
		// Arrange
		var option = FSharpValueOption<int>.None;

		// Act
		var result = option.ToMaybe();

		// Assert
		Assert.That(result, Is.InstanceOf<Maybe<int>>());
		Assert.That(result.HasValue, Is.False);
	}

	[Test]
	public void ValueOption_OfSome_ToMaybe_ReturnsMaybe()
	{
		// Arrange
		var option = FSharpValueOption<int>.Some(25);

		// Act
		var result = option.ToMaybe();

		// Assert
		Assert.That(result, Is.InstanceOf<Maybe<int>>());
		Assert.That(result.HasValue, Is.True);
		Assert.That(result.Value, Is.EqualTo(25));
	}

	[Test]
	public void EmptyMaybe_ToOption_ReturnsNone()
	{
		// Arrange
		var maybe = Maybe.Empty<int>();

		// Act
		var result = maybe.ToOption();

		// Assert
		Assert.That(result, Is.EqualTo(FSharpOption<int>.None));
	}

	[Test]
	public void Maybe_ToOption_ReturnsSome()
	{
		// Arrange
		var maybe = Maybe.Create(25);

		// Act
		var result = maybe.ToOption();

		// Assert
		Assert.That(result, Is.EqualTo(FSharpOption<int>.Some(25)));
	}

	[Test]
	public void EmptyMaybe_ToValueOption_ReturnsNone()
	{
		// Arrange
		var maybe = Maybe.Empty<int>();

		// Act
		var result = maybe.ToValueOption();

		// Assert
		Assert.That(result, Is.EqualTo(FSharpValueOption<int>.None));
	}

	[Test]
	public void Maybe_ToValueOption_ReturnsSome()
	{
		// Arrange
		var maybe = Maybe.Create(25);

		// Act
		var result = maybe.ToValueOption();

		// Assert
		Assert.That(result, Is.EqualTo(FSharpValueOption<int>.Some(25)));
	}
}
