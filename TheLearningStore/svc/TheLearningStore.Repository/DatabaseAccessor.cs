using TheLearningCenter.Database;

namespace TheLearningCenter.Repository
{
    public class DatabaseAccessor
    {
        private static readonly Entities2 entities;

        static DatabaseAccessor()
        {
            entities = new Entities2();
            entities.Database.Connection.Open();
        }

        public static Entities2 Instance
        {
            get
            {
                return entities;
            }
        }
    }
}
