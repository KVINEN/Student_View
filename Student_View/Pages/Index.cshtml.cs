using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Student_View.Entity;

namespace Student_View.Pages
{
    public class IndexModel : PageModel
    {
        private readonly Context _context;
        public IndexModel(Context context)
        {
            _context = context;
        }
        public List<Student> AllStudents { get; set; } = new();
        public List<Course> AllCourses { get; set; } = new();

        [BindProperty (SupportsGet = true)]
        public string? Sok { get; set; }

        [BindProperty(SupportsGet = true)]
        public string? SelectedCourse { get; set; }

        public void OnGet()
        {
            AllCourses = _context.Courses.ToList();

            var studentQuery = _context.Students
                .Include(s => s.Grades)
                .AsQueryable();

            if (!string.IsNullOrEmpty(Sok))
            {
                studentQuery = studentQuery.Where(s => s.Studentname.Contains(Sok));
            }

            if (!string.IsNullOrEmpty(SelectedCourse))
            {
                studentQuery = studentQuery.Where(s => s.Grades.Any(g => g.Coursecode == SelectedCourse));
            }

            AllStudents = studentQuery.ToList();
        }
    }
}
