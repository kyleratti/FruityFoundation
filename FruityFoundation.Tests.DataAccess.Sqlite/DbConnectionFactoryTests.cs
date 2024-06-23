using FruityFoundation.DataAccess.Abstractions;
using FruityFoundation.DataAccess.Sqlite;

namespace FruityFoundation.Tests.DataAccess.Sqlite;

public class DbConnectionFactoryTests
{
	[TestCase("")]
	[TestCase("    ")]
	[TestCase(null)]
	public void CreateConnection_ThrowsException_WhenConnectionStringIsNullOrEmpty(string? connectionString)
	{
		// Arrange
		var dbConnectionFactory = new DbConnectionFactory(connectionString!, readOnlyConnectionString: "ReadOnlyConnectionString");

		// Act
		var exception = Assert.Throws<ApplicationException>(() => dbConnectionFactory.CreateConnection());

		// Assert
		Assert.That(exception, Is.Not.Null);
		Assert.That(exception.Message, Is.EqualTo("ReadWrite connection string cannot be null or empty."));
	}

	[TestCase("")]
	[TestCase("    ")]
	[TestCase(null)]
	public void CreateReadOnlyConnection_ThrowsException_WhenConnectionStringIsNullOrEmpty(string? connectionString)
	{
		// Arrange
		var dbConnectionFactory = new DbConnectionFactory(readWriteConnectionString: "connectionString", readOnlyConnectionString: null!);

		// Act
		var exception = Assert.Throws<ApplicationException>(() => dbConnectionFactory.CreateReadOnlyConnection());

		// Assert
		Assert.That(exception, Is.Not.Null);
		Assert.That(exception.Message, Is.EqualTo("ReadOnly connection string cannot be null or empty."));
	}

	[Test]
	public void CreateConnection_ReturnsNonTransactionalDbConnection_WhenConnectionStringIsValid()
	{
		// Arrange
		var dbConnectionFactory = new DbConnectionFactory(readWriteConnectionString: "Data Source=:memory:", readOnlyConnectionString: null!);

		// Act
		var connection = dbConnectionFactory.CreateConnection();

		// Assert
		Assert.That(connection, Is.Not.Null);
		Assert.That(connection, Is.InstanceOf<INonTransactionalDbConnection<ReadWrite>>());
	}

	[Test]
	public void CreateReadOnlyConnection_ReturnsNonTransactionalDbConnection_WhenConnectionStringIsValid()
	{
		// Arrange
		var dbConnectionFactory = new DbConnectionFactory(readWriteConnectionString: null!, readOnlyConnectionString: "Data Source=:memory:;Mode=ReadOnly");

		// Act
		var connection = dbConnectionFactory.CreateReadOnlyConnection();

		// Assert
		Assert.That(connection, Is.Not.Null);
		Assert.That(connection, Is.InstanceOf<INonTransactionalDbConnection<ReadOnly>>());
	}
}
