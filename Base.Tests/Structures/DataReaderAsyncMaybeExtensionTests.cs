using System;
using System.Collections;
using System.Data.Common;
using System.Threading;
using System.Threading.Tasks;
using FruityFoundation.Base.Structures;
using NUnit.Framework;

namespace Base.Tests.Structures;

public class DataReaderAsyncMaybeExtensionTests
{
	[Test]
	public async Task DbDataReader_TryGetBooleanAsync_WithDbNull_ReturnsEmptyMaybe()
	{
		// Arrange
		var fakeDataReader = MockDbDataReader.Empty;

		// Act
		var result = await fakeDataReader.TryGetBooleanAsync(0);

		// Assert
		Assert.That(result, Is.InstanceOf<Maybe<bool>>());
		Assert.That(result.HasValue, Is.False);
	}

	[Test]
	public async Task DbDataReader_TryGetBooleanAsync_WithValue_ReturnsMaybeWithValue()
	{
		// Arrange
		var fakeDataReader = MockDbDataReader.WithBoolean(true);

		// Act
		var result = await fakeDataReader.TryGetBooleanAsync(0);

		// Assert
		Assert.That(result, Is.InstanceOf<Maybe<bool>>());
		Assert.That(result.HasValue, Is.True);
		Assert.That(result.Value, Is.EqualTo(true));
	}

	[Test]
	public async Task DbDataReader_TryGetByteAsync_WithDbNull_ReturnsEmptyMaybe()
	{
		// Arrange
		var fakeDataReader = MockDbDataReader.Empty;

		// Act
		var result = await fakeDataReader.TryGetByteAsync(0);

		// Assert
		Assert.That(result, Is.InstanceOf<Maybe<byte>>());
		Assert.That(result.HasValue, Is.False);
	}

	[Test]
	public async Task DbDataReader_TryGetByteAsync_WithValue_ReturnsMaybeWithValue()
	{
		// Arrange
		var fakeDataReader = MockDbDataReader.WithByte(25);

		// Act
		var result = await fakeDataReader.TryGetByteAsync(0);

		// Assert
		Assert.That(result, Is.InstanceOf<Maybe<byte>>());
		Assert.That(result.HasValue, Is.True);
		Assert.That(result.Value, Is.EqualTo((byte)25));
	}

	[Test]
	public async Task DbDataReader_TryGetBytesAsync_WithDbNull_ReturnsEmptyMaybe()
	{
		// Arrange
		var fakeDataReader = MockDbDataReader.Empty;

		// Act
		var result = await fakeDataReader.TryGetBytesAsync(0, 0, null, 0, 0);

		// Assert
		Assert.That(result, Is.InstanceOf<Maybe<long>>());
		Assert.That(result.HasValue, Is.False);
	}

	[Test]
	public async Task DbDataReader_TryGetBytesAsync_WithValue_ReturnsMaybeWithValue()
	{
		// Arrange
		var fakeDataReader = MockDbDataReader.WithBytes(25);

		// Act
		var result = await fakeDataReader.TryGetBytesAsync(0, 0, [], 0, 0);

		// Assert
		Assert.That(result, Is.InstanceOf<Maybe<long>>());
		Assert.That(result.HasValue, Is.True);
		Assert.That(result.Value, Is.EqualTo(25));
	}

	[Test]
	public async Task DbDataReader_TryGetCharAsync_WithDbNull_ReturnsEmptyMaybe()
	{
		// Arrange
		var fakeDataReader = MockDbDataReader.Empty;

		// Act
		var result = await fakeDataReader.TryGetCharAsync(0);

		// Assert
		Assert.That(result, Is.InstanceOf<Maybe<char>>());
		Assert.That(result.HasValue, Is.False);
	}

	[Test]
	public async Task DbDataReader_TryGetCharAsync_WithValue_ReturnsMaybeWithValue()
	{
		// Arrange
		var fakeDataReader = MockDbDataReader.WithChar('b');

		// Act
		var result = await fakeDataReader.TryGetCharAsync(0);

		// Assert
		Assert.That(result, Is.InstanceOf<Maybe<char>>());
		Assert.That(result.HasValue, Is.True);
		Assert.That(result.Value, Is.EqualTo('b'));
	}

