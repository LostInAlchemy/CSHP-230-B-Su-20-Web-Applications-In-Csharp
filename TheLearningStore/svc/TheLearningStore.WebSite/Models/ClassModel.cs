using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TheLearningCenter.WebSite.Models
{
    public class ClassModel
    {
        public int ClassId { get; set; }
        public string ClassName { get; set; }
        public string ClassDescription { get; set; }
        public decimal ClassPrice { get; set; }


        public ClassModel(int classId, string className, string classDescription, decimal classPrice)
        {
            ClassId = classId;
            ClassName = className;
            ClassDescription = classDescription;
            ClassPrice = classPrice;
        }
    }
}