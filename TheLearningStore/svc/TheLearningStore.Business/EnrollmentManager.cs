using System.Linq;
using TheLearningCenter.Repository;

namespace TheLearningCenter.Business
{
    public interface IEnrollmentManager
    {
        bool Add(int userId, int classId);
        //bool Remove(int userId, int classId);
        //ClassModel[] GetAll(int userId);
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

        public bool Add(int userId, int classId)
        {
            var userclass = enrollmentRepository.Add(userId, classId);

            return true;
            //return new EnrollmentModel
            //{
            //    UserId = userclass.UserId,
            //    ClassId = userclass.ClassId
            //};
        }

        //public ClassModel[] GetAll(int userId)
        //{

        //    var EnrolledClasses = enrollmentRepository.GetAll

        //                                  .Select(t => new ClassModel(t.ClassID, t.ClassName, t.ClassDescription, t.ClassPrice))
        //                                  .ToArray();
        //    return EnrolledClasses;
        //}

        //public bool Remove(int userId, int productId)
        //{
        //    return enrollmentRepository.Remove(userId, productId);
        //}
    }
}