using Bruce.Paln.Entity;
using Bruce.Paln.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bruce.Paln.Service
{
    public class SmallNoteService
    {
        private readonly SmallNoteRepository _repository;
        public SmallNoteService()
        {
            _repository = new SmallNoteRepository();
        }

        public int Insert(SmallNoteEntity entity)
        {
            return _repository.Insert(entity);
        }

        public int UpdateNote(int id, string note, int userId)
        {
            return _repository.UpdateNote(id, note, userId);
        }

        public int UpdateState(int id, int state, int userId)
        {
            return _repository.UpdateState(id, state, userId);
        }

        public List<SmallNoteEntity> GetListByState(int userId, int state)
        {
            return _repository.GetSmallNoteListByUserIdAndState(userId, state);
        }

        public int Delete(int id, int userId)
        {
            return _repository.Delete(id, userId);
        }

    }
}
