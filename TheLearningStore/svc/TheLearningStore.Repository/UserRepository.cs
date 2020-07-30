using System.Linq;

namespace TheLearningCenter.Repository
{
    public interface IUserRepository
    {
        UserModel LogIn(string userEmail, string userPassword);
        UserModel Register(string userEmail, string userPassword);
        bool UserExist(string userEmail);
    }

    public class UserModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class UserRepository : IUserRepository
    {
        public bool UserExist(string userEmail)
        {
            var user = DatabaseAccessor.Instance.Users
    .FirstOrDefault(t => t.UserEmail.ToLower() == userEmail.ToLower());

            if (user != null)
            {
                return true;
            }

            return false;
        }

        public UserModel LogIn(string userEmail, string userPassword)
        {
            var user = DatabaseAccessor.Instance.Users
                .FirstOrDefault(t => t.UserEmail.ToLower() == userEmail.ToLower()
                                      && t.UserPassword == userPassword);

            if (user == null)
            {
                return null;
            }

            return new UserModel { Id = user.UserId, Name = user.UserEmail };
        }

        public UserModel Register(string userEmail, string userPassword)
        {
            var user = DatabaseAccessor.Instance.Users
                    .Add(new TheLearningCenter.Database.User
                    {
                        UserEmail = userEmail,
                        UserPassword = userPassword
                    });

            DatabaseAccessor.Instance.SaveChanges();

            return new UserModel { Id = user.UserId, Name = user.UserEmail };
        }
    }
}
