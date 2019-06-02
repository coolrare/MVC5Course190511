using System;
using System.Linq;
using System.Collections.Generic;
	
namespace MVC5Course.Models
{   
	public  class CourseRepository : EFRepository<Course>, ICourseRepository
	{
        public Course Find(int id)
        {
            return this.All().Where(p => p.CourseID == id).FirstOrDefault();
        }

        public override IQueryable<Course> All()
        {
            return base.All().Where(p => p.Credits >= 1).OrderBy(p => p.CourseID);
        }

        public IQueryable<Course> Get©Ò¦³Git½Òµ{()
        {
            return this.All().Where(p => p.Title.Contains("Git"));
        }
    }

	public  interface ICourseRepository : IRepository<Course>
	{

	}
}