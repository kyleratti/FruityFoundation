using System.Data.Common;
using FakeItEasy;
using FruityFoundation.DataAccess.Abstractions;

namespace FruityFoundation.Tests.DataAccess.Abstractions;

public class DbDataReaderExtensionsTests
{
	private DbDataReader _fakeReader = null!;

	[SetUp]
	public void Setup()
	{
		_fakeReader = A.Fake<DbDataReader>();
	}

	[TearDown]
	public void TearDown()
	{
		_fakeReader.Dispose();
	}

	[Test]
	public async Task ToAsyncEnumerable_YieldsReader_ClosesWhenExhausted()
	{
		// Arrange
		// ReSharper disable once AccessToDisposedClosure
		A.CallTo(() => _fakeReader.ReadAsync(A<CancellationToken>.Ignored))
			.Returns(true).NumberOfTimes(4);
		// ReSharper disable once AccessToDisposedClosure
		A.CallTo(() => _fakeReader.GetInt32(0))
			.ReturnsNextFromSequence(1, 2, 3, 4);

		// Act
		var items = await Task.FromResult(_fakeReader)
			.ToAsyncEnumerable(CancellationToken.None)
			.Select(reader => reader.GetInt32(0))
			.ToArrayAsync();

		// Assert
		Assert.That(items, Has.Length.EqualTo(4));
		Assert.That(items, Is.EquivalentTo((int[]) [1, 2, 3, 4]));
		// ReSharper disable once AccessToDisposedClosure
		// ReSharper disable once DisposeOnUsingVariable
		A.CallTo(() => _fakeReader.DisposeAsync())
			.MustHaveHappenedOnceExactly();
	}
}
