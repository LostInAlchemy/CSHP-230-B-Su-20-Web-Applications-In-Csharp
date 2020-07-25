using System.Linq;

namespace Ziggle.Repository
{
    public interface IUserRepository
    {
        UserModel LogIn(string email, string password);
        UserModel Register(string email, string password);
        bool UserExist(string email);
    }








    public class UserModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class UserRepository : IUserRepository
    {
        public bool UserExist(string email)
        {
            var user = DatabaseAccessor.Instance.Users
    .FirstOrDefault(t => t.UserEmail.ToLower() == email.ToLower());

            if (user != null)
            {
                return true;
            }

            return false;
        }

        public UserModel LogIn(string email, string password)
        {
            var user = DatabaseAccessor.Instance.Users
                .FirstOrDefault(t => t.UserEmail.ToLower() == email.ToLower()
                                      && t.UserHashedPassword == password);

            if (user == null)
            {
                return null;
            }

            return new UserModel { Id = user.UserId, Name = user.UserEmail };
        }

        public UserModel Register(string email, string password)
        {
            var user = DatabaseAccessor.Instance.Users
                    .Add(new Ziggle.ProductDatabase.User
                    {
                        UserEmail = email,
                        UserHashedPassword = password
                    });

            DatabaseAccessor.Instance.SaveChanges();

            return new UserModel { Id = user.UserId, Name = user.UserEmail };
        }
    }
}