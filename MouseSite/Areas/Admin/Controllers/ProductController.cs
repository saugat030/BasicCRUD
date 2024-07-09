using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Mouse.DataAccess.Data;
using Mouse.DataAccess.Repository;
using Mouse.Models;

namespace MouseSite.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {   private readonly IUnitOfWork _unitOfWork;
        public ProductController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            List<Product> categObj = _unitOfWork.Product.GetAll().ToList();
            
            return View(categObj);
        }
        public IActionResult Create()
        {
            IEnumerable<SelectListItem> CategList = _unitOfWork.Category.GetAll().Select(u => new SelectListItem
            {
                Text = u.Name,
                Value = u.CategoryId.ToString()
            });
            ViewBag.CategList = CategList;
            return View();
        }
        [HttpPost]
        public IActionResult Create(Product obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Product.Add(obj);
                _unitOfWork.Save();
               TempData["notif"] = "category created successfully.";
                return RedirectToAction("Index");
            }
            return View(); //If error occured then stay in the Create page. Dont go to Index
        }
        public IActionResult Edit(int? id) //m ra tyoDherai Important kura : yo ko naa "asp-route-..." ma pass gareko name same hunu parxa
        {
            Product? editionObj = _unitOfWork.Product.Get(x=>x.Id==id); // can use any moethod to retrieve data just that FirstOrDefault is prefered.
           // Product? editionObj = _db.Products.Where(x => x.ProductId == idd).FirstOrDefault();//This is LINQ method obviously. That idd gets passed from the view of Index page of ProductController. Refer to that.
            if (editionObj == null){ 
                return NotFound(editionObj);  
            }
                return View(editionObj);
        }
        [HttpPost]
        public IActionResult Edit(Product obj)
        {
            
            if (ModelState.IsValid)
            {
                _unitOfWork.Product.Update(obj);
                _unitOfWork.Save();
                TempData["notif"] = "category updated successfully.";
                return RedirectToAction("Index");
            }
            return View(); //If error occured then stay in the Create page. Dont go to Index
        }
        public IActionResult Delete(int? id)
        {
            Product? editionObj = _unitOfWork.Product.Get(x => x.Id == id);
            return View(editionObj);
        }
        [HttpPost , ActionName("Delete")]
        public IActionResult DeletePost(int? id)
        {
            Product? obj = _unitOfWork.Product.Get(x => x.Id == id);
            if (obj == null)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                _unitOfWork.Product.Remove(obj);
                _unitOfWork.Save();
                TempData["notif"] = "category deleted successfully.";
                return RedirectToAction("Index");
            }
            return View(); //If error occured then stay in the Create page. Dont go to Index
        }
    }
}
    

