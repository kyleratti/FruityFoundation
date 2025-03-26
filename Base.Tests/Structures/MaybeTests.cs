using System;
using FruityFoundation.Base.Structures;
using NUnit.Framework;

namespace Base.Tests.Structures;

public class MaybeTests
{
	[Test]
	public void TestBind_DoesNotBindEmptyValue()
	{
		var emptyMaybe = Maybe.Empty<int>();

		var result = emptyMaybe.Bind(x => Maybe.Create(x + 1));

		Assert.That(result, Is.InstanceOf<Maybe<int>>());
		Assert.That(result.HasValue, Is.False);
	}

	[Test]
	public void TestBind_BindsWhenHasValue()
	{
		var emptyMaybe = Maybe.Create<int>(1);

		var result = emptyMaybe.Bind(x => Maybe.Create(x + 1));

		Assert.That(result, Is.InstanceOf<Maybe<int>>());
		Assert.That(result.HasValue, Is.True);
		Assert.That(result.Value, Is.EqualTo(2));
	}

	[Test]
	public void TestBind_BindsWhenHasValue_NewOutputType()
	{
		var maybe = Maybe.Create(25);

		var result = maybe.Bind(x => x switch
		{
			25 => Maybe.Create("twenty-five"),
			_ => Maybe.Empty<string>()
		});

		Assert.That(result, Is.InstanceOf<Maybe<string>>());
		Assert.That(result.HasValue, Is.True);
	}

	[Test]
	public void EmptyBind_DoesNotBindFactory_WhenHasValue()
	{
		var maybe = Maybe.Create(25);

		var result = maybe.EmptyBind(() => Maybe.Create(30));

		Assert.That(result, Is.InstanceOf<Maybe<int>>());
		Assert.That(result.HasValue, Is.True);
		Assert.That(result.Value, Is.EqualTo(25));
	}

	[Test]
	public void EmptyBind_BindsFactory_WhenDoesNotHaveValue()
	{
		var maybe = Maybe.Empty<int>();

		var result = maybe.EmptyBind(() => Maybe.Create(30));

		Assert.That(result, Is.InstanceOf<Maybe<int>>());
		Assert.That(result.HasValue, Is.True);
		Assert.That(result.Value, Is.EqualTo(30));
	}

	[Test]
	public void EmptyBind_DoesNotBindMaybe_WhenHasValue()
	{
		var maybe = Maybe.Create(25);

		var result = maybe.EmptyBind(Maybe.Create(30));

		Assert.That(result, Is.InstanceOf<Maybe<int>>());
		Assert.That(result.HasValue, Is.True);
		Assert.That(result.Value, Is.EqualTo(25));
	}

	[Test]
	public void EmptyBind_BindsMaybe_WhenDoesNotHaveValue()
	{
		var maybe = Maybe.Empty<int>();

		var result = maybe.EmptyBind(Maybe.Create(30));

		Assert.That(result, Is.InstanceOf<Maybe<int>>());
		Assert.That(result.HasValue, Is.True);
		Assert.That(result.Value, Is.EqualTo(30));
	}

	[Test]
	public void Cast_ToNullableReferenceType_ReturnsEmptyMaybe_WhenHasNoValue()
	{
		// Arrange
		var maybe = Maybe.Empty<string>();

		// Act
		var result = maybe.Cast<string?>();

		// Assert
		Assert.That(result, Is.InstanceOf<Maybe<string?>>());
		Assert.That(result.HasValue, Is.False);
	}

	[Test]
	public void Cast_ToNullableReferenceType_ReturnsMaybe_WhenHasValue()
	{
		// Arrange
		var maybe = Maybe.Create("banana");

		// Act
		var result = maybe.Cast<string?>();

		// Assert
		Assert.That(result, Is.InstanceOf<Maybe<string?>>());
		Assert.That(result.HasValue, Is.True);
		Assert.That(result.Value, Is.EqualTo("banana"));
	}

	[Test]
	public void Cast_ToNullableValueType_ReturnsEmptyMaybe_WhenHasNoValue()
	{
		// Arrange
		var maybe = Maybe.Empty<int>();

		// Act
		var result = maybe.Cast<string?>();

		// Assert
		Assert.That(result, Is.InstanceOf<Maybe<string?>>());
		Assert.That(result.HasValue, Is.False);
	}

	[Test]
	public void Cast_ToNullableValueType_ReturnsMaybe_WhenHasValue()
	{
		// Arrange
		var maybe = Maybe.Create(25);

		// Act
		var result = maybe.Cast<int?>();

		// Assert
		Assert.That(result, Is.InstanceOf<Maybe<int?>>());
		Assert.That(result.HasValue, Is.True);
		Assert.That(result.Value, Is.EqualTo(25));
	}

	[Test]
	public void Cast_ReturnsMaybe_WhenNewCastIsInvalid()
	{
		// Arrange
		var maybe = Maybe.Create(25);

		// Act
		var result = maybe.Cast<Array>();

		// Assert
		Assert.That(result, Is.InstanceOf<Maybe<Array>>());
		Assert.That(result.HasValue, Is.False);
	}

