using System.Text;
using Ziggle.Repository;

namespace Ziggle.Business
{
    public interface IUserManager
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

    public class UserManager : IUserManager
    {
        private readonly IUserRepository userRepository;

        public UserManager(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public bool UserExist(string email)
        {
            var user = userRepository.UserExist(email);

            if (user != false)
            {
                return true;
            }

            return false;
        }
        public UserModel LogIn(string email, string password)
        {
            var user = userRepository.LogIn(email, password);

            if (user == null)
            {
                return null;
            }

            return new UserModel { Id = user.Id, Name = user.Name };
        }

        public UserModel Register(string email, string password)
        {
            var user = userRepository.Register(email, password);

            if (user == null)
            {
                return null;
            }

            return new UserModel { Id = user.Id, Name = user.Name };
        }
    }
}