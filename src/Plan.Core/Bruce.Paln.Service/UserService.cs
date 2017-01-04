using Bruce.Paln.Entity.ViewModel;
using Bruce.Paln.Repository;

namespace Bruce.Paln.Service
{
    public class UserService
    {
        private readonly UserRepository _repository;

        public UserService()
        {
            _repository = new UserRepository();
        }

        public UserViewModel GetViewModel(int userId)
        {
            return _repository.GetViewModel(userId);
        }
        public UserViewModel GetViewModel(string userName, string passWord)
        {
            return _repository.GetViewModel(userName, passWord);
        }

        public int UserExist(int id, string passWord)
        {
            return _repository.UserExist(id, passWord);
        }
    }
}
