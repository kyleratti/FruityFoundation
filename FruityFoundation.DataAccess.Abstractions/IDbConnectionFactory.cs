namespace FruityFoundation.DataAccess.Abstractions;

public interface IDbConnectionFactory
{
	public INonTransactionalDbConnection<ReadWrite> CreateConnection();
	public INonTransactionalDbConnection<ReadOnly> CreateReadOnlyConnection();
}