	[Test]
	public void Cast_ReturnsEmptyMaybe_WhenValueIsNull()
	{
		// Arrange
		var maybe = Maybe.Create((string?)null);

		// Act
		var result = maybe.Cast<string>();

		// Assert
		Assert.That(result, Is.InstanceOf<Maybe<string>>());
		Assert.That(result.HasValue, Is.False);
	}

	[Test]
	public void Maybe_ValueType_OrValue_ReturnsProvidedValue_WhenEmpty()
	{
		// Arrange
		var maybe = Maybe.Empty<int>();

		// Act
		var result = maybe.OrValue(25);

		// Assert
		Assert.That(result, Is.EqualTo(25));
	}

	[Test]
	public void Maybe_ValueType_OrValue_ReturnsValue_WhenNotEmpty()
	{
		// Arrange
		var maybe = Maybe.Create(25);

		// Act
		var result = maybe.OrValue(321);

		// Assert
		Assert.That(result, Is.EqualTo(25));
	}

	[Test]
	public void Maybe_ReferenceType_OrValue_ReturnsProvidedValue_WhenEmpty()
	{
		// Arrange
		var maybe = Maybe.Empty<string>();

		// Act
		var result = maybe.OrValue("banana");

		// Assert
		Assert.That(result, Is.EqualTo("banana"));
	}

	[Test]
	public void Maybe_ReferenceType_OrValue_ReturnsValue_WhenNotEmpty()
	{
		// Arrange
		var maybe = Maybe.Create("banana");

		// Act
		var result = maybe.OrValue("pears");

		// Assert
		Assert.That(result, Is.EqualTo("banana"));
	}

	[Test]
	public void Maybe_ValueType_OrValueFactory_ReturnsOrValue_WhenEmpty()
	{
		// Arrange
		var maybe = Maybe.Empty<int>();

		// Act
		var result = maybe.OrEval(() => 25);

		// Assert
		Assert.That(result, Is.EqualTo(25));
	}

	[Test]
	public void Maybe_ValueType_OrValueFactory_ReturnsOrValue_WhenNotEmpty()
	{
		// Arrange
		var maybe = Maybe.Create(25);

		// Act
		var result = maybe.OrEval(() => 321);

		// Assert
		Assert.That(result, Is.EqualTo(25));
	}

	[Test]
	public void Maybe_ReferenceType_OrValueFactory_ReturnsOrValue_WhenEmpty()
	{
		// Arrange
		var maybe = Maybe.Empty<string>();

		// Act
		var result = maybe.OrEval(() => "banana");

		// Assert
		Assert.That(result, Is.EqualTo("banana"));
	}

	[Test]
	public void Maybe_ReferenceType_OrValueFactory_ReturnsOrValue_WhenNotEmpty()
	{
		// Arrange
		var maybe = Maybe.Create("banana");

		// Act
		var result = maybe.OrEval(() => "pears");

		// Assert
		Assert.That(result, Is.EqualTo("banana"));
	}

	[Test]
	public void Maybe_Try_ReturnsFalse_OutputsDefault_WhenEmpty()
	{
		// Arrange
		var maybe = Maybe.Empty<string>();

		// Act
		string? output;
		var result = maybe.Try(out output);

		// Assert
		Assert.That(result, Is.False);
		Assert.That(output, Is.Default);
	}

	[Test]
	public void Maybe_Try_RetunsTrue_OutputsValue_WhenNotEmpty()
	{
		// Arrange
		var maybe = Maybe.Create("banana");

		// Act
		string? output;
		var result = maybe.Try(out output);

		// Assert
		Assert.That(result, Is.True);
		Assert.That(output, Is.EqualTo("banana"));
	}

	[Test]
	public void Maybe_OrThrow_ThrowsMessage_WhenEmpty()
	{
		// Arrange
		var maybe = Maybe.Empty<string>();

		// Act
		var result = Assert.Throws<ApplicationException>(() => maybe.OrThrow("This cannot be empty!"));

		// Assert
		Assert.That(result, Is.InstanceOf<ApplicationException>());
		Assert.That(result.Message, Is.EqualTo("This cannot be empty!"));
	}

	[Test]
	public void Maybe_OrThrow_ReturnsValue_WhenNotEmpty()
	{
		// Arrange
		var maybe = Maybe.Create("banana");

		// Act
		var result = maybe.OrThrow("This cannot be empty!");

		// Assert
		Assert.That(result, Is.EqualTo("banana"));
	}

	[Test]
	public void Maybe_OrThrowMessageFactory_ThrowsMessage_WhenEmpty()
	{
		// Arrange
		var maybe = Maybe.Empty<string>();

		// Act
		var result = Assert.Throws<ApplicationException>(() => maybe.OrThrow(messageFactory: () => "This cannot be empty!"));

		// Assert
		Assert.That(result, Is.InstanceOf<ApplicationException>());
		Assert.That(result.Message, Is.EqualTo("This cannot be empty!"));
	}

