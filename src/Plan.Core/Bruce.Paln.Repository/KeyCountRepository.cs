using System;
using System.Collections.Generic;
using Bruce.Paln.Entity;
using Bruce.Paln.Entity.ViewModel;

namespace Bruce.Paln.Repository
{
    public class KeyCountRepository : BaseRepository
    {
        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public List<KeyCountEntity> GetList(int userId)
        {
            string sql = @"SELECT [Id],[WorkId],[MacAddr],[Day],[TimeStamp],[KCount],[UserId] FROM [KeyCount] WHERE UserId = @UserId";
            return Query<KeyCountEntity>(OpenMsSqlConnection(), sql, new { UserId = userId });
        }

        public List<KeyCountViewModel> GetLast7DayViewModels(int userId)
        {
            string sql = @"SELECT TOP 7 [Day],SUM(KCount) KCount FROM [KeyCount] WHERE UserId = @UserId GROUP BY [Day] ORDER BY [Day] DESC";
            return Query<KeyCountViewModel>(OpenMsSqlConnection(), sql, new { UserId = userId });
        }

        public List<KeyCountViewModel> GetViewModels(int userId, DateTime sday, DateTime eday)
        {
            string sql = @"SELECT [Day],SUM(KCount) KCount FROM [KeyCount] WHERE UserId = @UserId AND [Day] BETWEEN @SDay AND @EDay GROUP BY [Day] ORDER BY [Day] DESC";
            return Query<KeyCountViewModel>(OpenMsSqlConnection(), sql, new { UserId = userId, SDay = sday, EDay = eday });
        }
    }
}
