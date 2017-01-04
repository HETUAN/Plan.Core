using Bruce.Paln.Entity;
using Bruce.Paln.Entity.ViewModel;
using Bruce.Paln.Repository;
using System;
using System.Collections.Generic;

namespace Bruce.Paln.Service
{
    public class DailyService
    {
        private readonly DailyRepository _repository;
        public DailyService()
        {
            _repository = new DailyRepository();
        }


        public DailyEntity GetModel(int userId, DateTime date)
        {
            return _repository.GetModel(userId, date);
        }

        public DailyEntity GetModel(int id)
        {
            return _repository.GetModel(id);
        }

        public List<DailyViewModel> GetList(int userId)
        {
            return _repository.GetList(userId);
        }

        public List<DailyViewModel> GetList(int userId, int pageIndex, int pageSize, string title, DateTime? date, out int rows)
        {
            return _repository.GetList(userId, pageIndex, pageSize, title, date, out rows);
        }

        public int Insert(DailyEntity model)
        {
            return _repository.Insert(model);
        }

        public int Update(DailyEntity model)
        {
            return _repository.Update(model);
        }

        public int Delete(int id)
        {
            return _repository.Delete(id);
        }

        public int Count(DateTime today)
        {
            return _repository.Count(today);
        }

        public bool Exist(int id)
        {
            return _repository.Exist(id);
        }
    }
}
