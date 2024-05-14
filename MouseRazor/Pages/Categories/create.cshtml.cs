using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MouseRazor.Data;
using MouseRazor.Model;

namespace MouseRazor.Pages.Categories
{
    public class createModel : PageModel
    {
        private readonly MouseRazorDbContext _context;
        public Category Cat { get; set; } //since we dont need a list of category for creating but just the single Category instance Cat.
        public createModel(MouseRazorDbContext context)
        {
            _context = context;
        }
        public void OnGet()
        {

        }
    }
}
