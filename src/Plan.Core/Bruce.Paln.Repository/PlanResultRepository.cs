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
            return QuerySingle<PlanResultEntity>(OpenMsSqlConnection(), sql, new { PlanId = id });
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
            return Execute(OpenMsSqlConnection(), sql, model);
        }

        public int Update(PlanResultEntity model)
        {
            string sql = @"UPDATE [PlanResult]
                               SET [Result] = @Result 
                                  ,[Summary] = @Summary 
                             WHERE [PlanId] = @PlanId";
            return Execute(OpenMsSqlConnection(), sql, model);
        }

        public bool ExistResult(int planId)
        {
            //
            string sql = @"SELECT COUNT(1)
                          FROM [PlanResult] WHERE PlanId = @PlanId";
            return QuerySingle<int>(OpenMsSqlConnection(), sql, new { PlanId = planId }) > 0;
        }

    }
}
