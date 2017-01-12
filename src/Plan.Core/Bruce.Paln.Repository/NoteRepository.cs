using Bruce.Paln.Entity;
using Bruce.Paln.Entity.ViewModel;
using System.Collections.Generic;
using System.Linq;
using Dapper;

namespace Bruce.Paln.Repository
{
    public class NoteRepository : BaseRepository
    {

        public NoteEntity GetModel(int id)
        {
            string sql = @"SELECT [Id]
                                ,[UserId]
                                ,[Title]
                                ,[Note]
                                ,[CreateTime]
                                ,[UpdateTime]
                            FROM [Note] WHERE Id = @Id";
            return QuerySingle<NoteEntity>(OpenSqlConnection(), sql, new { Id = id });
        }

        public NoteEntity GetLastModel()
        {
            string sql = @"SELECT TOP 1 [Id]
                                ,[UserId]
                                ,[Title]
                                ,[Note]
                                ,[CreateTime]
                                ,[UpdateTime]
                            FROM [Note] ORDER BY Id DESC";
            return QuerySingle<NoteEntity>(OpenSqlConnection(), sql);
        }
        public List<NoteViewModel> GetList(int userId)
        {
            string sql = @"SELECT [Id]
                                ,[UserId]
                                ,[Title] 
                                ,[CreateTime]
                                ,[UpdateTime]
                              FROM [Note] WHERE UserId = @UserId ORDER BY UpdateTime DESC";
            return Query<NoteViewModel>(OpenSqlConnection(), sql, new { UserId = userId });
        }


        public List<DailyViewModel> GetList(int userId, int pageIndex, int pageSize, string title, out int rows)
        {
            // 
            string sql = @"SELECT   [Id] ,
                                    [UserId] ,
                                    [Title] ,
                                    [CreateTime] ,
                                    [UpdateTime]
                            FROM    ( SELECT    ROW_NUMBER() OVER ( ORDER BY CreateTime DESC ) AS OrderId ,
                                                *
                                      FROM      [Note]
                                    ) T
                            WHERE UserId = @UserId AND OrderId > @StartIndex  AND OrderId <= @EndIndex {0} ORDER BY CreateTime DESC;
                           SELECT COUNT(1) FROM [Note] WHERE UserId = @UserId {0}";
            List<string> where = new List<string>();
            if (title.Trim() != "")
                where.Add("Ttile LIKE '%'+@Title+'%'");

            using (System.Data.IDbConnection connection = OpenSqlConnection())
            {

                var qsql = string.Format(sql, where.Count > 0 ? " AND " : "" + string.Join(" AND ", where));
                var multi = connection.QueryMultiple(qsql, new { UserId = userId, StartIndex = (pageIndex - 1) * pageSize, EndIndex = pageIndex * pageSize, Title = title });
                var dailyList = multi.Read<DailyViewModel>().ToList();
                rows = multi.Read<int>().FirstOrDefault();
                return dailyList;
            }
        }

        public int Insert(NoteEntity model)
        {
            string sql = @"INSERT INTO [Note]
                                       ([UserId]
                                       ,[Note]
                                       ,[Title]
                                       ,[CreateTime]
                                       ,[UpdateTime])
                                 VALUES
                                       (@UserId
                                       ,@Note
                                       ,@Title
                                       ,GETDATE()
                                       ,GETDATE())";
            return ExecuteNonQuery(OpenSqlConnection(), sql, model);
        }


        public int Update(NoteEntity model)
        {
            string sql = @"UPDATE [Note]
                                           SET [Title] = @Title  
                                              ,[Note] = @Note  
                                              ,[UpdateTime] = GETDATE()
                                         WHERE Id = @Id";
            return ExecuteNonQuery(OpenSqlConnection(), sql, model);
        }


        public int Delete(int id)
        {
            string sql = @"DELETE FROM [Daily] WHERE Id = @Id";
            return ExecuteNonQuery(OpenSqlConnection(), sql, new { Id = id });
        }
    }
}
