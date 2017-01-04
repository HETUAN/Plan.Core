using System;
using System.Collections.Generic;
using System.Linq;
using Bruce.Paln.Entity;
using Bruce.Paln.Entity.ViewModel;
using Dapper;

namespace Bruce.Paln.Repository
{
    public class DailyRepository : BaseRepository
    {
        public DailyEntity GetModel(int userId, DateTime date)
        {
            string sql = @"SELECT [Id]
                                  ,[UserId]
                                  ,[DailyDate]
                                  ,[Title]
                                  ,[Summary]
                                  ,[CreateTime]
                                  ,[UpdateTime]
                              FROM [Daily] WHERE UserId = @UserId AND DailyDate = @DailyDate";
            return QuerySingle<DailyEntity>(OpenMsSqlConnection(), sql, new { UserId = userId, DailyDate = date.Date });
        }

        public DailyEntity GetModel(int id)
        {
            string sql = @"SELECT [Id]
                                  ,[UserId]
                                  ,[DailyDate]
                                  ,[Title]
                                  ,[Summary]
                                  ,[CreateTime]
                                  ,[UpdateTime]
                              FROM [Daily] WHERE Id = @Id";
            return QuerySingle<DailyEntity>(OpenMsSqlConnection(), sql, new { Id = id });
        }

        public List<DailyViewModel> GetList(int userId)
        {
            string sql = @"SELECT [Id]
                                  ,[UserId]
                                  ,[DailyDate] 
                                  ,[Title]
                                  ,[CreateTime]
                                  ,[UpdateTime]
                              FROM [Daily] WHERE UserId = @UserId ORDER BY UpdateTime DESC";
            return Query<DailyViewModel>(OpenMsSqlConnection(), sql, new { UserId = userId });
        }

        public List<DailyViewModel> GetList(int userId, int pageIndex, int pageSize, string title, DateTime? date, out int rows)
        {
            // 
            string sql = @"SELECT   [Id] ,
                                    [UserId] ,
                                    [DailyDate] ,
                                    [Title] ,
                                    [CreateTime] ,
                                    [UpdateTime]
                            FROM    ( SELECT    ROW_NUMBER() OVER ( ORDER BY DailyDate DESC ) AS OrderId ,
                                                *
                                      FROM      [Daily]
                                    ) T
                            WHERE UserId = @UserId AND OrderId > @StartIndex  AND OrderId <= @EndIndex {0} ORDER BY DailyDate DESC;
                           SELECT COUNT(1) FROM [Daily] WHERE UserId = @UserId {0}";
            List<string> where = new List<string>();
            if (title.Trim() != "")
                where.Add("Ttile LIKE '%'+@Title+'%'");
            if (date != null)
            {
                using (System.Data.IDbConnection connection = OpenMsSqlConnection())
                {
                    where.Add("DailyDate = @DailyDate");
                    var qsql = string.Format(sql, where.Count > 0 ? " AND " : "" + string.Join(" AND ", where));
                    var multi = connection.QueryMultiple(qsql, new { UserId = userId, StartIndex = (pageIndex - 1) * pageSize, EndIndex = pageIndex * pageSize, Title = title, DailyDate = date.Value.Date });
                    var dailyList = multi.Read<DailyViewModel>().ToList();
                    rows = multi.Read<int>().FirstOrDefault();
                    return dailyList;
                }
            }
            else
            {

                using (System.Data.IDbConnection connection = OpenMsSqlConnection())
                {
                    var qsql = string.Format(sql, where.Count > 0 ? " AND " : "" + string.Join(" AND ", where));
                    var multi = connection.QueryMultiple(qsql, new { UserId = userId, StartIndex = (pageIndex - 1) * pageSize, EndIndex = pageIndex * pageSize, Title = title });
                    var dailyList = multi.Read<DailyViewModel>().ToList();
                    rows = multi.Read<int>().FirstOrDefault();
                    return dailyList;
                }
            }
        }

        public int Insert(DailyEntity model)
        {
            string sql = @"INSERT INTO [Daily]
                                       ([UserId]
                                       ,[DailyDate]
                                       ,[Title]
                                       ,[Summary]
                                       ,[CreateTime]
                                       ,[UpdateTime])
                                 VALUES
                                       (@UserId 
                                       ,@DailyDate
                                       ,@Title
                                       ,@Summary
                                       ,GETDATE()
                                       ,GETDATE())";
            return Execute(OpenMsSqlConnection(), sql, new
            {
                UserId = model.UserId,
                DailyDate = model.DailyDate.Date,
                Title = model.Title,
                Summary = model.Summary
            });
        }


        public int Update(DailyEntity model)
        {
            string sql = @"UPDATE [Daily]
                                           SET [Title] = @Title
                                              ,[Summary] = @Summary
                                              ,[UpdateTime] = GETDATE()
                                         WHERE Id = @Id";
            return Execute(OpenMsSqlConnection(), sql, new
            {
                Id = model.Id,
                Title = model.Title,
                Summary = model.Summary
            });
        }


        public int Delete(int id)
        {
            string sql = @"DELETE FROM [Daily] WHERE Id = @Id";
            return Execute(OpenMsSqlConnection(), sql, new { Id = id });
        }

        public int Count(DateTime today)
        {
            string sql = "SELECT COUNT(*) FROM Daily WHERE DailyDate = @Today";
            return QuerySingle<int>(OpenMsSqlConnection(), sql, new { Today = today.Date });
        }

        public bool Exist(int id)
        {
            string sql = "SELECT COUNT(*) FROM Daily WHERE Id = @id";
            return QuerySingle<int>(OpenMsSqlConnection(), sql, new { Id = id }) > 0;
        }

    }
}
