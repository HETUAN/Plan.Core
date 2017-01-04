using Bruce.Paln.Entity;
using Bruce.Paln.Repository;
namespace Bruce.Paln.Service
{
    public class PlanResultService
    {
        private readonly PlanResultRepository _repository;

        public PlanResultService()
        {
            _repository = new PlanResultRepository();
        }
        public PlanResultEntity GetModel(int id)
        {
            return _repository.GetModel(id);
        }

        public int Insert(PlanResultEntity model)
        {
            return _repository.Insert(model);
        }

        public int Update(PlanResultEntity model)
        {
            return _repository.Update(model);
        }

        public bool ExistResult(int planId)
        {
            return _repository.ExistResult(planId);
        }
    }
}
