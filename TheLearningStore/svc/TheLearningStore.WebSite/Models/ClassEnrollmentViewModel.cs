using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TheLearningCenter.Business;

namespace TheLearningCenter.WebSite.Models
{
    public class ClassEnrollmentViewModel
    {

        protected void doIt(object sender, EventArgs e)
        {
           
        }

        //protected void ddlTest_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    string selectedText = ddlTest.SelectedItem.Text;
        //    string selectedValue = ddlTest.SelectedItem.Value;

        //    //--- Show results in page.
        //    Response.Write("Selected Text is " + selectedText + " and selected value is :" + selectedValue);
        //}

        //private readonly List<ClassModel> _classes;
        //private readonly IClassManager classManager;

        //[Display(Name = "Enroll In Class")]
        //public int SelectedClassId { get; set; }
        //public int UserId { get; set; }
        ////public IEnumerable<SelectListItem> ClassItems
        ////{
        ////    get { return new SelectList(_classes, "Id", "Name"); }
        ////}

        //public IEnumerable<SelectListItem> ClassItems
        //{
        //    get
        //    {
        //        var classes = classManager.Classes
        //                                   .Select(t =>
        //                                   new TheLearningCenter.WebSite.Models.ClassModel
        //                                   (
        //                                       t.ClassID,
        //                                   t.ClassName
        //                                   )).ToArray();

        //        foreach (ClassModel item in classes)
        //        {
        //            _classes.Add(item);
        //        }


        //        var allClasses = _classes.Select(f => new SelectListItem
        //        {
        //            Value = f.ClassId.ToString(),
        //            Text = f.ClassName
        //        });
        //        return DefaultClassItem.Concat(allClasses);

        //    }
        //}

        //public IEnumerable<SelectListItem> DefaultClassItem
        //{
        //    get
        //    {
        //        return Enumerable.Repeat(new SelectListItem
        //        {
        //            Value = "-1",
        //            Text = "Select a flavor"
        //        }, count: 1);
        //    }
        //}


    }
}