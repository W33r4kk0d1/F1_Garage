using F1_Garage.Data;
using Microsoft.AspNetCore.Mvc;

namespace F1_Garage.Controllers
{
    public class ManufacturerController : Controller
    {
        private readonly ApplicationDbContext _db;
        public ManufacturerController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            var objManufacturerList= _db.Manufacturers.ToList();
            return View(objManufacturerList);
        }

        [HttpPost]
        public IActionResult Create(Models.Manufacturer obj)
        {
            _db.Manufacturers.Add(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Create()
        {
            return View();
        }
    }
}