	[Test]
	public void Maybe_OrThrowMessageFactory_ReturnsValue_WhenNotEmpty()
	{
		// Arrange
		var maybe = Maybe.Create("banana");

		// Act
		var result = maybe.OrThrow(messageFactory: () => "This cannot be empty!");

		// Assert
		Assert.That(result, Is.EqualTo("banana"));
	}

	[Test]
	public void Maybe_OrThrowExceptionFactory_ThrowsMessage_WhenEmpty()
	{
		// Arrange
		var maybe = Maybe.Empty<string>();

		// Act
		var result = Assert.Throws<InvalidOperationException>(() => maybe.OrThrow(exFactory: () => new InvalidOperationException("This cannot be empty!")));

		// Assert
		Assert.That(result, Is.InstanceOf<InvalidOperationException>());
		Assert.That(result.Message, Is.EqualTo("This cannot be empty!"));
	}

	[Test]
	public void Maybe_OrThrowExceptionFactory_ReturnsValue_WhenNotEmpty()
	{
		// Arrange
		var maybe = Maybe.Create("banana");

		// Act
		var result = maybe.OrThrow(exFactory: () => new InvalidOperationException("This cannot be empty!"));

		// Assert
		Assert.That(result, Is.EqualTo("banana"));
	}

	[Test]
	public void Maybe_Map_ReturnsNewEmptyType_WhenEmpty()
	{
		// Arrange
		var maybe = Maybe.Empty<int>();

		// Act
		var result = maybe.Map(x => x.ToString());

		// Assert
		Assert.That(result.HasValue, Is.False);
	}

	[Test]
	public void Maybe_Map_ReturnsNewMaybeWithValue_WhenNotEmpty()
	{
		// Arrange
		var maybe = Maybe.Create(25);

		// Act
		var result = maybe.Map(x => x.ToString());

		// Assert
		Assert.That(result.HasValue, Is.True);
		Assert.That(result.Value, Is.EqualTo("25"));
	}

	[Test]
	public void Maybe_Value_Throws_WhenEmpty()
	{
		// Arrange
		var maybe = Maybe.Empty<string>();

		// Act
		var result = Assert.Throws<InvalidOperationException>(() => _ = maybe.Value);

		// Assert
		Assert.That(result, Is.InstanceOf<InvalidOperationException>());
		Assert.That(result.Message, Is.EqualTo("Maybe value is empty"));
	}

	[Test]
	public void Maybe_Value_ReturnsValue_WhenNotEmpty()
	{
		// Arrange
		var maybe = Maybe.Create("banana");

		// Act
		var result = maybe.Value;

		// Assert
		Assert.That(result, Is.EqualTo("banana"));
	}

	[Test]
	public void Maybe_ToString_ReturnsPlaceholder_WhenEmpty()
	{
		// Arrange
		var maybe = Maybe.Empty<string>();

		// Act
		var result = maybe.ToString();

		// Assert
		Assert.That(result, Is.EqualTo("<empty>"));
	}

	[Test]
	public void Maybe_ToString_ReturnsNullPlaceholder_WhenValueIsNull()
	{
		// Arrange
		var maybe = Maybe.Create((string?)null);

		// Act
		var result = maybe.ToString();

		// Assert
		Assert.That(result, Is.EqualTo("<null>"));
	}

	[Test]
	public void Maybe_ToString_ReturnsValue_WhenNotEmpty()
	{
		// Arrange
		var maybe = Maybe.Create("banana");

		// Act
		var result = maybe.ToString();

		// Assert
		Assert.That(result, Is.EqualTo("banana"));
	}

	[Test]
	public void Maybe_Create_ReturnsEmptyValue_WhenTryParseFails()
	{
		// Arrange
		const string input = "bananas";

		// Act
		var result = Maybe.TryParse<string, int>(input, int.TryParse);

		// Assert
		Assert.That(result, Is.InstanceOf<Maybe<int>>());
		Assert.That(result.HasValue, Is.False);
	}

	[Test]
	public void Maybe_Create_ReturnsValue_WhenTryParseSucceeds()
	{
		// Arrange
		const string input = "123";

		// Act
		var result = Maybe.TryParse<string, int>(input, int.TryParse);

		// Assert
		Assert.That(result, Is.InstanceOf<Maybe<int>>());
		Assert.That(result.HasValue, Is.True);
		Assert.That(result.Value, Is.EqualTo(123));
	}

	[Test]
	public void Filter_ReturnsEmptyMaybe_WhenPredicateIsTrue()
	{
		// Arrange
		var input = Maybe.Create("");
		static bool HasNonEmptyString(string x) => !string.IsNullOrEmpty(x);

		// Act
		var result = input.Filter(HasNonEmptyString);

		// Assert
		Assert.That(result.HasValue, Is.False);
	}

	[Test]
	public void Filter_ReturnsMaybeWithValue_WhenPredicateIsFalse()
	{
		// Arrange
		var input = Maybe.Create("banana");
		static bool HasNonEmptyString(string x) => !string.IsNullOrEmpty(x);

		// Act
		var result = input.Filter(HasNonEmptyString);

		// Assert
		Assert.That(result.HasValue, Is.True);
		Assert.That(result.Value, Is.EqualTo("banana"));
	}
}
