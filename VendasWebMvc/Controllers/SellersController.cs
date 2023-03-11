
using Microsoft.AspNetCore.Mvc;
using VendasWebMvc.Services;

namespace VendasWebMvc.Controllers
{
    public class SellersController : Controller
    {
        private readonly SellerService _sellerSevice;

        public SellersController(SellerService sellerService)
        {
            _sellerSevice = sellerService;
        }

        public IActionResult Index()
        {
            var list = _sellerSevice.FindAll();

            return View(list);
        }
    }
}
