using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MouseRazor.Data;
using MouseRazor.Model;

namespace MouseRazor.Pages.Categories
{   //[BindProperties] This works as well but for all the properties in the page.
    public class createModel : PageModel
    {
        
        private readonly MouseRazorDbContext _context;
        [BindProperty] //This makes sure the OnPost recieves the Cat obj unlike in MVC it works slightly different. No need to put parameter in OnPost
        public Category Cat { get; set; } //since we dont need a list of category for creating but just the single Category instance Cat.
        public createModel(MouseRazorDbContext context)
        {
            _context = context;
        }
        public void OnGet()
        {

        }
        public IActionResult OnPost()
        {
            _context.Add(Cat); //direcly we can add this unlike in MVC compare it once to get clear details on how this works.
            _context.SaveChanges();
            return RedirectToPage("Index"); //redirect to action ko satta redirect to page.
        }
    }
}
