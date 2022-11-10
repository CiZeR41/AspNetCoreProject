using AspNetCoreProject.Data;
using AspNetCoreProject.Interfaces;
using AspNetCoreProject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreProject.Controllers
{
    public class AdminController : Controller
    {
        private AnimalDBContext _context; // Depetency Injection from DB.
        private ICategoryService _categoryservice;
        private IAnimalService _animalService;
        List<SelectListItem> _categorylist;


        public AdminController(AnimalDBContext context, ICategoryService categoryservice, IAnimalService animalService)
        {
            _context = context;
            _categoryservice = categoryservice;
            _animalService = animalService;
            _categorylist = _categoryservice.GetCategories().Select(c => new SelectListItem(c.Name, c.CategoryID.ToString())).ToList();
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Delete(int id)
        {
            var petedelete = _context.Animals.SingleOrDefault(m => m.AnimalID == id);
            _context.Animals.Remove(petedelete);
            _context.SaveChanges();
            return RedirectToAction("Admin");
        }
        [HttpGet]
        public IActionResult Admin(int id) //Admin Page
        {
            if (id == 0)
            {
                ViewBag.Animal = _context.Animals.ToList();
                return View(_categoryservice.GetCategories());
            }
            ViewBag.ID = id;
            ViewBag.Animal = _categoryservice.GetAnimalID(id);
            return View(_categoryservice.GetCategories());
        }
        public IActionResult EditPet(int id) //Edit Page
        { //S = Specific

            ViewBag.SAnimal = _categoryservice.GetSpecificPet(id);
            ViewBag.SCategory = _categorylist;
            return View();
        }
        public IActionResult EditPet1(Animal a) //Edit Page
        {
            if (ModelState.IsValid)
            {
                _animalService.EditPet(a);
                return RedirectToAction("Admin");
            }
            return View("EditPet");
        }
        public IActionResult AddPetView()
        {
            ViewBag.CategoriesName = _categorylist;
            return View();
        }
        [HttpPost]
        public IActionResult AddPet(Animal a, IFormFile NewPicture)
        {
            if (NewPicture != null)
            {
                FileStream file = new FileStream("wwwroot/Images/" + NewPicture.FileName, FileMode.Create);
                NewPicture.CopyTo(file);
                file.Close();
                a.PictureName = NewPicture.FileName;
            }
            ViewBag.CategoriesName = _categorylist;
            if (ModelState.IsValid)
            {
                _animalService.AddPet(a);
                return RedirectToAction("Admin");
            }
            return View("AddPetView");
        }
    }
}
