using System.Data;

namespace CleanArchitecture.Application.Common
{
    public interface IDbConnectionFactory
    {
        IDbConnection CreateConnection();
    }
}