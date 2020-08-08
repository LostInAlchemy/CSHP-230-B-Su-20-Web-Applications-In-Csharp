using System.Linq;
using TheLearningCenter.Repository;

namespace TheLearningCenter.Business
{
    public interface IEnrollmentManager
    {
        EnrollmentModel Add(int userId, int classId);
        ClassModel[] GetAll(int userId);
    }

    public class EnrollmentModel
    {
        public int UserId { get; set; }
        public int ClassId { get; set; }
    }

    public class EnrollmentManager : IEnrollmentManager
    {
        private readonly IEnrollmentRepository enrollmentRepository;

        public EnrollmentManager(IEnrollmentRepository enrollmentRepository)
        {
            this.enrollmentRepository = enrollmentRepository;
        }

        public EnrollmentModel Add(int userId, int classId)
        {
            var userclass = enrollmentRepository.Add(userId, classId);

            return new EnrollmentModel { UserId = userclass.UserId, ClassId = userclass.ClassID };
        }

        public ClassModel[] GetAll(int userId)
        {
            return enrollmentRepository.GetAll(userId)
                              .Select(t => new ClassModel(t.ClassId, t.ClassName, t.ClassDescription, t.ClassPrice))
                              .ToArray();
        }
    }
}