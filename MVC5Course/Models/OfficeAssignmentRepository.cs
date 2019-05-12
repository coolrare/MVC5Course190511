using System;
using System.Linq;
using System.Collections.Generic;
	
namespace MVC5Course.Models
{   
	public  class OfficeAssignmentRepository : EFRepository<OfficeAssignment>, IOfficeAssignmentRepository
	{

	}

	public  interface IOfficeAssignmentRepository : IRepository<OfficeAssignment>
	{

	}
}