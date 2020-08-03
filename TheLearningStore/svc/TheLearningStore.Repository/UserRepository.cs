﻿using System.Diagnostics.Eventing.Reader;
using System.Linq;
using TheLearningCenter.Database;

namespace TheLearningCenter.Repository
{
    public interface IUserRepository
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

    public class UserRepository : IUserRepository
    {
        //public object HttpContext { get; private set; }

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


        //public int GetUser(string userName)
        //{
        //    var userId = DatabaseAccessor.Instance.Users
        //        .Where(t => t.UserEmail == userName)
        //        .Select(u => u.UserId)
        //        .FirstOrDefault();

        //    return userId;
        //}
    }
}