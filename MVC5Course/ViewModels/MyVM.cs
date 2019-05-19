using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC5Course.ViewModels
{
    public class MyVM
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int Count { get; set; }
    }
}