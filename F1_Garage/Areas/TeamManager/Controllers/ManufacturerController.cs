using F1_DataAccess.Repository.IRepository;
using F1_Garage.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace F1_Garage.Areas.TeamManager.Controllers
{
    [Area("TeamManager")]
    public class ManufacturerController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public ManufacturerController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
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
            List<Manufacturer> objManufacturerList = _unitOfWork.Manufacturer.GetAll().ToList();
            return View(objManufacturerList);
        }
    }
}