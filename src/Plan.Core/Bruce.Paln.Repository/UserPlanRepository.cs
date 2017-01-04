using Bruce.Paln.Entity;
using Bruce.Paln.Entity.ViewModel;
using System;
using System.Collections.Generic;

namespace Bruce.Paln.Repository
{
    public class UserPlanRepository : BaseRepository
    {
        /// <summary>
        /// 插入操作
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public int Insert(UserPlanEntity entity)
        {
            string sql = @"INSERT INTO [UserPlan]
                                   ([UserId]
                                   ,[Importance]
                                   ,[Tag]
                                   ,[Detail]
                                   ,[IsRemind]
                                   ,[PerRemind]
                                   ,[perRemindTime]
                                   ,[HappenTime]
                                   ,[UseTime]
                                   ,[CreateTime]
                                   ,[UpdateTime])
                             VALUES
                                   (@UserId 
                                   ,@IMPORTANCE
                                   ,@Tag
                                   ,@Detail
                                   ,@IsRemind
                                   ,@PerRemind
                                   ,@perRemindTime
                                   ,@HappenTime
                                   ,@UseTime
                                   ,GETDATE()
                                   ,GETDATE())";
            return Execute(OpenMsSqlConnection(), sql, entity);
        }

        /// <summary>
        /// 更新操作
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool Update(UserPlanEntity entity)
        {
            string sql = @"UPDATE [UserPlan]
                               SET [Importance] = @IMPORTANCE
                                  ,[Tag] = @Tag
                                  ,[Detail] = @Detail
                                  ,[IsRemind] = @IsRemind
                                  ,[PerRemind] = @PerRemind
                                  ,[perRemindTime] = @perRemindTime
                                  ,[HappenTime] = @HappenTime
                                  ,[UseTime] = @UseTime
                                  ,[UpdateTime] = GETDATE() 
                             WHERE Id = @Id";
            return Execute(OpenMsSqlConnection(), sql, entity) > 0;
        }

        public UserPlanEntity GetModel(int id)
        {
            string sql = @"SELECT [Id]
                              ,[UserId]
                              ,[Importance]
                              ,[Tag]
                              ,[Detail]
                              ,[IsRemind]
                              ,[PerRemind]
                              ,[perRemindTime]
                              ,[HappenTime]
                              ,[UseTime]
                              ,[CreateTime]
                              ,[UpdateTime]
                          FROM [UserPlan] WHERE Id = @Id";
            return QuerySingle<UserPlanEntity>(OpenMsSqlConnection(), sql, new { Id = id });
        }

        /// <summary>
        /// 获取实体列表
        /// </summary>
        /// <returns></returns>
        public List<UserPlanEntity> GetList()
        {
            string sql = @"SELECT [Id]
                              ,[UserId]
                              ,[Importance]
                              ,[Tag]
                              ,[Detail]
                              ,[IsRemind]
                              ,[PerRemind]
                              ,[perRemindTime]
                              ,[HappenTime]
                              ,[UseTime]
                              ,[CreateTime]
                              ,[UpdateTime]
                          FROM [UserPlan]";
            return Query<UserPlanEntity>(OpenMsSqlConnection(), sql);
        }

        /// <summary>
        /// 获取业务实体列表
        /// </summary>
        /// <returns></returns>
        public List<UserPlanViewModel> GetVmList()
        {
            string sql = @"SELECT [Id]
                                  ,[UserId]
                                  ,[Tag]
                                  ,[Detail]
                                  ,[IsRemind]
                                  ,[PerRemind]
                                  ,[perRemindTime]
                                  ,[Importance]
                                  ,[HappenTime]
                                  ,[UseTime]
                                  ,[HappenYear]
                                  ,[HappenMonth]
                                  ,[HappenDay]
                                  ,[HappenHour]
                                  ,[HappenMinute]
                                  ,[CreateTime]
                                  ,[UpdateTime]
                                  ,Result
                                  ,Summary
                              FROM [VIEW_UserPlan] ORDER BY HappenTime";
            return Query<UserPlanViewModel>(OpenMsSqlConnection(), sql);
        }


        /// <summary>
        /// 获取业务实体列表
        /// </summary>
        /// <returns></returns>
        public List<UserPlanViewModel> GetVmList(int userId, DateTime startTime, DateTime endTime)
        {
            string sql = @"SELECT [Id]
                                  ,[UserId]
                                  ,[Tag]
                                  ,[Detail]
                                  ,[IsRemind]
                                  ,[PerRemind]
                                  ,[perRemindTime]
                                  ,[Importance]
                                  ,[HappenTime]
                                  ,[UseTime]
                                  ,[HappenYear]
                                  ,[HappenMonth]
                                  ,[HappenDay]
                                  ,[HappenHour]
                                  ,[HappenMinute]
                                  ,[CreateTime]
                                  ,[UpdateTime]
                                  ,Result
                                  ,Summary
                              FROM [VIEW_UserPlan]  WHERE UserId = @UserId AND HappenTime BETWEEN @startTime AND @endTime  ORDER BY HappenTime";
            return Query<UserPlanViewModel>(OpenMsSqlConnection(), sql, new { UserId = userId, startTime = startTime, endTime = endTime });
        }

        /// <summary>
        /// 物理删除数据
        /// </summary>
        /// <param name="entityId"></param>
        /// <returns></returns>
        public int Delete(int entityId)
        {
            string sql = "DELETE FROM [UserPlan] WHERE Id = @Id";
            return Execute(OpenMsSqlConnection(), sql, new { Id = entityId });
        }

        /// <summary>
        /// 检查时间是否冲突
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <returns></returns>
        public int CheckConflict(int userId, DateTime startTime, DateTime endTime)
        {
            string sql = @"SELECT * FROM [UserPlan] 
                            WHERE 
                            UserId = @UserId AND (
                            (@T1>HappenTime AND @T1 < DATEADD(n,UseTime, HappenTime) ) 
                            OR  (@T2>HappenTime AND @T2 < DATEADD(n,UseTime, HappenTime) ) 
                            OR  (@T2>HappenTime AND @T1 < HappenTime ) 
                            OR  (@T2>DATEADD(n,UseTime, HappenTime) AND @T1 < DATEADD(n,UseTime, HappenTime) ) )";
            return QuerySingle<int>(OpenMsSqlConnection(), sql, new { UserId = userId, T1 = startTime, T2 = endTime });
        }

    }
}
