using System.Linq;
using TheLearningCenter.Repository;

namespace TheLearningCenter.Business
{
    public interface IClassManager
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

        public ClassModel(int classID, string className, string classDescription, decimal classPrice)
        {
            ClassID = classID;
            ClassName = className;
            ClassDescription = classDescription;
            ClassPrice = classPrice;
        }
    }

    public class ClassManager : IClassManager
    {
        private readonly IClassRepository classRepository;

        public ClassManager(IClassRepository classRepository)
        {
            this.classRepository = classRepository;
        }

        public ClassModel[] Classes
        {
            get
            {
                return classRepository.Classes
                                         .Select(t => new ClassModel(t.ClassID, t.ClassName, t.ClassDescription, t.ClassPrice))
                                         .ToArray();
            }
        }

        public ClassModel Class(int classID)
        {
            var classModel = classRepository.Class(classID);
            return new ClassModel(classModel.ClassID, classModel.ClassName, classModel.ClassDescription, classModel.ClassPrice);
        }
    }
}
