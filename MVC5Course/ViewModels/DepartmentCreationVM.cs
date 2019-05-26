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

        public int DepartmentId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public decimal Budget { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public System.DateTime StartDate { get; set; }
    }


    public class DepartmentBatchUpdateVM
    {
        [Required]
        public int DepartmentId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public decimal Budget { get; set; }
    }
}