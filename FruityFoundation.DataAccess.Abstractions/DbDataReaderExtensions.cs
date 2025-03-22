using System.Data.Common;
using System.Runtime.CompilerServices;

namespace FruityFoundation.DataAccess.Abstractions;

public static class DbDataReaderExtensions
{
	public static async IAsyncEnumerable<DbDataReader> ToAsyncEnumerable(
		this DbDataReader reader,
		[EnumeratorCancellation] CancellationToken cancellationToken
	)
	{
		await using var readerHandle = reader;

		while (await reader.ReadAsync(cancellationToken))
		{
			yield return reader;
		}
	}
}
