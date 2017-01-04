using Bruce.Paln.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace Bruce.Paln.Repository
{
    public class SmallNoteRepository : BaseRepository
    {
        /// <summary>
        /// 获取数据
        /// </summary>
        /// <param name="userId">用户Id</param>
        /// <returns></returns>
        public List<SmallNoteEntity> GetSmallNoteListByUserId(int userId)
        {
            string sql = @"SELECT [Id]
                                ,[UserId]
                                ,[Note] 
                                ,[NState] 
                                ,[CreateTime]
                                ,[UpdateTime]
                              FROM [SmallNote] WHERE UserId = @UserId ORDER BY AddTime";
            return Query<SmallNoteEntity>(OpenMsSqlConnection(), sql, new { UserId = userId });
        }

        /// <summary>
        /// 获取数据
        /// </summary>
        /// <param name="userId">用户Id</param>
        /// <param name="state">状态</param>
        /// <returns></returns>
        public List<SmallNoteEntity> GetSmallNoteListByUserIdAndState(int userId, int state)
        {
            string sql = @"SELECT [Id]
                                ,[UserId]
                                ,[Note] 
                                ,[NState] 
                                ,[CreateTime]
                                ,[UpdateTime]
                              FROM [SmallNote] WHERE UserId = @UserId AND NState = @NState ORDER BY CreateTime";
            return Query<SmallNoteEntity>(OpenMsSqlConnection(), sql, new { UserId = userId, NState = state });
        }

        public List<SmallNoteEntity> GetList(int userId, int pageIndex, int pageSize, string title, out int rows)
        {
            // 
            string sql = @"SELECT   [Id] ,
                                    [UserId] ,
                                    [Note] ,
                                    [NState] ,
                                    [CreateTime] ,
                                    [UpdateTime]
                            FROM    ( SELECT    ROW_NUMBER() OVER ( ORDER BY CreateTime DESC ) AS OrderId ,
                                                *
                                      FROM      [SmallNote]
                                    ) T
                            WHERE UserId = @UserId AND OrderId > @StartIndex  AND OrderId <= @EndIndex {0} ORDER BY CreateTime DESC;
                           SELECT COUNT(1) FROM [SmallNote] WHERE UserId = @UserId {0}";
            List<string> where = new List<string>();
            if (title.Trim() != "")
                where.Add("Ttile LIKE '%'+@Title+'%'");

            using (System.Data.IDbConnection connection = OpenMsSqlConnection())
            {
                var qsql = string.Format(sql, where.Count > 0 ? " AND " : "" + string.Join(" AND ", where));
                var multi = connection.QueryMultiple(qsql, new { UserId = userId, StartIndex = (pageIndex - 1) * pageSize, EndIndex = pageIndex * pageSize, Title = title });
                var dailyList = multi.Read<SmallNoteEntity>().ToList();
                rows = multi.Read<int>().FirstOrDefault();
                return dailyList;
            }
        }

        public int Insert(SmallNoteEntity model)
        {
            string sql = @"INSERT INTO [SmallNote]
                                       ([UserId]
                                       ,[Note]
                                       ,[NState]
                                       ,[CreateTime]
                                       ,[UpdateTime])
                                 VALUES
                                       (@UserId
                                       ,@Note
                                       ,@NState
                                       ,GETDATE()
                                       ,GETDATE())";
            return Execute(OpenMsSqlConnection(), sql, model);
        }

        public int Update(NoteEntity model)
        {
            string sql = @"UPDATE [SmallNote]
                                           SET  [Note] = @Note 
                                              ,[NState] = @NState
                                              ,[UpdateTime] = GETDATE()
                                         WHERE Id = @Id AND UserID = @UserId";
            return Execute(OpenMsSqlConnection(), sql, model);
        }

        public int UpdateState(int id, int state, int userId)
        {
            string sql = @"UPDATE [SmallNote]
                                           SET [NState] = @NState
                                              ,[UpdateTime] = GETDATE()
                                         WHERE Id = @Id AND UserID = @UserId";
            return Execute(OpenMsSqlConnection(), sql, new { Id = id, NState = state, UserId = userId });
        }

        public int UpdateNote(int id, string note, int userId)
        {
            string sql = @"UPDATE [SmallNote]
                                           SET [Note] = @Note 
                                              ,[UpdateTime] = GETDATE()
                                         WHERE Id = @Id AND UserID = @UserId";
            return Execute(OpenMsSqlConnection(), sql, new { Id = id, Note = note, UserId = userId });
        }

        public int Delete(int id, int userId)
        {
            string sql = @"DELETE FROM [SmallNote] WHERE Id = @Id AND UserID = @UserId";
            return Execute(OpenMsSqlConnection(), sql, new { Id = id, UserId = userId });
        }

        public int IsNoteExist(int userId, string note, int id)
        {
            string where = string.Empty;
            if (id != 0)
            {
                where = " AND Id <> @Id ";
            }
            string sql = string.Format("SELECT COUNT(1) FROM [SmallNote] WHERE UserId = @UserId AND Note = @Note {0}", where);
            return QuerySingle<int>(OpenMsSqlConnection(), sql, new { UserId = userId, Note = note, Id = id });
        }
    }
}
