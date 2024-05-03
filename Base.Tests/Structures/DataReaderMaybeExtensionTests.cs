using System;
using System.Data;
using FakeItEasy;
using FruityFoundation.Base.Structures;
using NUnit.Framework;

namespace Base.Tests.Structures;

public class DataReaderMaybeExtensionTests
{
	[Test]
	public void DataReader_TryGetBoolean_WithDbNull_ReturnsEmptyMaybe()
	{
		// Arrange
		var fakeDataReader = A.Fake<IDataReader>();
		A.CallTo(() => fakeDataReader.IsDBNull(0))
			.Returns(true);

		// Act
		var result = fakeDataReader.TryGetBoolean(0);

		// Assert
		Assert.That(result, Is.InstanceOf<Maybe<bool>>());
		Assert.That(result.HasValue, Is.False);
	}

	[Test]
	public void DataReader_TryGetBoolean_WithValue_ReturnsMaybeWithValue()
	{
		// Arrange
		var fakeDataReader = A.Fake<IDataReader>();
		A.CallTo(() => fakeDataReader.IsDBNull(0))
			.Returns(false);
		A.CallTo(() => fakeDataReader.GetBoolean(0))
			.Returns(true);

		// Act
		var result = fakeDataReader.TryGetBoolean(0);

		// Assert
		Assert.That(result, Is.InstanceOf<Maybe<bool>>());
		Assert.That(result.HasValue, Is.True);
		Assert.That(result.Value, Is.EqualTo(true));
	}

	[Test]
	public void DataReader_TryGetByte_WithDbNull_ReturnsEmptyMaybe()
	{
		// Arrange
		var fakeDataReader = A.Fake<IDataReader>();
		A.CallTo(() => fakeDataReader.IsDBNull(0))
			.Returns(true);

		// Act
		var result = fakeDataReader.TryGetByte(0);

		// Assert
		Assert.That(result, Is.InstanceOf<Maybe<byte>>());
		Assert.That(result.HasValue, Is.False);
	}

	[Test]
	public void DataReader_TryGetByte_WithValue_ReturnsMaybeWithValue()
	{
		// Arrange
		var fakeDataReader = A.Fake<IDataReader>();
		A.CallTo(() => fakeDataReader.IsDBNull(0))
			.Returns(false);
		A.CallTo(() => fakeDataReader.GetByte(0))
			.Returns((byte)25);

		// Act
		var result = fakeDataReader.TryGetByte(0);

		// Assert
		Assert.That(result, Is.InstanceOf<Maybe<byte>>());
		Assert.That(result.HasValue, Is.True);
		Assert.That(result.Value, Is.EqualTo((byte)25));
	}

	[Test]
	public void DataReader_TryGetBytes_WithDbNull_ReturnsEmptyMaybe()
	{
		// Arrange
		var fakeDataReader = A.Fake<IDataReader>();
		A.CallTo(() => fakeDataReader.IsDBNull(0))
			.Returns(true);

		// Act
		var result = fakeDataReader.TryGetBytes(0, 0, null, 0, 0);

		// Assert
		Assert.That(result, Is.InstanceOf<Maybe<long>>());
		Assert.That(result.HasValue, Is.False);
	}

	[Test]
	public void DataReader_TryGetBytes_WithValue_ReturnsMaybeWithValue()
	{
		// Arrange
		var fakeDataReader = A.Fake<IDataReader>();
		A.CallTo(() => fakeDataReader.IsDBNull(0))
			.Returns(false);
		A.CallTo(() => fakeDataReader.GetBytes(0, 0, A<byte[]>._, 0, 0))
			.Returns(25);

		// Act
		var result = fakeDataReader.TryGetBytes(0, 0, [], 0, 0);

		// Assert
		Assert.That(result, Is.InstanceOf<Maybe<long>>());
		Assert.That(result.HasValue, Is.True);
		Assert.That(result.Value, Is.EqualTo(25));
	}

	[Test]
	public void DataReader_TryGetChars_WithDbNull_ReturnsEmptyMaybe()
	{
		// Arrange
		var fakeDataReader = A.Fake<IDataReader>();
		A.CallTo(() => fakeDataReader.IsDBNull(0))
			.Returns(true);

		// Act
		var result = fakeDataReader.TryGetChars(0, 0, null, 0, 0);

		// Assert
		Assert.That(result, Is.InstanceOf<Maybe<long>>());
		Assert.That(result.HasValue, Is.False);
	}

	[Test]
	public void DataReader_TryGetChars_WithValue_ReturnsMaybeWithValue()
	{
		// Arrange
		var fakeDataReader = A.Fake<IDataReader>();
		A.CallTo(() => fakeDataReader.IsDBNull(0))
			.Returns(false);
		A.CallTo(() => fakeDataReader.GetChars(0, 0, A<char[]>._, 0, 0))
			.Returns(25);

		// Act
		var result = fakeDataReader.TryGetChars(0, 0, [], 0, 0);

		// Assert
		Assert.That(result, Is.InstanceOf<Maybe<long>>());
		Assert.That(result.HasValue, Is.True);
		Assert.That(result.Value, Is.EqualTo(25));
	}

