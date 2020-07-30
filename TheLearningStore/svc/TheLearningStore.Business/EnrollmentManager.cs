//using TheLearningCenter.Repository;

//namespace TheLearningStore.Business
//{
//    public interface IEnrollmentManager
//    {
//        EnrollmentModel Enrolled(int ClassId, int UserId);
//    }

//    public class EnrollmentModel
//    {
//        public int ClassId { get; set; }
//        public int UserId { get; set; }
//    }


//        public class EnrollmentManager : IEnrollmentManager
//        {
//            private readonly IEnrollmentrRepository enrollmentRepository;

//            public EnrollmentManager(IEnrollmentRepository enrollmentRepository)
//            {
//                this.enrollmentRepository = enrollmentRepository;
//            }


//            public EnrollmentModel Enrolled(int classId, int userId)
//            {
//                var enrollment = enrollmentRepository.Enrolled(classId, userId);

//                if (userId == null)
//                {
//                    return null;
//                }

//                return new EnrollmentModel { ClassId = userId.classId, UserId = userId.userId };
//            }
//        }
//    }
