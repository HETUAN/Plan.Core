using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using Dapper;
using System.Data;
using MySql.Data.MySqlClient;

namespace Bruce.Paln.Repository
{
    //public abstract class MsSqlBaseRepository
    //{
    //    private string connStr = "Data Source=.;Initial Catalog=Bruce;User ID=sa;Password=123.com;";
    //    #region dapper 封装方法
    //    protected T QuerySingle<T>(IDbConnection sqlConnection, string sql, object param = null, bool buffered = true, int? commandTimeout = null, CommandType? commandType = null)
    //    {
    //        using (sqlConnection)
    //        {
    //            var result = sqlConnection.Query<T>(sql, param, null, buffered, commandTimeout, commandType);
    //            if (result == null)
    //                return default(T);

    //            return result.FirstOrDefault();
    //        }
    //    }

    //    protected List<T> Query<T>(IDbConnection sqlConnection, string sql, object param = null, bool buffered = true, int? commandTimeout = null, CommandType? commandType = null)
    //    {
    //        using (sqlConnection)
    //        {
    //            var result = sqlConnection.Query<T>(sql, param, null, buffered, commandTimeout, commandType).ToList();

    //            return result;
    //        }
    //    }

    //    protected int ExecuteNonQuery(IDbConnection sqlConnection, string sql, object param = null, int? commandTimeout = null, CommandType? commandType = null)
    //    {
    //        using (sqlConnection)
    //        {
    //            var result = sqlConnection.Execute(sql, param, null, commandTimeout, commandType);
    //            return result;
    //        }
    //    }

    //    protected SqlConnection OpenSqlConnection()
    //    {
    //        SqlConnection connection = new SqlConnection(connStr);
    //        connection.Open();
    //        return connection;
    //    }
    //    #endregion
    //}

    public abstract class BaseRepository
    {

        protected string ConnStr = "server=52.197.53.214;database=bbs;uid=bruce;pwd=bruce@*#%;charset='utf8';SslMode=None";
        protected MySqlConnection OpenSqlConnection()
        {
            // 
            try
            {
                MySqlConnection connection = new MySqlConnection(ConnStr);
                connection.Open();
                return connection;
            }
            catch (System.Exception ex)
            {
                return null;
            }
        }

        protected int ExecuteNonQuery(MySqlConnection con, string sql, object param = null)
        {
            try
            {
                //修改数据
                int row = con.Execute(sql, param);
                return row;
            }
            catch (System.Exception ex)
            {
                return 0;
            }
        }

        protected T QuerySingle<T>(MySqlConnection con, string sql, object param = null)
        {
            try
            {
                return con.QueryFirst<T>(sql, param);
            }
            catch (System.Exception ex)
            {
                return default(T);
            }
        }

        protected List<T> Query<T>(MySqlConnection con, string sql, object param = null)
        {
            //
            try
            {
                return con.Query<T>(sql, param).ToList();
            }
            catch (System.Exception ex)
            {
                return null;
            }
        }

    }

}