	[Test]
	public async Task DbDataReader_TryGetCharsAsync_WithDbNull_ReturnsEmptyMaybe()
	{
		// Arrange
		var fakeDataReader = MockDbDataReader.Empty;

		// Act
		var result = await fakeDataReader.TryGetCharsAsync(0, 0, null, 0, 0);

		// Assert
		Assert.That(result, Is.InstanceOf<Maybe<long>>());
		Assert.That(result.HasValue, Is.False);
	}

	[Test]
	public async Task DbDataReader_TryGetCharsAsync_WithValue_ReturnsMaybeWithValue()
	{
		// Arrange
		var fakeDataReader = MockDbDataReader.WithChars(25);

		// Act
		var result = await fakeDataReader.TryGetCharsAsync(0, 0, [], 0, 0);

		// Assert
		Assert.That(result, Is.InstanceOf<Maybe<long>>());
		Assert.That(result.HasValue, Is.True);
		Assert.That(result.Value, Is.EqualTo(25));
	}

	[Test]
	public async Task DbDataReader_TryGetDateTimeAsync_WithDbNull_ReturnsEmptyMaybe()
	{
		// Arrange
		var fakeDataReader = MockDbDataReader.Empty;

		// Act
		var result = await fakeDataReader.TryGetDateTimeAsync(0);

		// Assert
		Assert.That(result, Is.InstanceOf<Maybe<DateTime>>());
		Assert.That(result.HasValue, Is.False);
	}

	[Test]
	public async Task DbDataReader_TryGetDateTimeAsync_WithValue_ReturnsMaybeWithValue()
	{
		// Arrange
		var fakeDataReader = MockDbDataReader.WithDateTime(new DateTime(2024, 05, 03, 17, 21, 0, DateTimeKind.Utc));

		// Act
		var result = await fakeDataReader.TryGetDateTimeAsync(0);

		// Assert
		Assert.That(result, Is.InstanceOf<Maybe<DateTime>>());
		Assert.That(result.HasValue, Is.True);
		Assert.That(result.Value, Is.EqualTo(new DateTime(2024, 05, 03, 17, 21, 0, DateTimeKind.Utc)));
	}

	[Test]
	public async Task DbDataReader_TryGetDecimalAsync_WithDbNull_ReturnsEmptyMaybe()
	{
		// Arrange
		var fakeDataReader = MockDbDataReader.Empty;

		// Act
		var result = await fakeDataReader.TryGetDecimalAsync(0);

		// Assert
		Assert.That(result, Is.InstanceOf<Maybe<decimal>>());
		Assert.That(result.HasValue, Is.False);
	}

	[Test]
	public async Task DbDataReader_TryGetDecimalAsync_WithValue_ReturnsMaybeWithValue()
	{
		// Arrange
		var fakeDataReader = MockDbDataReader.WithDecimal(25.0m);

		// Act
		var result = await fakeDataReader.TryGetDecimalAsync(0);

		// Assert
		Assert.That(result, Is.InstanceOf<Maybe<decimal>>());
		Assert.That(result.HasValue, Is.True);
		Assert.That(result.Value, Is.EqualTo(25.0m));
	}

	[Test]
	public async Task DbDataReader_TryGetFloatAsync_WithDbNull_ReturnsEmptyMaybe()
	{
		// Arrange
		var fakeDataReader = MockDbDataReader.Empty;

		// Act
		var result = await fakeDataReader.TryGetFloatAsync(0);

		// Assert
		Assert.That(result, Is.InstanceOf<Maybe<float>>());
		Assert.That(result.HasValue, Is.False);
	}

