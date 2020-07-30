//using System.Linq;

//namespace TheLearningCenter.Repository
//{
//    public interface IEnrollmentRepository
//    {
//        EnrollmentModel Enrolled(int ClassId, int UserId);
//    }

//    public class EnrollmentModel
//    {
//        public int ClassId { get; set; }
//        public int UserId { get; set; }
//    }

//    public class EnrollmentRepository : IEnrollmentRepository
//    {
//        public EnrollmentModel Enrolled(int ClassId, int UserId)
//        {

//            /// Need to access table UserClass
//            /// 


//            var user = DatabaseAccessor.Instance.UserClass
//                //.FirstOrDefault(t => t.UserEmail.ToLower() == userEmail.ToLower()
//                //                      && t.UserPassword == userPassword);

//            if (user == null)
//            {
//                return null;
//            }

//            return new UserModel { Id = user.UserId, Name = user.UserEmail };
//        }


//    }
//}
