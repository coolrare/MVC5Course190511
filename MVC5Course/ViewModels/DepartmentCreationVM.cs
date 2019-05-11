using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MVC5Course.ViewModels
{
    public class DepartmentCreationVM
    {
        public DepartmentCreationVM()
        {
        }

        [Required]
        public string Name { get; set; }
        [Required]
        public decimal Budget { get; set; }
        [Required]
        public System.DateTime StartDate { get; set; }
    }
}