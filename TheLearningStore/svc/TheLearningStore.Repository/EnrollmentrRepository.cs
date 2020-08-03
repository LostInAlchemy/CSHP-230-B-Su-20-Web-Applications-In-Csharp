//using System.Linq;
//using TheLearningCenter.Database;

//namespace TheLearningCenter.Repository
//{
//    public interface IEnrollmentRepository
//    {
//        EnrollmentModel Add(int userId, int classId);
//        bool Remove(int userId, int classId);
//        EnrollmentModel[] GetAll(int userId);
//    }

//    public class EnrollmentModel
//    {
//        public int UserId { get; set; }
//        public int ClassId { get; set; }
//    }

//    public class EnrollmentRepository : IEnrollmentRepository
//    {
//        public EnrollmentModel Add(int userId, int classId)
//        {
//            var userclass = DatabaseAccessor.Instance.Classes.Add(UserModel);



//            // User.Add(classId);

//            //(new EnrollmentModel
//            // {
//            //     UserId = userId,
//            //     ClassId = classId
//            // });

//            DatabaseAccessor.Instance.SaveChanges();

//            return new EnrollmentModel
//            {
//                UserId = userclass.Entity2.UserId,
//                ClassId = userclass.Entity2.ClassId
//            };





//        }









//        public EnrollmentModel[] GetAll(int userId)
//        {
//            var classes = DatabaseAccessor.Instance.UserClass
//                .Where(t => t.UserId == userId)
//                .Select(t => new EnrollmentModel
//                {
//                    UserId = t.UserId,
//                    ClassId = t.ClassId,
//                })
//                .ToArray();
//            return classes;
//        }

//        public bool Remove(int userId, int classId)
//        {
//            var userClass = DatabaseAccessor.Instance.UserClass
//                                .Where(t => t.Users.Contains(userId)
//                                    && t.ClassId == classId);

//            if (userClass.Count() == 0)
//            {
//                return false;
//            }

//            DatabaseAccessor.Instance.UserClass.Remove(userClass.First());

//            DatabaseAccessor.Instance.SaveChanges();

//            return true;
//        }
//    }
//}