	[Test]
	public async Task DbDataReader_TryGetFloatAsync_WithValue_ReturnsMaybeWithValue()
	{
		// Arrange
		var fakeDataReader = MockDbDataReader.WithFloat(25.0f);

		// Act
		var result = await fakeDataReader.TryGetFloatAsync(0);

		// Assert
		Assert.That(result, Is.InstanceOf<Maybe<float>>());
		Assert.That(result.HasValue, Is.True);
		Assert.That(result.Value, Is.EqualTo(25.0f));
	}

	[Test]
	public async Task DbDataReader_TryGetGuidAsync_WithDbNull_ReturnsEmptyMaybe()
	{
		// Arrange
		var fakeDataReader = MockDbDataReader.Empty;

		// Act
		var result = await fakeDataReader.TryGetGuidAsync(0);

		// Assert
		Assert.That(result, Is.InstanceOf<Maybe<Guid>>());
		Assert.That(result.HasValue, Is.False);
	}

	[Test]
	public async Task DbDataReader_TryGetGuidAsync_WithValue_ReturnsMaybeWithValue()
	{
		// Arrange
		var fakeDataReader = MockDbDataReader.WithGuid(new Guid("b3e7f4d3-3b7b-4b1b-8e0e-3b1b7b4b3e7f"));

		// Act
		var result = await fakeDataReader.TryGetGuidAsync(0);

		// Assert
		Assert.That(result, Is.InstanceOf<Maybe<Guid>>());
		Assert.That(result.HasValue, Is.True);
		Assert.That(result.Value, Is.EqualTo(new Guid("b3e7f4d3-3b7b-4b1b-8e0e-3b1b7b4b3e7f")));
	}

	[Test]
	public async Task DbDataReader_TryGetInt16Async_WithDbNull_ReturnsEmptyMaybe()
	{
		// Arrange
		var fakeDataReader = MockDbDataReader.Empty;

		// Act
		var result = await fakeDataReader.TryGetInt16Async(0);

		// Assert
		Assert.That(result, Is.InstanceOf<Maybe<short>>());
		Assert.That(result.HasValue, Is.False);
	}

	[Test]
	public async Task DbDataReader_TryGetInt16Async_WithValue_ReturnsMaybeWithValue()
	{
		// Arrange
		var fakeDataReader = MockDbDataReader.WithInt16(25);

		// Act
		var result = await fakeDataReader.TryGetInt16Async(0);

		// Assert
		Assert.That(result, Is.InstanceOf<Maybe<short>>());
		Assert.That(result.HasValue, Is.True);
		Assert.That(result.Value, Is.EqualTo((short)25));
	}

	[Test]
	public async Task DbDataReader_TryGetInt32Async_WithDbNull_ReturnsEmptyMaybe()
	{
		// Arrange
		var fakeDataReader = MockDbDataReader.Empty;

		// Act
		var result = await fakeDataReader.TryGetInt32Async(0);

		// Assert
		Assert.That(result, Is.InstanceOf<Maybe<int>>());
		Assert.That(result.HasValue, Is.False);
	}

	[Test]
	public async Task DbDataReader_TryGetInt32Async_WithValue_ReturnsMaybeWithValue()
	{
		// Arrange
		var fakeDataReader = MockDbDataReader.WithInt32(25);

		// Act
		var result = await fakeDataReader.TryGetInt32Async(0);

		// Assert
		Assert.That(result, Is.InstanceOf<Maybe<int>>());
		Assert.That(result.HasValue, Is.True);
		Assert.That(result.Value, Is.EqualTo(25));
	}

	[Test]
	public async Task DbDataReader_TryGetInt64Async_WithDbNull_ReturnsEmptyMaybe()
	{
		// Arrange
		var fakeDataReader = MockDbDataReader.Empty;

		// Act
		var result = await fakeDataReader.TryGetInt64Async(0);

		// Assert
		Assert.That(result, Is.InstanceOf<Maybe<long>>());
		Assert.That(result.HasValue, Is.False);
	}

