using System;
using System.Collections.Generic;
using Bruce.Paln.Entity.ViewModel;
using Bruce.Paln.Repository;

namespace Bruce.Paln.Service
{
    public class KeyCountService
    {
        private readonly KeyCountRepository _repository;

        public KeyCountService()
        {
            _repository = new KeyCountRepository();
        }

        public List<KeyCountViewModel> GetLast7DayViewModels(int userId)
        {
            return _repository.GetLast7DayViewModels(userId);
        }

        public List<KeyCountViewModel> GetViewModels(int userId, DateTime sday, DateTime eday)
        {
            return _repository.GetViewModels(userId, sday, eday);
        }
    }
}
