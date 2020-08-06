namespace TheLearningCenter.WebSite.Models
{
    internal class EnrollmentModel
    {
        private int userID;
        private string classID;


        public EnrollmentModel(int userId, string classID)
        {
            this.userID = userID;
            this.classID = classID;
        }
    }
}