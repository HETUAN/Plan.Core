using Bruce.Paln.Entity;
using Bruce.Paln.Entity.ViewModel;
using Bruce.Paln.Repository;
using System;
using System.Collections.Generic;

namespace Bruce.Paln.Service
{
    public class WeeklyService
    {
        private readonly WeeklyRepository _repository;
        public WeeklyService()
        {
            _repository = new WeeklyRepository();
        }


        public WeeklyEntity GetMode(int userId, DateTime date)
        {
            return _repository.GetModel(userId, date);
        }

        public List<WeeklyViewModel> GetList(int userId)
        {
            return _repository.GetList(userId);
        }

        public int Insert(WeeklyEntity model)
        {
            return _repository.Insert(model);
        }

        public int Update(WeeklyEntity model)
        {
            return _repository.Update(model);
        }

        public int Delete(int id)
        {
            return _repository.Delete(id);
        }
    }
}
