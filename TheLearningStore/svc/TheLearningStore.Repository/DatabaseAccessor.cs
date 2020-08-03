using TheLearningCenter.Database;

namespace TheLearningCenter.Repository
{
    public class DatabaseAccessor
    {
        private static readonly Entities entities;

        static DatabaseAccessor()
        {
            entities = new Entities();
            entities.Database.Connection.Open();
        }

        public static Entities Instance
        {
            get
            {
                return entities;
            }
        }
    }
}
