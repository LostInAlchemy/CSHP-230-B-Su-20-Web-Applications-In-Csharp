using System.Linq;
using TheLearningCenter.Database;

namespace TheLearningCenter.Repository
{
    public interface IEnrollmentRepository
    {
        EnrollmentModel Add(int userId, int classId);
        Class[] GetAll(int userId);
    }

    public class EnrollmentModel
    {
        public int UserId { get; set; }
        public int ClassID { get; set; }
    }
    public class EnrollmentRepository : IEnrollmentRepository
    {
        public EnrollmentModel Add(int userId, int classId)
        {
            var newClass = DatabaseAccessor.Instance.Classes.First(t => t.ClassId == classId);
            var user = DatabaseAccessor.Instance.Users.First(t => t.UserId == userId);
            
            user.Classes.Add(newClass);
            DatabaseAccessor.Instance.SaveChanges();

            return new EnrollmentModel { UserId = user.UserId, ClassID = newClass.ClassId } ;
        }

        public Class[] GetAll(int userId)
        {
            var user = DatabaseAccessor.Instance.Users.First(t => t.UserId == userId);
            return user.Classes.ToArray();
        }
    }
}