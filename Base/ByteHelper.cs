namespace FruityFoundation.Base;

public static class ByteHelper
{
	public static long FromKilobytes(long kilobytes) =>
		kilobytes * 1024;

	public static long FromMegabytes(long megabytes) =>
		megabytes * 1024 * 1024;

	public static long FromGigabytes(long gigabytes) =>
		gigabytes * 1024 * 1024 * 1024;
}