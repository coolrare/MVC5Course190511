using System;
using System.Linq;
using System.Collections.Generic;
	
namespace MVC5Course.Models
{   
	public  class DepartmentRepository : EFRepository<Department>, IDepartmentRepository
	{

	}

	public  interface IDepartmentRepository : IRepository<Department>
	{

	}
}