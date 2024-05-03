using System;
using System.Data;

namespace FruityFoundation.Base.Structures;

public static class DataReaderExtensions
{
	public static Maybe<bool> TryGetBoolean(this IDataReader reader, int ord) =>
		TryGet(reader, ord, reader.GetBoolean);

	public static Maybe<byte> TryGetByte(this IDataReader reader, int ord) =>
		TryGet(reader, ord, reader.GetByte);

	public static Maybe<long> TryGetBytes(this IDataReader reader, int ord, long fieldOffset, byte[]? buffer, int bufferOffset, int length) =>
		TryGet(reader, ord, _ => reader.GetBytes(ord, fieldOffset, buffer, bufferOffset, length));

	public static Maybe<char> TryGetChar(this IDataReader reader, int ord) =>
		TryGet(reader, ord, reader.GetChar);

	public static Maybe<long> TryGetChars(this IDataReader reader, int ord, long fieldOffset, char[]? buffer, int bufferOffset, int length) =>
		TryGet(reader, ord, _ => reader.GetChars(ord, fieldOffset, buffer, bufferOffset, length));

	public static Maybe<DateTime> TryGetDateTime(this IDataReader reader, int ord) =>
		TryGet(reader, ord, reader.GetDateTime);

	public static Maybe<decimal> TryGetDecimal(this IDataReader reader, int ord) =>
		TryGet(reader, ord, reader.GetDecimal);

	public static Maybe<float> TryGetFloat(this IDataReader reader, int ord) =>
		TryGet(reader, ord, reader.GetFloat);

	public static Maybe<Guid> TryGetGuid(this IDataReader reader, int ord) =>
		TryGet(reader, ord, reader.GetGuid);

	public static Maybe<short> TryGetInt16(this IDataReader reader, int ord) =>
		TryGet(reader, ord, reader.GetInt16);

	public static Maybe<int> TryGetInt32(this IDataReader reader, int ord) =>
		TryGet(reader, ord, reader.GetInt32);

	public static Maybe<long> TryGetInt64(this IDataReader reader, int ord) =>
		TryGet(reader, ord, reader.GetInt64);

	public static Maybe<string> TryGetString(this IDataReader reader, int ord) =>
		TryGet(reader, ord, reader.GetString);

	private static Maybe<T> TryGet<T>(IDataRecord reader, int ord, Func<int, T> valueGetter) =>
		reader.IsDBNull(ord) ? Maybe.Empty<T>() : valueGetter(ord);
}
