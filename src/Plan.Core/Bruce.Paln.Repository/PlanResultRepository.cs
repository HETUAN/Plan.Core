using Bruce.Paln.Entity;

namespace Bruce.Paln.Repository
{
    public class PlanResultRepository : BaseRepository
    {
        public PlanResultEntity GetModel(int id)
        {
            string sql = @"SELECT [Id]
                              ,[PlanId]
                              ,[Result]
                              ,[Summary]
                          FROM [PlanResult] WHERE PlanId = @PlanId";
            return QuerySingle<PlanResultEntity>(OpenSqlConnection(), sql, new { PlanId = id });
        }

        public int Insert(PlanResultEntity model)
        {
            string sql = @"INSERT INTO [PlanResult]
                               ([PlanId]
                               ,[Result]
                               ,[Summary])
                         VALUES
                               (@PlanId, 
                                @Result, 
                                @Summary)";
            return ExecuteNonQuery(OpenSqlConnection(), sql, model);
        }

        public int Update(PlanResultEntity model)
        {
            string sql = @"UPDATE [PlanResult]
                               SET [Result] = @Result 
                                  ,[Summary] = @Summary 
                             WHERE [PlanId] = @PlanId";
            return ExecuteNonQuery(OpenSqlConnection(), sql, model);
        }

        public bool ExistResult(int planId)
        {
            //
            string sql = @"SELECT COUNT(1)
                          FROM [PlanResult] WHERE PlanId = @PlanId";
            return QuerySingle<int>(OpenSqlConnection(), sql, new { PlanId = planId }) > 0;
        }

    }
}
