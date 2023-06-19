using FinalExam.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FinalExam.Pages
{
    public class Question2Model : PageModel
    {
        [BindProperty]
        public StudentMark? NewStudentMark { get; set; }

        [BindProperty]
        public string Grade {  get; set; }

        public class StudentRecord
        {
            public int Id { get; set; }
            public string? Name { get; set; }
            public int? Marks { get; set; }
            public string? StudentGrade { get; set; }
        }

        [BindProperty]
        public List<StudentRecord> Students { get; set; } = new List<StudentRecord>();

        private readonly ILogger<Question2Model> _logger;
        private readonly FinalExamDatabaseContext _databaseContext;

        public Question2Model(ILogger<Question2Model> logger, FinalExamDatabaseContext databaseContext)
        {
            _logger = logger;
            _databaseContext = databaseContext;
        }

        public void OnGet()
        {
            var studentList = _databaseContext.StudentMark
                .ToList();

            foreach (var student in studentList)
            {
                if (student.Marks >= 0 && student.Marks < 50)
                {
                    Grade = "F";
                } 
                else if (student.Marks >= 50 && student.Marks < 60)
                {
                    Grade = "D";
                }
                else if (student.Marks >= 60 && student.Marks < 70)
                {
                    Grade = "C";
                }
                else if (student.Marks >= 70 && student.Marks < 80)
                {
                    Grade = "B";
                }
                else if (student.Marks >= 80 && student.Marks<=100)
                {
                    Grade = "A";
                }
                else
                {
                    Grade = "Invalid";
                }

                Students.Add(new StudentRecord
                {
                    Id = student.Id,
                    Name = student.Name,
                    Marks = student.Marks,
                    StudentGrade = Grade
                }); 
            }
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (NewStudentMark.Name == null && NewStudentMark.Marks == null)
            {
                return Page();
            }

            if (NewStudentMark != null) _databaseContext.StudentMark.Add(NewStudentMark);
            await _databaseContext.SaveChangesAsync();

            return RedirectToPage("./Question2");
        }
    }
}
