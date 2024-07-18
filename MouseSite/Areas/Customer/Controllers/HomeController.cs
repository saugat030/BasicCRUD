using Microsoft.AspNetCore.Mvc;
using Mouse.DataAccess.Repository;
using Mouse.Models;
using System.Diagnostics;

namespace MouseSite.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public HomeController(ILogger<HomeController> logger ,IUnitOfWork unitOfWork )
        {
            _unitOfWork = unitOfWork;   
            _logger = logger;
        }

        public IActionResult Index()
        {
            IEnumerable<Product> products = _unitOfWork.Product.GetAll(includeProperties:"Category");
            return View(products);
        }
        public IActionResult Details(int prdid)
        {
            Product product = _unitOfWork.Product.Get(u=> u.Id == prdid , includeProperties:"Category"); //yo prdid ra uta details view ko id same hunu parxa.
            return View(product);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
