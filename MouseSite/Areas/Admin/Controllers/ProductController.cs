//Some comments are not aligned properly due to this file being edited multiple times. Aba afai check han paxi revision handa.

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Mouse.DataAccess.Data;
using Mouse.DataAccess.Repository;
using Mouse.Models;
using Mouse.Models.ProductViewModel;

namespace MouseSite.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {   private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment;//This lets us access the wwwroot folder. Yo build in feature ho asp.net ko so services ma register garnu pardaina sidai DI hanna milxa.
        public ProductController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
        {

            _unitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnvironment;   
        }
        public IActionResult Index()
        {
            List<Product> categObj = _unitOfWork.Product.GetAll().ToList();
            
            return View(categObj);
        }
        public IActionResult Upsert(int? id) //Update+Insert //Create ra edit ma main diff vabya chai create ke model ni naya obj lagxa kei populate va vako
            //Edit le chai model ko already exixting object lagxa @model ma jasko chai id match hunxa Get garda.
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
            if(id == null || id==0){
                return View(productVM);  //ViewBag.CategList = CategList; //We can use this to easily access the CategList but this is not the standard method to bind a model to a view
                                         //Since the view is already binded with the Product model , we cant send extra stuff so lets make a class to put them there.
            }
            else
            {
                //update;
                productVM.Product = _unitOfWork.Product.Get(u=> u.Id==id); //euta matrai id return chiay so use get() not getall()
                return View(productVM);
            }
           
        }
        [HttpPost]
        public IActionResult Upsert(ProductVM obj , IFormFile? file) //to recieve the file.
        {
            if (ModelState.IsValid) //Ya model state ko kei kura wrong vayo, It goes back to the view. Tara view ma pheri pharkida PostMethod ma we havent passed anything
            {

                //in line 48. productVM pass gareko xaina so @model ma chai ProductVm bind vako xa ani pass chai gareko xaina. So basically badhi validate hanyo.
                string wwwRootPath = _webHostEnvironment.WebRootPath;
                if(file!=null)
                {
                    string filename = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName); //randok name for file.
                    string productPath = Path.Combine(wwwRootPath, @"images\product");

                    using (var fileStream = new FileStream(Path.Combine(productPath, filename), FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }
                    obj.Product.ImageUrl = @"image\product\" + filename;
                }
                _unitOfWork.Product.Add(obj.Product); 
                _unitOfWork.Save();
               TempData["notif"] = "category created successfully.";
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
    

