using System.Linq;

namespace TheLearningCenter.Repository
{
    public interface IClassRepository
    {
        ClassModel[] Classes { get; }
        ClassModel Class(int classID);
    }

    public class ClassModel
    {
        public int ClassID { get; set; }
        public string ClassName { get; set; }
        public string ClassDescription { get; set; }
        public decimal ClassPrice { get; set; }
    }

    public class ClassRepository : IClassRepository
    {
        public ClassModel[] Classes
        {
            get
            {
                return DatabaseAccessor.Instance.Classes
                                               .Select(t => new ClassModel { ClassID = t.ClassId,
                                                                                ClassName = t.ClassName,
                                                                                ClassDescription = t.ClassDescription,
                                                                                ClassPrice = t.ClassPrice })
                                               .ToArray();
            }
        }

        public ClassModel Class(int classID)
        {
            var Class = DatabaseAccessor.Instance.Classes
                                                   .Where(t => t.ClassId == classID)
                                                   .Select(t => new ClassModel { ClassID = t.ClassId,
                                                                                    ClassName = t.ClassName,
                                                                                    ClassDescription = t.ClassDescription,
                                                                                    ClassPrice = t.ClassPrice})
                                                   .First();
            return Class;
        }
    }
}
