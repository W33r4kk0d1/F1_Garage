using F1_Garage.Data;
using F1_Garage.Models;
using Microsoft.AspNetCore.Mvc;
using F1_DataAccess.Repository.IRepository;
using System.Reflection.Metadata.Ecma335;

namespace F1_Garage.Controllers
{
    public class ManufacturerController : Controller
    {
        private readonly IManufacturerRepository _manufacturerRepo;
        public ManufacturerController(IManufacturerRepository db)
        {
            _manufacturerRepo = db;
        }
        public IActionResult Index()
        {
            List<Manufacturer> objManufacturerList = _manufacturerRepo.GetAll().ToList();
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
                _manufacturerRepo.Add(obj);
                _manufacturerRepo.Save();
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
            Manufacturer? manufacturerFromDb = _manufacturerRepo.Get(u=>u.Id == id);

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
                _manufacturerRepo.Update(obj);
                _manufacturerRepo.Save();
                TempData["Success"] = "Manufacturer details have been updated successfully!";
                return RedirectToAction("Index");
            }
            return View();
        }

        // Delete Button
        public IActionResult Delete(int? id)
        {
            Manufacturer? obj = _manufacturerRepo.Get(u => u.Id == id);

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

            Manufacturer? obj = _manufacturerRepo.Get(u => u.Id == id);

            if (obj == null)
            {
                return NotFound();
            }

            _manufacturerRepo.Remove(obj);
            _manufacturerRepo.Save();
            TempData["Success"] = "Manufacturer details have been deleted successfully!";
            return RedirectToAction("Index");
        }
    }
}


