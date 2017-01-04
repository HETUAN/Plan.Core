using Bruce.Paln.Entity;
using Bruce.Paln.Entity.ViewModel;
using Bruce.Paln.Repository;
using System.Collections.Generic;

namespace Bruce.Paln.Service
{
    public class NoteService
    {
        private readonly NoteRepository _repository;
        public NoteService()
        {
            _repository = new NoteRepository();
        }


        public NoteEntity GetMode(int id)
        {
            return _repository.GetModel(id);
        }

        public NoteEntity GetLastMode()
        {
            return _repository.GetLastModel();
        }

        public List<NoteViewModel> GetList(int userId)
        {
            return _repository.GetList(userId);
        }

        public List<DailyViewModel> GetList(int userId, int pageIndex, int pageSize, string title, out int rows)
        {
            return _repository.GetList(userId, pageIndex, pageSize, title, out rows);
        }

        public int Insert(NoteEntity model)
        {
            return _repository.Insert(model);
        }

        public int Update(NoteEntity model)
        {
            return _repository.Update(model);
        }

        public int Delete(int id)
        {
            return _repository.Delete(id);
        }
    }
}
