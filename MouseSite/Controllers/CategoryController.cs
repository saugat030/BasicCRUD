using Microsoft.AspNetCore.Mvc;
using Mouse.DataAccess.Data;
using Mouse.Models;

namespace MouseSite.Controllers
{
    public class CategoryController : Controller
    {   private readonly MouseDbContext _db;
        public CategoryController(MouseDbContext db)
        {
                _db = db;
        }
        public IActionResult Index()
        {
            List<Categ> categObj = _db.Categs.ToList(); 
            return View(categObj);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Categ obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "The display order cant match the name.");//"name" le chai name model sanga bind handinxa.
            }
            if (ModelState.IsValid)
            {
                _db.Categs.Add(obj);
                _db.SaveChanges();
               TempData["notif"] = "category created successfully.";
                return RedirectToAction("Index");
            }
            return View(); //If error occured then stay in the Create page. Dont go to Index
        }
        public IActionResult Edit(int? id) //m ra tyoDherai Important kura : yo ko naa "asp-route-..." ma pass gareko name same hunu parxa
        {
            Categ? editionObj = _db.Categs.FirstOrDefault(x=>x.CategoryId==id); // can use any moethod to retrieve data just that FirstOrDefault is prefered.
           // Categ? editionObj = _db.Categs.Where(x => x.CategoryId == idd).FirstOrDefault();//This is LINQ method obviously. That idd gets passed from the view of Index page of CategoryController. Refer to that.
            if (editionObj == null){ 
                return NotFound(editionObj);  
            }
                return View(editionObj);
        }
        [HttpPost]
        public IActionResult Edit(Categ obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "The display order cant match the name.");//"name" le chai name model sanga bind handinxa.
            }
            if (ModelState.IsValid)
            {
                _db.Categs.Update(obj);
                _db.SaveChanges();
                TempData["notif"] = "category updated successfully.";
                return RedirectToAction("Index");
            }
            return View(); //If error occured then stay in the Create page. Dont go to Index
        }
        public IActionResult Delete(int? id)
        {
            Categ? editionObj = _db.Categs.FirstOrDefault(x => x.CategoryId == id); 
            return View(editionObj);
        }
        [HttpPost , ActionName("Delete")]
        public IActionResult DeletePost(int? id)
        {
            Categ? obj = _db.Categs.FirstOrDefault(x => x.CategoryId == id);
            if (obj == null)
            {
                return NotFound();
            }
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "The display order cant match the name."); //"name" le chai name model sanga bind handinxa. Why lowercase? Dont ask.
            }
            if (ModelState.IsValid)
            {
                _db.Categs.Remove(obj);
                _db.SaveChanges();
                TempData["notif"] = "category deleted successfully.";
                return RedirectToAction("Index");
            }
            return View(); //If error occured then stay in the Create page. Dont go to Index
        }
    }
}
    

