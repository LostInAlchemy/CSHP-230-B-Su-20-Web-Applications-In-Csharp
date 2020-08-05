using System.Linq;
using TheLearningCenter.Database;

namespace TheLearningCenter.Repository
{
    public interface IEnrollmentRepository
    {
        bool Add(int userId, int classId);
        //bool Remove(int userId, int classId);
        Class[] GetAll(int userId);
    }

    public class EnrollmentRepository : IEnrollmentRepository
    {
        public bool Add(int userId, int classId)
        {
            //var userclass = DatabaseAccessor.Instance.Classes.Add(UserModel);

            //DatabaseAccessor.Instance.Classes.

            // User.Add(classId);

            //(new EnrollmentModel
            // {
            //     UserId = userId,
            //     ClassId = classId
            // });

            //DatabaseAccessor.Instance.SaveChanges();



            //return new EnrollmentModel
            //{
            //    UserId = userclass.Entity.UserId,
            //    ClassId = userclass.Entity.ClassId
            //};



            var newClass = DatabaseAccessor.Instance.Classes.First(t => t.ClassId == classId);
            var user = DatabaseAccessor.Instance.Users.First(t => t.UserId == userId);
            user.Classes.Add(newClass);
            //newClass.Users.Add(user);


            return true;




           // return null;


        }









        public Class[] GetAll(int userId)
        {
            var user = DatabaseAccessor.Instance.Users.First(t => t.UserId == userId);
            return user.Classes.ToArray();
        }

        //public bool Remove(int userId, int classId)
        //{
        //    var userClass = DatabaseAccessor.Instance.Users
        //                        .Where(t => t.Users.Contains(userId)
        //                            && t.Classes.Contains(classId);

        //    if (userClass.Count() == 0)
        //    {
        //        return false;
        //    }

        //    DatabaseAccessor.Instance.Users.Remove(userClass.First());

        //    DatabaseAccessor.Instance.SaveChanges();

        //    return true;
        //}
    }
}
