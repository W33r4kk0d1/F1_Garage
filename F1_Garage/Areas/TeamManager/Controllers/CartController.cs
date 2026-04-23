using F1_Garage.Data;
using F1_Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace F1_Garage.Areas.TeamManager.Controllers
{
    [Area("TeamManager")]
    public class CartController : Controller
    {
        private readonly ApplicationDbContext _db;

        public CartController(ApplicationDbContext db)
        {
            _db = db;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var role = HttpContext.Session.GetString("Role");

            if (role != "TeamManager")
            {
                context.Result = RedirectToAction("Login", "User", new { area = "" });
            }

            base.OnActionExecuting(context);
        }

        public IActionResult Index()
        {
            int? userId = HttpContext.Session.GetInt32("UserId");

            if (userId == null)
            {
                return RedirectToAction("Login", "User", new { area = "" });
            }

            List<CartItem> cartItems = _db.CartItems
                .Where(c => c.UserId == userId)
                .ToList();

            return View(cartItems);
        }

        public IActionResult AddTyre(int id)
        {
            int? userId = HttpContext.Session.GetInt32("UserId");

            if (userId == null)
            {
                return RedirectToAction("Login", "User", new { area = "" });
            }

            Tyres? tyre = _db.Tyres.Find(id);

            if (tyre == null)
            {
                return NotFound();
            }

            CartItem item = new CartItem
            {
                UserId = userId.Value,
                ItemId = tyre.Id,
                ItemName = tyre.Name,
                ItemType = "Tyre",
                Quantity = 1
            };

            _db.CartItems.Add(item);
            _db.SaveChanges();

            TempData["Success"] = "Tyre added to cart successfully!";
            return RedirectToAction("Index", "Tyres", new { area = "TeamManager" });
        }

        public IActionResult AddECU(int id)
        {
            int? userId = HttpContext.Session.GetInt32("UserId");

            if (userId == null)
            {
                return RedirectToAction("Login", "User", new { area = "" });
            }

            ECU? ecu = _db.ECUs.Find(id);

            if (ecu == null)
            {
                return NotFound();
            }

            CartItem item = new CartItem
            {
                UserId = userId.Value,
                ItemId = ecu.Id,
                ItemName = ecu.Name,
                ItemType = "ECU",
                Quantity = 1
            };

            _db.CartItems.Add(item);
            _db.SaveChanges();

            TempData["Success"] = "ECU added to cart successfully!";
            return RedirectToAction("Index", "ECU", new { area = "TeamManager" });
        }

        public IActionResult Remove(int id)
        {
            CartItem? item = _db.CartItems.Find(id);

            if (item == null)
            {
                return NotFound();
            }

            _db.CartItems.Remove(item);
            _db.SaveChanges();

            TempData["Success"] = "Item removed from cart successfully!";
            return RedirectToAction("Index");
        }
    }
}