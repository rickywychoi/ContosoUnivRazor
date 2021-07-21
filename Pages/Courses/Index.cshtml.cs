using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ContosoUniversity.Data;
using ContosoUniversity.Models;
using ContosoUniversity.Models.ViewModels;

namespace ContosoUniversity.Pages.Courses
{
    public class IndexModel : PageModel
    {
        private readonly ContosoUniversity.Data.SchoolContext _context;

        public IndexModel(ContosoUniversity.Data.SchoolContext context)
        {
            _context = context;
        }

        public IList<CourseVM> CourseVM { get; set; }

        public async Task OnGetAsync()
        {
            //Courses = await _context.Courses
            //    .Include(c => c.Department) // eager loading
            //    .AsNoTracking() // no need to be tracked because the entity is not being updated here.
            //    .ToListAsync();
            CourseVM = await _context.Courses
                .Select(p => new CourseVM
                {
                    CourseID = p.CourseID,
                    Title = p.Title,
                    Credits = p.Credits,
                    DepartmentName = p.Department.Name
                }).ToListAsync();
        }
    }
}
