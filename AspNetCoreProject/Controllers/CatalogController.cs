using AspNetCoreProject.Data;
using AspNetCoreProject.Interfaces;
using AspNetCoreProject.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreProject.Controllers
{
    public class CatalogController : Controller
    {
        private AnimalDBContext _context; // Depetency Injection from DB.
        private ICategoryService _categoryservice;
        public CatalogController(AnimalDBContext context, ICategoryService categoryservice)
        {
            _context = context;
            _categoryservice = categoryservice;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Details(int id) //Details Page
        {
            ViewBag.SAnimal = _categoryservice.GetSpecificPet(id);
            ViewBag.Animal = _context.Animals.First(a => a.AnimalID == id);
            return View("Details");
        }
        [HttpGet]
        public IActionResult Catalog(int id) //Catalog Page
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
        public IActionResult AddComment(Comment comment)
        {
            var animal = _context.Animals.First(a => a.AnimalID == comment.AnimalID);
            animal.Comments.Add(comment);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