	[Test]
	public async Task DbDataReader_TryGetInt64Async_WithValue_ReturnsMaybeWithValue()
	{
		// Arrange
		var fakeDataReader = MockDbDataReader.WithInt64(25L);

		// Act
		var result = await fakeDataReader.TryGetInt64Async(0);

		// Assert
		Assert.That(result, Is.InstanceOf<Maybe<long>>());
		Assert.That(result.HasValue, Is.True);
		Assert.That(result.Value, Is.EqualTo(25));
	}

	[Test]
	public async Task DbDataReader_TryGetStringAsync_WithDbNull_ReturnsEmptyMaybe()
	{
		// Arrange
		var fakeDataReader = MockDbDataReader.Empty;

		// Act
		var result = await fakeDataReader.TryGetStringAsync(0);

		// Assert
		Assert.That(result, Is.InstanceOf<Maybe<string>>());
		Assert.That(result.HasValue, Is.False);
	}

	[Test]
	public async Task DbDataReader_TryGetStringAsync_WithValue_ReturnsMaybeWithValue()
	{
		// Arrange
		var fakeDataReader = MockDbDataReader.WithString("banana");

		// Act
		var result = await fakeDataReader.TryGetStringAsync(0);

		// Assert
		Assert.That(result, Is.InstanceOf<Maybe<string>>());
		Assert.That(result.HasValue, Is.True);
		Assert.That(result.Value, Is.EqualTo("banana"));
	}

	private class MockDbDataReader : DbDataReader
	{
		private readonly bool _isNull;
		private readonly Maybe<bool> _boolValue;
		private readonly Maybe<byte> _byteValue;
		private readonly Maybe<long> _bytesValue;
		private readonly Maybe<char> _charValue;
		private readonly Maybe<long> _charsValue;
		private readonly Maybe<DateTime> _dateTimeValue;
		private readonly Maybe<decimal> _decimalValue;
		private readonly Maybe<float> _floatValue;
		private readonly Maybe<Guid> _guidValue;
		private readonly Maybe<short> _int16Value;
		private readonly Maybe<int> _int32Value;
		private readonly Maybe<long> _int64Value;
		private readonly Maybe<string> _stringValue;

		private MockDbDataReader(
			bool isNull,
			Maybe<bool> boolValue = default,
			Maybe<byte> byteValue = default,
			Maybe<long> bytesValue = default,
			Maybe<char> charValue = default,
			Maybe<long> charsValue = default,
			Maybe<DateTime> dateTimeValue = default,
			Maybe<decimal> decimalValue = default,
			Maybe<float> floatValue = default,
			Maybe<Guid> guidValue = default,
			Maybe<short> int16Value = default,
			Maybe<int> int32Value = default,
			Maybe<long> int64Value = default,
			Maybe<string> stringValue = default
		)
		{
			_isNull = isNull;
			_boolValue = boolValue;
			_byteValue = byteValue;
			_bytesValue = bytesValue;
			_charValue = charValue;
			_charsValue = charsValue;
			_dateTimeValue = dateTimeValue;
			_decimalValue = decimalValue;
			_floatValue = floatValue;
			_guidValue = guidValue;
			_int16Value = int16Value;
			_int32Value = int32Value;
			_int64Value = int64Value;
			_stringValue = stringValue;
			//
		}

		public static MockDbDataReader Empty => new(isNull: true);
		public static MockDbDataReader WithBoolean(bool value) => new(isNull: false, boolValue: Maybe.Create(value));
		public static MockDbDataReader WithByte(byte value) => new(isNull: false, byteValue: Maybe.Create(value));
		public static MockDbDataReader WithBytes(long value) => new(isNull: false, bytesValue: Maybe.Create(value));
		public static MockDbDataReader WithChar(char value) => new(isNull: false, charValue: Maybe.Create(value));
		public static MockDbDataReader WithChars(long value) => new(isNull: false, charsValue: Maybe.Create(value));
		public static MockDbDataReader WithDateTime(DateTime value) => new(isNull: false, dateTimeValue: Maybe.Create(value));
		public static MockDbDataReader WithDecimal(decimal value) => new(isNull: false, decimalValue: Maybe.Create(value));
		public static MockDbDataReader WithFloat(float value) => new(isNull: false, floatValue: Maybe.Create(value));
		public static MockDbDataReader WithGuid(Guid value) => new(isNull: false, guidValue: Maybe.Create(value));
		public static MockDbDataReader WithInt16(short value) => new(isNull: false, int16Value: Maybe.Create(value));
		public static MockDbDataReader WithInt32(int value) => new(isNull: false, int32Value: Maybe.Create(value));
		public static MockDbDataReader WithInt64(long value) => new(isNull: false, int64Value: Maybe.Create(value));
		public static MockDbDataReader WithString(string value) => new(isNull: false, stringValue: Maybe.Create(value));

