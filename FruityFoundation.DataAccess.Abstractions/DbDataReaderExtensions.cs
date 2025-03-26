using System.Data.Common;
using System.Runtime.CompilerServices;

namespace FruityFoundation.DataAccess.Abstractions;

public static class DbDataReaderExtensions
{
	public static async IAsyncEnumerable<DbDataReader> ToAsyncEnumerable(
		this Task<DbDataReader> reader,
		[EnumeratorCancellation] CancellationToken cancellationToken
	)
	{
		await using var readerHandle = await reader.ConfigureAwait(false);

		while (await readerHandle.ReadAsync(cancellationToken).ConfigureAwait(false))
		{
			yield return readerHandle;
		}
	}
}
