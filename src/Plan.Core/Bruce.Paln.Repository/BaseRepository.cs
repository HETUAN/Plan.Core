using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using Dapper;
using System.Data;

namespace Bruce.Paln.Repository
{
    public abstract class BaseRepository
    {
        private string connStr = "Data Source=.;Initial Catalog=Bruce;User ID=sa;Password=123.com;";
        #region dapper 封装方法
        protected T QuerySingle<T>(IDbConnection sqlConnection, string sql, object param = null, bool buffered = true, int? commandTimeout = null, CommandType? commandType = null)
        {
            using (sqlConnection)
            {
                var result = sqlConnection.Query<T>(sql, param, null, buffered, commandTimeout, commandType);
                if (result == null)
                    return default(T);

                return result.FirstOrDefault();
            }
        }

        protected List<T> Query<T>(IDbConnection sqlConnection, string sql, object param = null, bool buffered = true, int? commandTimeout = null, CommandType? commandType = null)
        {
            using (sqlConnection)
            {
                var result = sqlConnection.Query<T>(sql, param, null, buffered, commandTimeout, commandType).ToList();

                return result;
            }
        }

        protected int Execute(IDbConnection sqlConnection, string sql, object param = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            using (sqlConnection)
            {
                var result = sqlConnection.Execute(sql, param, null, commandTimeout, commandType);
                return result;
            }
        }

        protected SqlConnection OpenMsSqlConnection()
        {
            SqlConnection connection = new SqlConnection(connStr);
            connection.Open();
            return connection;
        }
        #endregion
    }
}
