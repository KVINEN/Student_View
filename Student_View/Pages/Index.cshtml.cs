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

        [BindProperty (SupportsGet = true)]
        public string? Sok { get; set; }
        public void OnGet()
        {
            if(!string.IsNullOrEmpty(Sok))
            {
                AllStudents = _context.Students
                    .Where(s => s.Studentname.Contains(Sok))
                    .Include(s => s.Grades)
                    .ToList();
            }
            else
            {
                AllStudents = _context.Students
                    .Include(s => s.Grades)
                    .ToList();
            }
        }
    }
}
