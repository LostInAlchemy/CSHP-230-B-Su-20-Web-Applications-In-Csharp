
namespace TheLearningStore.WebSite.Models
{
    public class EnrollmentModel
    {
        public int UserId { get; set; }
        public int ClassId { get; set; }

        public EnrollmentModel(int userId, int classId)
        {
            UserId = userId;
            ClassId = classId;
        }
    }
}