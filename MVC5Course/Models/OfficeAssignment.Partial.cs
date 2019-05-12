namespace MVC5Course.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    [MetadataType(typeof(OfficeAssignmentMetaData))]
    public partial class OfficeAssignment
    {
    }
    
    public partial class OfficeAssignmentMetaData
    {
        [Required]
        public int InstructorID { get; set; }
        
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        public string Location { get; set; }
    
        public virtual Person Person { get; set; }
    }
}
