using F1_DataAccess.Repository.IRepository;
using F1_Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace F1_Garage.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TyresController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public TyresController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var role = HttpContext.Session.GetString("Role");

            if (role != "Admin")
            {
                context.Result = RedirectToAction("Login", "User", new { area = "" });
            }

            base.OnActionExecuting(context);
        }

        public IActionResult Index()
        {
            List<Tyres> objList = _unitOfWork.Tyres.GetAll().ToList();
            return View(objList);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Tyres obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Tyres.Add(obj);
                _unitOfWork.Save();
                TempData["Success"] = "Tyre created successfully!";
                return RedirectToAction("Index");
            }

            return View(obj);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            Tyres? obj = _unitOfWork.Tyres.Get(u => u.Id == id);

            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Tyres obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Tyres.Update(obj);
                _unitOfWork.Save();
                TempData["Success"] = "Tyre updated successfully!";
                return RedirectToAction("Index");
            }

            return View(obj);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            Tyres? obj = _unitOfWork.Tyres.Get(u => u.Id == id);

            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            Tyres? obj = _unitOfWork.Tyres.Get(u => u.Id == id);

            if (obj == null)
            {
                return NotFound();
            }

            _unitOfWork.Tyres.Remove(obj);
            _unitOfWork.Save();
            TempData["Success"] = "Tyre deleted successfully!";
            return RedirectToAction("Index");
        }
    }
}