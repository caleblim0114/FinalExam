using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FinalExam.Pages
{
    public class ConvertLengthModel : PageModel
    {
        [BindProperty]
        public int ConvertType { get; set; }

        [BindProperty]
        public int? InputLength { get; set; }

        [BindProperty]
        public int? OutputLength { get; set; }
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            return Page();
        }
    }
}
