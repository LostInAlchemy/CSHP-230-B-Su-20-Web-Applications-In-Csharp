//using System.Linq;
//using TheLearningCenter.Repository;

//namespace Ziggle.Business
//{
//    public interface IEnrollmentManager
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

//    public class EnrollmentManager : IEnrollmentManager
//    {
//        private readonly IEnrollmentRepository enrollmentRepository;

//        public EnrollmentManager(IEnrollmentRepository enrollmentRepository)
//        {
//            this.enrollmentRepository = enrollmentRepository;
//        }

//        public EnrollmentModel Add(int userId, int classId)
//        {
//            var userclass = enrollmentRepository.Add(userId, classId);

//            return new EnrollmentModel
//            {
//                UserId = userclass.UserId,
//                ClassId = userclass.ClassId
//            };
//        }

//        public EnrollmentModel[] GetAll(int userId)
//        {
//            var items = enrollmentRepository.GetAll(userId)
//                .Select(t => new EnrollmentModel
//                {
//                    UserId = t.UserId,
//                    ClassId = t.ClassId,
//                })
//                .ToArray();

//            return items;
//        }

//        public bool Remove(int userId, int productId)
//        {
//            return enrollmentRepository.Remove(userId, productId);
//        }
//    }
//}