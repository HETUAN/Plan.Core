using Bruce.Paln.Entity.ViewModel; 

namespace Bruce.Paln.Repository
{
    public class UserRepository : BaseRepository
    {
        public UserViewModel GetViewModel(string userName, string passWord)
        {
            //
            string sql = @"SELECT [UserID] 
                              ,[UserName]
                              ,[Name]
                              ,[Sex] 
                              ,[Email] 
                          FROM [Users] WHERE UserName = @UserName AND PassWord = @PassWord";
            return QuerySingle<UserViewModel>(OpenSqlConnection(), sql, new { UserName = userName, PassWord = passWord });
        }

        public int UserExist(int id, string passWord)
        {
            //
            string sql = @"SELECT COUNT(UserID)
                          FROM [Users] WHERE UserID = @UserID AND PassWord = @PassWord";
            return QuerySingle<int>(OpenSqlConnection(), sql, new { UserID = id, PassWord = passWord });
        }

        public UserViewModel GetViewModel(int userId)
        {
            //
            string sql = @"SELECT [UserName]
                              ,[Name]
                              ,[Sex] 
                              ,[Email] 
                          FROM [Users] WHERE UserID = @UserID";
            return QuerySingle<UserViewModel>(OpenSqlConnection(), sql, new { UserID = userId });
        }
    }
}
