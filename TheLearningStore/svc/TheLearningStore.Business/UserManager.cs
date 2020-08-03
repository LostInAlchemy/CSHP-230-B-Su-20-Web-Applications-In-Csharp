using System.Text;
using TheLearningCenter.Repository;

namespace TheLearningCenter.Business
{
    public interface IUserManager
    {
        UserModel LogIn(string userEmail, string userPassword);
        UserModel Register(string userEmail, string userPassword);
        bool UserExist(string userEmail);

        //int GetUser(string userName);

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

        public bool UserExist(string userEmail)
        {
            var user = userRepository.UserExist(userEmail);

            if (user != false)
            {
                return true;
            }

            return false;
        }
        public UserModel LogIn(string userEmail, string userPassword)
        {
            var user = userRepository.LogIn(userEmail, userPassword);

            if (user == null)
            {
                return null;
            }

            return new UserModel { Id = user.Id, Name = user.Name };
        }

        public UserModel Register(string userEmail, string userPassword)
        {
            var user = userRepository.Register(userEmail, userPassword);

            if (user == null)
            {
                return null;
            }

            return new UserModel { Id = user.Id, Name = user.Name };
        }

        //public int GetUser(string userName)
        //{
        //    var userId = UserRepository.GetUser(userName);

        //    return userId;
        //}
    }
}