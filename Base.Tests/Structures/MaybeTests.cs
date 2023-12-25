using FruityFoundation.Base.Structures;
using NUnit.Framework;

namespace Base.Tests.Structures;

public class MaybeTests
{
	[Test]
	public void TestBind_DoesNotBindEmptyValue()
	{
		var emptyMaybe = Maybe.Empty<int>();

		var result = emptyMaybe.Bind(x => Maybe.Just(x + 1));

		Assert.That(result, Is.InstanceOf<Maybe<int>>());
		Assert.That(result.HasValue, Is.False);
	}

	[Test]
	public void TestBind_BindsWhenHasValue()
	{
		var emptyMaybe = Maybe.Just<int>(1);

		var result = emptyMaybe.Bind(x => Maybe.Just(x + 1));

		Assert.That(result, Is.InstanceOf<Maybe<int>>());
		Assert.That(result.HasValue, Is.True);
		Assert.That(result.Value, Is.EqualTo(2));
	}

	[Test]
	public void TestBind_BindsWhenHasValue_NewOutputType()
	{
		var maybe = Maybe.Just(25);

		var result = maybe.Bind(x => x switch
		{
			25 => Maybe.Just("twenty-five"),
			_ => Maybe.Empty<string>()
		});

		Assert.That(result, Is.InstanceOf<Maybe<string>>());
		Assert.That(result.HasValue, Is.True);
	}

	[Test]
	public void EmptyBind_DoesNotBindFactory_WhenHasValue()
	{
		var maybe = Maybe.Just(25);

		var result = maybe.EmptyBind(() => Maybe.Just(30));

		Assert.That(result, Is.InstanceOf<Maybe<int>>());
		Assert.That(result.HasValue, Is.True);
		Assert.That(result.Value, Is.EqualTo(25));
	}

	[Test]
	public void EmptyBind_BindsFactory_WhenDoesNotHaveValue()
	{
		var maybe = Maybe.Empty<int>();

		var result = maybe.EmptyBind(() => Maybe.Just(30));

		Assert.That(result, Is.InstanceOf<Maybe<int>>());
		Assert.That(result.HasValue, Is.True);
		Assert.That(result.Value, Is.EqualTo(30));
	}

	[Test]
	public void EmptyBind_DoesNotBindMaybe_WhenHasValue()
	{
		var maybe = Maybe.Just(25);

		var result = maybe.EmptyBind(Maybe.Just(30));

		Assert.That(result, Is.InstanceOf<Maybe<int>>());
		Assert.That(result.HasValue, Is.True);
		Assert.That(result.Value, Is.EqualTo(25));
	}

	[Test]
	public void EmptyBind_BindsMaybe_WhenDoesNotHaveValue()
	{
		var maybe = Maybe.Empty<int>();

		var result = maybe.EmptyBind(Maybe.Just(30));

		Assert.That(result, Is.InstanceOf<Maybe<int>>());
		Assert.That(result.HasValue, Is.True);
		Assert.That(result.Value, Is.EqualTo(30));
	}
}
