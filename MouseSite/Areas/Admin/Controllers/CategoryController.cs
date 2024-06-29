using Microsoft.AspNetCore.Mvc;
using Mouse.DataAccess.Data;
using Mouse.DataAccess.Repository;
using Mouse.Models;

namespace MouseSite.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {   private readonly IUnitOfWork _unitOfWork;
        public CategoryController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            List<Categ> categObj = _unitOfWork.Category.GetAll().ToList(); 
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
                _unitOfWork.Category.Add(obj);
                _unitOfWork.Save();
               TempData["notif"] = "category created successfully.";
                return RedirectToAction("Index");
            }
            return View(); //If error occured then stay in the Create page. Dont go to Index
        }
        public IActionResult Edit(int? id) //m ra tyoDherai Important kura : yo ko naa "asp-route-..." ma pass gareko name same hunu parxa
        {
            Categ? editionObj = _unitOfWork.Category.Get(x=>x.CategoryId==id); // can use any moethod to retrieve data just that FirstOrDefault is prefered.
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
                _unitOfWork.Category.Update(obj);
                _unitOfWork.Save();
                TempData["notif"] = "category updated successfully.";
                return RedirectToAction("Index");
            }
            return View(); //If error occured then stay in the Create page. Dont go to Index
        }
        public IActionResult Delete(int? id)
        {
            Categ? editionObj = _unitOfWork.Category.Get(x => x.CategoryId == id);
            return View(editionObj);
        }
        [HttpPost , ActionName("Delete")]
        public IActionResult DeletePost(int? id)
        {
            Categ? obj = _unitOfWork.Category.Get(x => x.CategoryId == id);
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
                _unitOfWork.Category.Remove(obj);
                _unitOfWork.Save();
                TempData["notif"] = "category deleted successfully.";
                return RedirectToAction("Index");
            }
            return View(); //If error occured then stay in the Create page. Dont go to Index
        }
    }
}
    

