namespace MVC5Course.Models
{
    using MVC5Course.DataTypeAttributes;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;

    [MetadataType(typeof(CourseMetaData))]
    public partial class Course : IValidatableObject, IEditCourse
    {
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (this.Credits <= 3 && this.Title.Length > 10)
            {
                throw new ArgumentException("驗證失敗");
                yield return new ValidationResult("當 Credits <= 3 時，課程名稱的長度不能超過 10 個字元", new string[] { "Credits", "Title" });
            }
        }
    }

    public interface IEditCourse
    {
        int CourseID { get; set; }
        string Title { get; set; }
        int Credits { get; set; }
        string Location { get; set; }
    }

    public partial class CourseMetaData
    {
        [Required]
        public int CourseID { get; set; }
        
        [StringLength(40, ErrorMessage="欄位長度不得大於 50 個字元")]
        [驗證標題不允許出現特定文字(Words = new String[] { "MVC", "Water" })]
        [Required]
        [AllowHtml]
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