	[Test]
	public void DataReader_TryGetDateTime_WithDbNull_ReturnsEmptyMaybe()
	{
		// Arrange
		var fakeDataReader = A.Fake<IDataReader>();
		A.CallTo(() => fakeDataReader.IsDBNull(0))
			.Returns(true);

		// Act
		var result = fakeDataReader.TryGetDateTime(0);

		// Assert
		Assert.That(result, Is.InstanceOf<Maybe<DateTime>>());
		Assert.That(result.HasValue, Is.False);
	}

	[Test]
	public void DataReader_TryGetDateTime_WithValue_ReturnsMaybeWithValue()
	{
		// Arrange
		var fakeDataReader = A.Fake<IDataReader>();
		A.CallTo(() => fakeDataReader.IsDBNull(0))
			.Returns(false);
		A.CallTo(() => fakeDataReader.GetDateTime(0))
			.Returns(new DateTime(2024, 05, 03, 17, 21, 0, DateTimeKind.Utc));

		// Act
		var result = fakeDataReader.TryGetDateTime(0);

		// Assert
		Assert.That(result, Is.InstanceOf<Maybe<DateTime>>());
		Assert.That(result.HasValue, Is.True);
		Assert.That(result.Value, Is.EqualTo(new DateTime(2024, 05, 03, 17, 21, 0, DateTimeKind.Utc)));
	}

	[Test]
	public void DataReader_TryGetDecimal_WithDbNull_ReturnsEmptyMaybe()
	{
		// Arrange
		var fakeDataReader = A.Fake<IDataReader>();
		A.CallTo(() => fakeDataReader.IsDBNull(0))
			.Returns(true);

		// Act
		var result = fakeDataReader.TryGetDecimal(0);

		// Assert
		Assert.That(result, Is.InstanceOf<Maybe<decimal>>());
		Assert.That(result.HasValue, Is.False);
	}

	[Test]
	public void DataReader_TryGetDecimal_WithValue_ReturnsMaybeWithValue()
	{
		// Arrange
		var fakeDataReader = A.Fake<IDataReader>();
		A.CallTo(() => fakeDataReader.IsDBNull(0))
			.Returns(false);
		A.CallTo(() => fakeDataReader.GetDecimal(0))
			.Returns(25.0m);

		// Act
		var result = fakeDataReader.TryGetDecimal(0);

		// Assert
		Assert.That(result, Is.InstanceOf<Maybe<decimal>>());
		Assert.That(result.HasValue, Is.True);
		Assert.That(result.Value, Is.EqualTo(25.0m));
	}

	[Test]
	public void DataReader_TryGetFloat_WithDbNull_ReturnsEmptyMaybe()
	{
		// Arrange
		var fakeDataReader = A.Fake<IDataReader>();
		A.CallTo(() => fakeDataReader.IsDBNull(0))
			.Returns(true);

		// Act
		var result = fakeDataReader.TryGetFloat(0);

		// Assert
		Assert.That(result, Is.InstanceOf<Maybe<float>>());
		Assert.That(result.HasValue, Is.False);
	}

	[Test]
	public void DataReader_TryGetFloat_WithValue_ReturnsMaybeWithValue()
	{
		// Arrange
		var fakeDataReader = A.Fake<IDataReader>();
		A.CallTo(() => fakeDataReader.IsDBNull(0))
			.Returns(false);
		A.CallTo(() => fakeDataReader.GetFloat(0))
			.Returns(25.0f);

		// Act
		var result = fakeDataReader.TryGetFloat(0);

		// Assert
		Assert.That(result, Is.InstanceOf<Maybe<float>>());
		Assert.That(result.HasValue, Is.True);
		Assert.That(result.Value, Is.EqualTo(25.0f));
	}

	[Test]
	public void DataReader_TryGetGuid_WithDbNull_ReturnsEmptyMaybe()
	{
		// Arrange
		var fakeDataReader = A.Fake<IDataReader>();
		A.CallTo(() => fakeDataReader.IsDBNull(0))
			.Returns(true);

		// Act
		var result = fakeDataReader.TryGetGuid(0);

		// Assert
		Assert.That(result, Is.InstanceOf<Maybe<Guid>>());
		Assert.That(result.HasValue, Is.False);
	}

	[Test]
	public void DataReader_TryGetGuid_WithValue_ReturnsMaybeWithValue()
	{
		// Arrange
		var fakeDataReader = A.Fake<IDataReader>();
		A.CallTo(() => fakeDataReader.IsDBNull(0))
			.Returns(false);
		A.CallTo(() => fakeDataReader.GetGuid(0))
			.Returns(Guid.NewGuid());

		// Act
		var result = fakeDataReader.TryGetGuid(0);

		// Assert
		Assert.That(result, Is.InstanceOf<Maybe<Guid>>());
		Assert.That(result.HasValue, Is.True);
		Assert.That(result.Value, Is.Not.EqualTo(Guid.Empty));
	}

