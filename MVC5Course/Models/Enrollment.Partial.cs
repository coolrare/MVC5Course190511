namespace MVC5Course.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    [MetadataType(typeof(EnrollmentMetaData))]
    public partial class Enrollment
    {
    }
    
    public partial class EnrollmentMetaData
    {
        [Required]
        public int EnrollmentID { get; set; }
        [Required]
        public int CourseID { get; set; }
        [Required]
        public int StudentID { get; set; }
        public Nullable<int> Grade { get; set; }
    
        public virtual Course Course { get; set; }
        public virtual Person Person { get; set; }
    }
}
