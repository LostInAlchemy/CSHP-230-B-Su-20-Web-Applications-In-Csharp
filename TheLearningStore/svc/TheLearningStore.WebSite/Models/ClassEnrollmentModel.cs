using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TheLearningCenter.WebSite.Models
{
    public class ClassEnrollmentModel
    {
        private readonly List<ClassModel> _classes;

        [Display(Name = "Enroll In Class")]
        public int SelectedClassId { get; set; }

        //public IEnumerable<SelectListItem> ClassItems
        //{
        //    get { return new SelectList(_classes, "Id", "Name"); }
        //}

        public IEnumerable<SelectListItem> ClassItems
        {
            get
            {
                var allClasses = _classes.Select(f => new SelectListItem
                {
                    Value = f.ClassId.ToString(),
                    Text = f.ClassName.ToString()
                });
                return DefaultClassItem.Concat(allClasses);

            }
        }

        public IEnumerable<SelectListItem> DefaultClassItem
        {
            get
            {
                return Enumerable.Repeat(new SelectListItem
                {
                    Value = "-1",
                    Text = "Select a flavor"
                }, count: 1);
            }
        }


    }
}