	[Test]
	public void DataReader_TryGetInt16_WithDbNull_ReturnsEmptyMaybe()
	{
		// Arrange
		var fakeDataReader = A.Fake<IDataReader>();
		A.CallTo(() => fakeDataReader.IsDBNull(0))
			.Returns(true);

		// Act
		var result = fakeDataReader.TryGetInt16(0);

		// Assert
		Assert.That(result, Is.InstanceOf<Maybe<short>>());
		Assert.That(result.HasValue, Is.False);
	}

	[Test]
	public void DataReader_TryGetInt16_WithValue_ReturnsMaybeWithValue()
	{
		// Arrange
		var fakeDataReader = A.Fake<IDataReader>();
		A.CallTo(() => fakeDataReader.IsDBNull(0))
			.Returns(false);
		A.CallTo(() => fakeDataReader.GetInt16(0))
			.Returns((short)25);

		// Act
		var result = fakeDataReader.TryGetInt16(0);

		// Assert
		Assert.That(result, Is.InstanceOf<Maybe<short>>());
		Assert.That(result.HasValue, Is.True);
		Assert.That(result.Value, Is.EqualTo((short)25));
	}

	[Test]
	public void DataReader_TryGetInt32_WithDbNull_ReturnsEmptyMaybe()
	{
		// Arrange
		var fakeDataReader = A.Fake<IDataReader>();
		A.CallTo(() => fakeDataReader.IsDBNull(0))
			.Returns(true);

		// Act
		var result = fakeDataReader.TryGetInt32(0);

		// Assert
		Assert.That(result, Is.InstanceOf<Maybe<int>>());
		Assert.That(result.HasValue, Is.False);
	}

	[Test]
	public void DataReader_TryGetInt32_WithValue_ReturnsMaybeWithValue()
	{
		// Arrange
		var fakeDataReader = A.Fake<IDataReader>();
		A.CallTo(() => fakeDataReader.IsDBNull(0))
			.Returns(false);
		A.CallTo(() => fakeDataReader.GetInt32(0))
			.Returns(25);

		// Act
		var result = fakeDataReader.TryGetInt32(0);

		// Assert
		Assert.That(result, Is.InstanceOf<Maybe<int>>());
		Assert.That(result.HasValue, Is.True);
		Assert.That(result.Value, Is.EqualTo(25));
	}

	[Test]
	public void DataReader_TryGetInt64_WithDbNull_ReturnsEmptyMaybe()
	{
		// Arrange
		var fakeDataReader = A.Fake<IDataReader>();
		A.CallTo(() => fakeDataReader.IsDBNull(0))
			.Returns(true);

		// Act
		var result = fakeDataReader.TryGetInt64(0);

		// Assert
		Assert.That(result, Is.InstanceOf<Maybe<long>>());
		Assert.That(result.HasValue, Is.False);
	}

	[Test]
	public void DataReader_TryGetInt64_WithValue_ReturnsMaybeWithValue()
	{
		// Arrange
		var fakeDataReader = A.Fake<IDataReader>();
		A.CallTo(() => fakeDataReader.IsDBNull(0))
			.Returns(false);
		A.CallTo(() => fakeDataReader.GetInt64(0))
			.Returns(25);

		// Act
		var result = fakeDataReader.TryGetInt64(0);

		// Assert
		Assert.That(result, Is.InstanceOf<Maybe<long>>());
		Assert.That(result.HasValue, Is.True);
		Assert.That(result.Value, Is.EqualTo(25));
	}

	[Test]
	public void DataReader_TryGetString_WithDbNull_ReturnsEmptyMaybe()
	{
		// Arrange
		var fakeDataReader = A.Fake<IDataReader>();
		A.CallTo(() => fakeDataReader.IsDBNull(0))
			.Returns(true);

		// Act
		var result = fakeDataReader.TryGetString(0);

		// Assert
		Assert.That(result, Is.InstanceOf<Maybe<string>>());
		Assert.That(result.HasValue, Is.False);
	}

	[Test]
	public void DataReader_TryGetString_WithValue_ReturnsMaybeWithValue()
	{
		// Arrange
		var fakeDataReader = A.Fake<IDataReader>();
		A.CallTo(() => fakeDataReader.IsDBNull(0))
			.Returns(false);
		A.CallTo(() => fakeDataReader.GetString(0))
			.Returns("banana");

		// Act
		var result = fakeDataReader.TryGetString(0);

		// Assert
		Assert.That(result, Is.InstanceOf<Maybe<string>>());
		Assert.That(result.HasValue, Is.True);
		Assert.That(result.Value, Is.EqualTo("banana"));
	}
}
