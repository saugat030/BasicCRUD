using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MouseRazor.Data;
using MouseRazor.Model;

namespace MouseRazor.Pages.Categories
{
    public class IndexModel : PageModel
    {   
        private readonly MouseRazorDbContext _context;
        public List<Category> CategoriesList { get; set; }
        public IndexModel(MouseRazorDbContext context)
        {
            _context = context;
        }
        public void OnGet()
        {
            CategoriesList = _context.Categs.ToList();  
        }
    }
}
