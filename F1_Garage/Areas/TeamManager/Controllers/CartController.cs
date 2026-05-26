using F1_DataAccess.Repository.IRepository;
using F1_Models;
using Microsoft.AspNetCore.Mvc;

namespace F1_Garage.Areas.TeamManager.Controllers
{
    [Area("TeamManager")]
    public class CartController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public CartController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            var userId = HttpContext.Session.GetInt32("UserId");

            if (userId == null)
                return RedirectToAction("Login", "User");

            CartVM cartVM = new CartVM
            {
                CartItems = _unitOfWork.CartItem.GetAll(
                    u => u.UserId == userId.Value,
                    includeProperties: "Product"
                ),
                OrderHeader = new OrderHeader()
            };

            return View(cartVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddToCart(CartItem obj)
        {
            var userId = HttpContext.Session.GetInt32("UserId");

            if (userId == null)
                return RedirectToAction("Login", "User");

            obj.UserId = userId.Value;

            if (obj.ProductId == 0)
                return RedirectToAction("Index", "Product");

            if (obj.Count <= 0)
                obj.Count = 1;

            _unitOfWork.CartItem.Add(obj);
            _unitOfWork.Save();

            return RedirectToAction("Index");
        }

        public IActionResult Remove(int id)
        {
            var item = _unitOfWork.CartItem.Get(u => u.Id == id);

            if (item == null)
                return NotFound();

            _unitOfWork.CartItem.Remove(item);
            _unitOfWork.Save();

            return RedirectToAction("Index");
        }
    }
}