using Bruce.Paln.Entity;
using Bruce.Paln.Entity.ViewModel;
using System;
using System.Collections.Generic;

namespace Bruce.Paln.Repository
{
    public class WeeklyRepository : BaseRepository
    {
        public WeeklyEntity GetModel(int userId, DateTime date)
        {
            //
            string sql = @"SELECT [Id]
                                  ,[UserId]
                                  ,[WeekDate]
                                  ,[Title]
                                  ,[Summary]
                                  ,[CreateTime]
                                  ,[UpdateTime]
                              FROM [Weekly] WHERE UserId = @UserId 
                                            AND  @WeekDate >= DATEADD(DAY,2-DATEPART(weekday,WeekDate),WeekDate)
                                            AND @WeekDate <= DATEADD(DAY,8-DATEPART(weekday,WeekDate),WeekDate)";
            return QuerySingle<WeeklyEntity>(OpenMsSqlConnection(), sql, new { UserId = userId, WeekDate = date.Date });
        }


        public WeeklyEntity GetModel(int id)
        {
            //
            string sql = @"SELECT [Id]
                                  ,[UserId]
                                  ,[WeekDate]
                                  ,[Title]
                                  ,[Summary]
                                  ,[CreateTime]
                                  ,[UpdateTime]
                              FROM [Weekly] WHERE Id = @Id";
            return QuerySingle<WeeklyEntity>(OpenMsSqlConnection(), sql, new { Id = id });
        }

        public List<WeeklyViewModel> GetList(int userId)
        {
            string sql = @"SELECT [Id]
                                  ,[UserId]
                                  ,[WeekDate]
                                  ,[Title]
                                  ,[CreateTime]
                                  ,[UpdateTime]
                              FROM [Weekly] WHERE UserId = @UserId ORDER BY UpdateTime DESC";
            return Query<WeeklyViewModel>(OpenMsSqlConnection(), sql, new { UserId = userId });
        }

        public int Insert(WeeklyEntity model)
        {
            string sql = @"INSERT INTO [Weekly]
                                        ([UserId]
                                        ,[WeekDate]
                                        ,[Title]
                                        ,[Summary]
                                        ,[CreateTime]
                                        ,[UpdateTime])
                                    VALUES
                                        (@UserId
                                        ,@WeekDate
                                        ,@Title
                                        ,@Summary
                                       ,GETDATE()
                                       ,GETDATE())";
            return Execute(OpenMsSqlConnection(), sql, model);
        }


        public int Update(WeeklyEntity model)
        {
            string sql = @"UPDATE [Weekly]
                                SET  [Title] = @Title 
                                    ,[Summary] = @Summary  
                                    ,[UpdateTime] = GETDATE()
                                WHERE Id = @Id";
            return Execute(OpenMsSqlConnection(), sql, model);
        }


        public int Delete(int id)
        {
            string sql = @"DELETE FROM [Weekly] WHERE Id = @Id";
            return Execute(OpenMsSqlConnection(), sql, new { Id = id });
        }
    }
}
