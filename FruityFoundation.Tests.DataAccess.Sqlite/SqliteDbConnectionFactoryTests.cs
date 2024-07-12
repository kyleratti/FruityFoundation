using FruityFoundation.DataAccess.Abstractions;
using FruityFoundation.DataAccess.Sqlite;

namespace FruityFoundation.Tests.DataAccess.Sqlite;

public class SqliteDbConnectionFactoryTests
{
	[Test]
	public void CreateConnection_WithValidConnectionString_ReturnsNonTransactionalDbConnection_ReadWrite()
	{
		// Arrange
		var connectionFactory = new SqliteDbConnectionFactory(
			serviceProvider: null!,
			getReadWriteConnectionString: _ => "Data Source=:memory:",
			getReadOnlyConnectionString: null!);

		// Act
		var result = connectionFactory.CreateConnection();

		// Assert
		Assert.That(result, Is.InstanceOf<INonTransactionalDbConnection<ReadWrite>>());
	}

	[Test]
	public void CreateReadOnlyConnection_WithValidConnectionString_ReturnsNonTransactionalDbConnection_ReadOnly()
	{
		// Arrange
		var connectionFactory = new SqliteDbConnectionFactory(
			serviceProvider: null!,
			getReadWriteConnectionString: null!,
			getReadOnlyConnectionString: _ => "Data Source=:memory:");

		// Act
		var result = connectionFactory.CreateReadOnlyConnection();

		// Assert
		Assert.That(result, Is.InstanceOf<INonTransactionalDbConnection<ReadOnly>>());
	}
}
