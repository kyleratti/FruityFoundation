using System;
using System.Data;
using System.Data.Common;
using System.Threading.Tasks;

namespace FruityFoundation.Base.Structures;

public static class DataReaderExtensions
{
	public static Maybe<bool> TryGetBoolean(this IDataReader reader, int ord) =>
		TryGet(reader, ord, reader.GetBoolean);

	public static async Task<Maybe<bool>> TryGetBooleanAsync(this DbDataReader reader, int ord) =>
		await TryGetAsync(reader, ord, reader.GetBoolean);

	public static Maybe<byte> TryGetByte(this IDataReader reader, int ord) =>
		TryGet(reader, ord, reader.GetByte);

	public static async Task<Maybe<byte>> TryGetByteAsync(this DbDataReader reader, int ord) =>
		await TryGetAsync(reader, ord, reader.GetByte);

	public static Maybe<long> TryGetBytes(this IDataReader reader, int ord, long fieldOffset, byte[]? buffer, int bufferOffset, int length) =>
		TryGet(reader, ord, _ => reader.GetBytes(ord, fieldOffset, buffer, bufferOffset, length));

	public static async Task<Maybe<long>> TryGetBytesAsync(this DbDataReader reader, int ord, long fieldOffset, byte[]? buffer, int bufferOffset, int length) =>
		await TryGetAsync(reader, ord, _ => reader.GetBytes(ord, fieldOffset, buffer, bufferOffset, length));

	public static Maybe<char> TryGetChar(this IDataReader reader, int ord) =>
		TryGet(reader, ord, reader.GetChar);

	public static async Task<Maybe<char>> TryGetCharAsync(this DbDataReader reader, int ord) =>
		await TryGetAsync(reader, ord, reader.GetChar);

	public static Maybe<long> TryGetChars(this IDataReader reader, int ord, long fieldOffset, char[]? buffer, int bufferOffset, int length) =>
		TryGet(reader, ord, _ => reader.GetChars(ord, fieldOffset, buffer, bufferOffset, length));

	public static async Task<Maybe<long>> TryGetCharsAsync(this DbDataReader reader, int ord, long fieldOffset, char[]? buffer, int bufferOffset, int length) =>
		await TryGetAsync(reader, ord, _ => reader.GetChars(ord, fieldOffset, buffer, bufferOffset, length));

	public static Maybe<DateTime> TryGetDateTime(this IDataReader reader, int ord) =>
		TryGet(reader, ord, reader.GetDateTime);

    public static async Task<Maybe<DateTime>> TryGetDateTimeAsync(this DbDataReader reader, int ord) =>
		await TryGetAsync(reader, ord, reader.GetDateTime);

	public static Maybe<decimal> TryGetDecimal(this IDataReader reader, int ord) =>
		TryGet(reader, ord, reader.GetDecimal);

    public static async Task<Maybe<decimal>> TryGetDecimalAsync(this DbDataReader reader, int ord) =>
		await TryGetAsync(reader, ord, reader.GetDecimal);

	public static Maybe<float> TryGetFloat(this IDataReader reader, int ord) =>
		TryGet(reader, ord, reader.GetFloat);

    public static async Task<Maybe<float>> TryGetFloatAsync(this DbDataReader reader, int ord) =>
		await TryGetAsync(reader, ord, reader.GetFloat);

	public static Maybe<Guid> TryGetGuid(this IDataReader reader, int ord) =>
		TryGet(reader, ord, reader.GetGuid);

    public static async Task<Maybe<Guid>> TryGetGuidAsync(this DbDataReader reader, int ord) =>
		await TryGetAsync(reader, ord, reader.GetGuid);

	public static Maybe<short> TryGetInt16(this IDataReader reader, int ord) =>
		TryGet(reader, ord, reader.GetInt16);

    public static async Task<Maybe<short>> TryGetInt16Async(this DbDataReader reader, int ord) =>
		await TryGetAsync(reader, ord, reader.GetInt16);

	public static Maybe<int> TryGetInt32(this IDataReader reader, int ord) =>
		TryGet(reader, ord, reader.GetInt32);

    public static async Task<Maybe<int>> TryGetInt32Async(this DbDataReader reader, int ord) =>
		await TryGetAsync(reader, ord, reader.GetInt32);

	public static Maybe<long> TryGetInt64(this IDataReader reader, int ord) =>
		TryGet(reader, ord, reader.GetInt64);

    public static async Task<Maybe<long>> TryGetInt64Async(this DbDataReader reader, int ord) =>
		await TryGetAsync(reader, ord, reader.GetInt64);

	public static Maybe<string> TryGetString(this IDataReader reader, int ord) =>
		TryGet(reader, ord, reader.GetString);

    public static async Task<Maybe<string>> TryGetStringAsync(this DbDataReader reader, int ord) =>
		await TryGetAsync(reader, ord, reader.GetString);

	private static Maybe<T> TryGet<T>(IDataRecord reader, int ord, Func<int, T> valueGetter) =>
		reader.IsDBNull(ord) ? Maybe.Empty<T>() : valueGetter(ord);

	private static async Task<Maybe<T>> TryGetAsync<T>(DbDataReader reader, int ord, Func<int, T> valueGetter)
	{
		if (await reader.IsDBNullAsync(ord))
			return Maybe.Empty<T>();

		var value = valueGetter(ord);

		return Maybe.Create(value);
	}
}
