using F1_DataAccess.Repository.IRepository;
using F1_Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace F1_Garage.Areas.TeamManager.Controllers
{
    [Area("TeamManager")]
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

            if (role != "TeamManager")
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
    }
}