		/// <inheritdoc />
		public override bool GetBoolean(int ordinal) => _boolValue.Value;

		/// <inheritdoc />
		public override byte GetByte(int ordinal) => _byteValue.Value;

		/// <inheritdoc />
		public override long GetBytes(int ordinal, long dataOffset, byte[]? buffer, int bufferOffset, int length) =>
			_bytesValue.Value;

		/// <inheritdoc />
		public override char GetChar(int ordinal) => _charValue.Value;

		/// <inheritdoc />
		public override long GetChars(int ordinal, long dataOffset, char[]? buffer, int bufferOffset, int length) =>
			_charsValue.Value;

		/// <inheritdoc />
		public override string GetDataTypeName(int ordinal) => throw new NotImplementedException();

		/// <inheritdoc />
		public override DateTime GetDateTime(int ordinal) => _dateTimeValue.Value;

		/// <inheritdoc />
		public override decimal GetDecimal(int ordinal) => _decimalValue.Value;

		/// <inheritdoc />
		public override double GetDouble(int ordinal) => throw new NotImplementedException();

		/// <inheritdoc />
		public override Type GetFieldType(int ordinal) => throw new NotImplementedException();

		/// <inheritdoc />
		public override float GetFloat(int ordinal) => _floatValue.Value;

		/// <inheritdoc />
		public override Guid GetGuid(int ordinal) => _guidValue.Value;

		/// <inheritdoc />
		public override short GetInt16(int ordinal) => _int16Value.Value;

		/// <inheritdoc />
		public override int GetInt32(int ordinal) => _int32Value.Value;

		/// <inheritdoc />
		public override long GetInt64(int ordinal) => _int64Value.Value;

		/// <inheritdoc />
		public override string GetName(int ordinal) => throw new NotImplementedException();

		/// <inheritdoc />
		public override int GetOrdinal(string name) => throw new NotImplementedException();

		/// <inheritdoc />
		public override string GetString(int ordinal) => _stringValue.Value;

		/// <inheritdoc />
		public override object GetValue(int ordinal) => throw new NotImplementedException();

		/// <inheritdoc />
		public override int GetValues(object[] values) => throw new NotImplementedException();

		/// <inheritdoc />
		public override bool IsDBNull(int ordinal) => throw new NotImplementedException();

		/// <inheritdoc />
		public override Task<bool> IsDBNullAsync(int ordinal, CancellationToken cancellationToken) =>
			Task.FromResult(_isNull);

		/// <inheritdoc />
		public override int FieldCount => throw new NotImplementedException();

		/// <inheritdoc />
		public override object this[int ordinal] => throw new NotImplementedException();

		/// <inheritdoc />
		public override object this[string name] => throw new NotImplementedException();

		/// <inheritdoc />
		public override int RecordsAffected => throw new NotImplementedException();

		/// <inheritdoc />
		public override bool HasRows => throw new NotImplementedException();

		/// <inheritdoc />
		public override bool IsClosed => throw new NotImplementedException();

		/// <inheritdoc />
		public override bool NextResult() => throw new NotImplementedException();

		/// <inheritdoc />
		public override bool Read() => throw new NotImplementedException();

		/// <inheritdoc />
		public override int Depth => throw new NotImplementedException();

		/// <inheritdoc />
		public override IEnumerator GetEnumerator() => throw new NotImplementedException();
	}
}
