using F1_DataAccess.Repository.IRepository;
using F1_Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace F1_Garage.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ECUController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public ECUController(IUnitOfWork unitOfWork)
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
            List<ECU> objList = _unitOfWork.ECU.GetAll().ToList();
            return View(objList);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ECU obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.ECU.Add(obj);
                _unitOfWork.Save();
                TempData["Success"] = "ECU created successfully!";
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

            ECU? obj = _unitOfWork.ECU.Get(u => u.Id == id);

            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(ECU obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.ECU.Update(obj);
                _unitOfWork.Save();
                TempData["Success"] = "ECU updated successfully!";
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

            ECU? obj = _unitOfWork.ECU.Get(u => u.Id == id);

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

            ECU? obj = _unitOfWork.ECU.Get(u => u.Id == id);

            if (obj == null)
            {
                return NotFound();
            }

            _unitOfWork.ECU.Remove(obj);
            _unitOfWork.Save();
            TempData["Success"] = "ECU deleted successfully!";
            return RedirectToAction("Index");
        }
    }
}