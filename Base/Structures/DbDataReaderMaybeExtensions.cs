using System;
using System.Data.Common;
using System.Threading;
using System.Threading.Tasks;

namespace FruityFoundation.Base.Structures;

public static class DbDataReaderMaybeExtensions
{
	public static async Task<Maybe<bool>> TryGetBooleanAsync(this DbDataReader reader, int ord, CancellationToken cancellationToken = default) =>
		await TryGetAsync(reader, ord, reader.GetBoolean, cancellationToken);

	public static async Task<Maybe<byte>> TryGetByteAsync(this DbDataReader reader, int ord, CancellationToken cancellationToken = default) =>
		await TryGetAsync(reader, ord, reader.GetByte, cancellationToken);

	public static async Task<Maybe<long>> TryGetBytesAsync(this DbDataReader reader, int ord, long fieldOffset, byte[]? buffer, int bufferOffset, int length, CancellationToken cancellationToken = default) =>
		await TryGetAsync(reader, ord, _ => reader.GetBytes(ord, fieldOffset, buffer, bufferOffset, length), cancellationToken);

	public static async Task<Maybe<char>> TryGetCharAsync(this DbDataReader reader, int ord, CancellationToken cancellationToken = default) =>
		await TryGetAsync(reader, ord, reader.GetChar, cancellationToken);

	public static async Task<Maybe<long>> TryGetCharsAsync(this DbDataReader reader, int ord, long fieldOffset, char[]? buffer, int bufferOffset, int length, CancellationToken cancellationToken = default) =>
		await TryGetAsync(reader, ord, _ => reader.GetChars(ord, fieldOffset, buffer, bufferOffset, length), cancellationToken);

	public static async Task<Maybe<DateTime>> TryGetDateTimeAsync(this DbDataReader reader, int ord, CancellationToken cancellationToken = default) =>
		await TryGetAsync(reader, ord, reader.GetDateTime, cancellationToken);

	public static async Task<Maybe<decimal>> TryGetDecimalAsync(this DbDataReader reader, int ord, CancellationToken cancellationToken = default) =>
		await TryGetAsync(reader, ord, reader.GetDecimal, cancellationToken);

	public static async Task<Maybe<float>> TryGetFloatAsync(this DbDataReader reader, int ord, CancellationToken cancellationToken = default) =>
		await TryGetAsync(reader, ord, reader.GetFloat, cancellationToken);

	public static async Task<Maybe<Guid>> TryGetGuidAsync(this DbDataReader reader, int ord, CancellationToken cancellationToken = default) =>
		await TryGetAsync(reader, ord, reader.GetGuid, cancellationToken);

	public static async Task<Maybe<short>> TryGetInt16Async(this DbDataReader reader, int ord, CancellationToken cancellationToken = default) =>
		await TryGetAsync(reader, ord, reader.GetInt16, cancellationToken);

	public static async Task<Maybe<int>> TryGetInt32Async(this DbDataReader reader, int ord, CancellationToken cancellationToken = default) =>
		await TryGetAsync(reader, ord, reader.GetInt32, cancellationToken);

	public static async Task<Maybe<long>> TryGetInt64Async(this DbDataReader reader, int ord, CancellationToken cancellationToken = default) =>
		await TryGetAsync(reader, ord, reader.GetInt64, cancellationToken);

	public static async Task<Maybe<string>> TryGetStringAsync(this DbDataReader reader, int ord, CancellationToken cancellationToken = default) =>
		await TryGetAsync(reader, ord, reader.GetString, cancellationToken);

	private static async Task<Maybe<T>> TryGetAsync<T>(DbDataReader reader, int ord, Func<int, T> valueGetter, CancellationToken cancellationToken)
	{
		if (await reader.IsDBNullAsync(ord, cancellationToken))
			return Maybe.Empty<T>();

		var value = valueGetter(ord);

		return Maybe.Create(value);
	}
}
