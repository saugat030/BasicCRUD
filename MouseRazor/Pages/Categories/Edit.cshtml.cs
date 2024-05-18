using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MouseRazor.Data;
using MouseRazor.Model;

namespace MouseRazor.Pages.Categories
{
    public class EditModel : PageModel
    {
        private readonly MouseRazorDbContext _context;
        [BindProperty] //This makes sure the OnPost recieves the Cat obj unlike in MVC it works slightly different. No need to put parameter in OnPost
        public Category Cat { get; set; } //since we dont need a list of category for creating but just the single Category instance Cat.
        public EditModel(MouseRazorDbContext context)
        {
            _context = context;
        }
        public void OnGet(int? id)
        {
            if (id != null && id != 0)
            {
                Cat = _context.Categs.Find(id);
            }

        }
        public IActionResult OnPost()
        {
            if (Cat.Name == Cat.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "The display order cant match the name.");//"name" le chai name model sanga bind handinxa.
            }
            if (ModelState.IsValid)
            {
                _context.Categs.Update(Cat);
                _context.SaveChanges();
                //TempData["notif"] = "category updated successfully.";
                return RedirectToPage("Index");
            }
            return Page(); //If error occured then stay in the Create page. Dont go to Index this is differnt in MVC.
        }
    }
}
