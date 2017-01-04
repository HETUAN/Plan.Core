using System.Collections.Generic;
using Bruce.Paln.Entity;
using Bruce.Paln.Entity.ViewModel;

namespace Bruce.Paln.Repository
{
    public class LeetQuestionRepository : BaseRepository
    {
        /// <summary>
        /// 插入一条回答记录
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public int Insert(LeetAnswerEntity entity)
        {
            string sql = @"INSERT INTO [Leet_Answer]
                                   ([UserId]
                                   ,[LeetCodeId]
                                   ,[Status]
                                   ,[Answer]
                                   ,[CreateTime]
                                   ,[UpdateTime])
                             VALUES
                                   (@UserId 
                                   ,@LeetCodeId
                                   ,@Status
                                   ,@Answer
                                   ,GETDATE()
                                   ,GETDATE())";
            return base.Execute(base.OpenMsSqlConnection(), sql, new { UserId = entity.UserId, LeetCodeId = entity.LeetCodeId, Status = entity.Status, Answer = entity.Answer });
        }

        public int Update(LeetAnswerEntity entity)
        {
            string sql = @"UPDATE [Leet_Answer]
                               SET [Status] = @Status
                                  ,[Answer] = @Answer
                                  ,[UpdateTime] = GETDATE()
                             WHERE [UserId] = @UserId AND [LeetCodeId] = @LeetCodeId ";
            return base.Execute(base.OpenMsSqlConnection(), sql, new { UserId = entity.UserId, LeetCodeId = entity.LeetCodeId, Status = entity.Status, Answer = entity.Answer });
        }


        public int Update(int userId, int leetCodeId, int status)
        {
            string sql = @"UPDATE [Leet_Answer]
                               SET [Status] = @Status 
                                  ,[UpdateTime] = GETDATE()
                             WHERE [UserId] = @UserId AND [LeetCodeId] = @LeetCodeId ";
            return base.Execute(base.OpenMsSqlConnection(), sql, new { UserId = userId, LeetCodeId = leetCodeId, Status = status });
        }

        public LeetQuestionEntity GetNextLeetQuestion(int userId)
        {
            //
            string sql = @"SELECT TOP 1 [TotalAcs],[QuestionTitle],[QuestionArticleSlug]
                                      ,[TotalSubmitted],[QuestionTitleSlug],[QuestionArticleLive]
                                      ,[QuestionHide],[QuestionId],[Level]
                                      ,[PaidOnly],[Frequency],[Progress]
                              FROM [Leet_Question] lq 
                                  LEFT JOIN  (SELECT * FROM Leet_Answer WHERE UserId = @UserId )la 
                                  ON la.LeetCodeId = lq.QuestionId 
                                  WHERE la.Status IS NULL OR la.status = 0 ORDER BY lq.[QuestionId] ";
            return base.QuerySingle<LeetQuestionEntity>(OpenMsSqlConnection(), sql,
                new
                {
                    UserId = userId
                }
            );
        }

        /// <summary>
        /// 获取所有问题和回答情况
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public List<LeetQuestionViewModel> GetList(int userId)
        {
            string sql = @"SELECT LQ.[TotalAcs],LQ.[QuestionTitle],LQ.[QuestionArticleSlug]
                                  ,LQ.[TotalSubmitted],LQ.[QuestionTitleSlug],LQ.[QuestionArticleLive]
                                  ,LQ.[QuestionHide],LQ.[QuestionId],LQ.[Level]
                                  ,LQ.[PaidOnly],LQ.[Frequency],LQ.[Progress]
                                  ,LA.[Answer],LA.[Status],LA.[CreateTime],LA.[UpdateTime]
                            FROM [Leet_Question] LQ LEFT JOIN (SELECT * FROM Leet_Answer WHERE UserId =  @UserId) LA 
                            ON LA.LeetCodeId = LQ.QuestionId 
                            ORDER BY LQ.QuestionId";
            return base.Query<LeetQuestionViewModel>(OpenMsSqlConnection(), sql,
                new
                {
                    UserId = userId
                }
            );
        }

    }
}
