using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bruce.Paln.Entity;
using Bruce.Paln.Repository;

namespace Bruce.Paln.Service
{
    public class LeetAnswerService
    {
        private readonly LeetAnswerRepository _repository;

        public LeetAnswerService()
        {
            _repository = new LeetAnswerRepository();
        }

        public int Insert(LeetAnswerEntity entity)
        {
            return _repository.Insert(entity);
        }
    }
}
