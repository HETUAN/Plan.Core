using System.Collections.Generic;
using Bruce.Paln.Entity;
using Bruce.Paln.Entity.LeetCode;

namespace Bruce.Paln.Repository
{
    public class LeetAnswerRepository : BaseRepository
    {
        public int Insert(LeetAnswerEntity entity)
        {
            string sql = @"INSERT INTO [Leet_Answer]
                                        ([UserId],[LeetCodeId],[Status],[Answer])
                                    VALUES
                                        (@UserId,@LeetCodeId,@STATUS,@Answer)";
            return base.Execute(OpenMsSqlConnection(), sql, entity);
        }

        public int Update(LeetAnswerEntity entity)
        {
            string sql = @"UPDATE [Leet_Answer]
                                   SET [Status] = @STATUS
                                      ,[Answer] = @Answer
                                      ,[UpdateTime] = @UpdateTime
                                 WHERE  Id = @Id";
            return 0;
        }

    }
}
