using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Mouse.DataAccess.Data;
using Mouse.DataAccess.Repository;
using Mouse.Models;
using Mouse.Models.ProductViewModel;

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
            ProductVM productVM = new ProductVM()
            {
                CategoryList = CategList,   
                Product = new Product()
            };
            //ViewBag.CategList = CategList; //We can use this to easily access the CategList but this is not the standard method to bind a model to a view
            return View(productVM); //Since the view is already binded with the Product model , we cant send extra stuff so lets make a class to put them there.
        }
        [HttpPost]
        public IActionResult Create(ProductVM obj)
        {
            if (ModelState.IsValid) //Ya model state ko kei kura wrong vayo, It goes back to the view. Tara view ma pheri pharkida PostMethod ma we havent passed anything
            {                       //in line 48. productVM pass gareko xaina so @model ma chai ProductVm bind vako xa ani pass chai gareko xaina. So basically badhi validate hanyo.
                _unitOfWork.Product.Add(obj.Product); 
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
    

