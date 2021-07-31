using ContosoUniversity.Data;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContosoUniversity.Pages.Courses
{
    public class DepartmentNamePageModel : PageModel
    {
        public SelectList DepartmentNameSL { get; set; }

        public void PopulateDepartmentsDropDownList(SchoolContext _context, object selectedDepartment = null)
        {
            var departments = _context.Departments.AsNoTracking().Distinct().ToList();

            DepartmentNameSL = new SelectList(departments, "DepartmentID", "Name", selectedDepartment);
        }
    }
}
