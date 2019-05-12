namespace MVC5Course.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    [MetadataType(typeof(CourseMetaData))]
    public partial class Course
    {
    }
    
    public partial class CourseMetaData
    {
        [Required]
        public int CourseID { get; set; }
        
        [StringLength(40, ErrorMessage="欄位長度不得大於 50 個字元")]
        public string Title { get; set; }
        [Required]
        [Range(1, 5, ErrorMessage = "Credits 請輸入 1 ~ 5")]
        public int Credits { get; set; }
        [Required]
        public int DepartmentID { get; set; }
        
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        public string Location { get; set; }
    
        public virtual Department Department { get; set; }
        public virtual ICollection<Enrollment> Enrollment { get; set; }
        public virtual ICollection<Person> Person { get; set; }
    }
}
