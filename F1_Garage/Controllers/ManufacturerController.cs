using F1_Garage.Data;
using F1_Garage.Models;
using Microsoft.AspNetCore.Mvc;
using F1_DataAccess.Repository.IRepository;
using System.Reflection.Metadata.Ecma335;

namespace F1_Garage.Controllers
{
    public class ManufacturerController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public ManufacturerController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            List<Manufacturer> objManufacturerList = _unitOfWork.Manufacturer.GetAll().ToList();
            return View(objManufacturerList);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Models.Manufacturer obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("Name", "The Display cannot be the same as the Name!");
            }

            if (ModelState.IsValid)
            {
                _unitOfWork.Manufacturer.Add(obj);
                _unitOfWork.Save();
                TempData["Success"] = "New Manufacturer added successfully.";
                return RedirectToAction("Index");
            }
            return View();
        }

        // EDIT BUTTON
        public IActionResult Edit(int? id)
        {
            if(id==null || id==0)
            {
                return NotFound();
            }
            Manufacturer? manufacturerFromDb = _unitOfWork.Manufacturer.Get(u=>u.Id == id);

            if(manufacturerFromDb == null)
            {
                return NotFound();
            }
            return View(manufacturerFromDb);
        }

        [HttpPost]
        public IActionResult Edit(Manufacturer obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Manufacturer.Update(obj);
                _unitOfWork.Save();
                TempData["Success"] = "Manufacturer details have been updated successfully!";
                return RedirectToAction("Index");
            }
            return View();
        }

        // Delete Button
        public IActionResult Delete(int? id)
        {
            Manufacturer? obj = _unitOfWork.Manufacturer.Get(u => u.Id == id);

            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            Manufacturer? obj = _unitOfWork.Manufacturer.Get(u => u.Id == id);

            if (obj == null)
            {
                return NotFound();
            }

            _unitOfWork.Manufacturer.Remove(obj);
            _unitOfWork.Save();
            TempData["Success"] = "Manufacturer details have been deleted successfully!";
            return RedirectToAction("Index");
        }
    }
}


