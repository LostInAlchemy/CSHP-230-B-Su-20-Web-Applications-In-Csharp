namespace TheLearningCenter.WebSite.Models
{
    public class ClassPageModel
    {
        //public int ClassId { get; set; }
        //public string ClassName { get; set; }
        //public string ClassDescription { get; set; }
        //public decimal ClassPrice { get; set; }


        //public ClassModel(int classId, string className, string classDescription, decimal classPrice)
        //{
        //    ClassId = classId;
        //    ClassName = className;
        //    ClassDescription = classDescription;
        //    ClassPrice = classPrice;
        //}

        public ClassModel[] Classes { get; set; }
    }
}