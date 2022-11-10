using AspNetCoreProject.Data;
using AspNetCoreProject.Interfaces;
using AspNetCoreProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace AspNetCoreProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly IWebHostEnvironment _webhost;

        List<SelectListItem> _categorylist;
        private ICommentService _commentservice;
        private ICategoryService _categoryservice;
        private AnimalDBContext _context; // Depetency Injection from DB.

        private IAnimalService _animalService; // To get GetTopTwo Method
        public HomeController(AnimalDBContext context, IAnimalService animalservice, ICategoryService categoryservice, ICommentService commentservice, IWebHostEnvironment webhost)
        {
            _webhost = webhost;
            _context = context;
            _categoryservice = categoryservice;
            _animalService = animalservice; // To get GetTopTwo Method
            _categorylist = _categoryservice.GetCategories().Select(c => new SelectListItem(c.Name, c.CategoryID.ToString())).ToList();
            _commentservice = commentservice;
        }
        [HttpPost]
        public IActionResult AddPet(Animal a, IFormFile NewPicture)
        {
            if(NewPicture != null)
            {
                FileStream file = new FileStream("wwwroot/Images/" + NewPicture.FileName, FileMode.Create);
                NewPicture.CopyTo(file);
                file.Close();
                a.PictureName = NewPicture.FileName;
            }
            _animalService.AddPet(a);
            ViewBag.CategoriesName = _categorylist;
            return RedirectToAction("Admin");
        }
        public IActionResult AddPetView()
        {
            ViewBag.CategoriesName = _categorylist;
            return View();
        }
        public IActionResult Index() //Home Page
        {
            return View(_animalService.GetTopTwo()); // return only the Top Two at the home page.

        }
        public IActionResult Details(int id) //Details Page
        {
            Animal animal = _context.Animals.FirstOrDefault(animal => animal.AnimalID == id);
            ViewBag.Animal = animal;
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
        [HttpGet]
        public IActionResult Admin(int id) //Admin Page
        {
            if(id == 0)
            {
                ViewBag.Animal = _context.Animals.ToList();
                return View(_categoryservice.GetCategories());
            }
            ViewBag.ID = id;
            ViewBag.Animal = _categoryservice.GetAnimalID(id);
            return View(_categoryservice.GetCategories());
        }
        public IActionResult EditPet(int id) //Edit Page
        {
            Animal animalToShow = _context.Animals.FirstOrDefault(animal => animal.AnimalID == id);
            ViewBag.categories = _categorylist;
            ViewBag.Aniamal = animalToShow;
            return View(_categoryservice.GetSpecificPet(id));
        }
        public IActionResult EditPet1(int id ,Animal a, IFormFile newpicture) //Edit Page
        {
            if (newpicture != null)
            {
                FileStream file = new FileStream("wwwroot/Images/" + newpicture.FileName, FileMode.OpenOrCreate);
                newpicture.CopyTo(file);
                file.Close();
                a.PictureName = newpicture.FileName;
            }
            a.AnimalID = id;
            if (TryValidateModel(a))
            {
                _animalService.EditPet(a);
                return RedirectToAction("Admin");
            }
            Animal animalToShow = _context.Animals.FirstOrDefault(animal => animal.AnimalID == id);
            ViewBag.categories = _categorylist;
            ViewBag.Aniamal = animalToShow;
            return View("EditPet");
        }
        public IActionResult Delete(int id)
        {
            var petedelete = _context.Animals.SingleOrDefault(m => m.AnimalID == id);
            _context.Animals.Remove(petedelete);
            _context.SaveChanges();
            return RedirectToAction("Admin");
        }
        public IActionResult AddComment(Comment comment)
        {
            if (ModelState.IsValid)
            {
            var animal = _context.Animals.First(a => a.AnimalID == comment.AnimalID);
            animal.Comments.Add(comment);
            _context.SaveChanges();
                Animal animalToShow = _context.Animals.FirstOrDefault(animal => animal.AnimalID == comment.AnimalID);
                ViewBag.Animal = animalToShow;
                return View("Details");
            }
            else
            {
                Animal animal = _context.Animals.FirstOrDefault(animal => animal.AnimalID == comment.AnimalID);
                ViewBag.Animal = animal;
                return View("Details");
            }
        }
    }
}

        //[HttpPost]
        //public async Task<IActionResult> AddImg(IFormFile imgfile)
        //{
        //    var savingimg = Path.Combine(_webhost.WebRootPath, "Images", imgfile.FileName);
        //    string imgtxt = Path.GetExtension(imgfile.FileName);
        //    if(imgtxt == ".jpg" || imgtxt == ".png")
        //    {
        //        using(var uploadimg = new FileStream(savingimg,FileMode.Create))
        //        {
        //            await imgfile.CopyToAsync(uploadimg);
        //            ViewData["Message"] = "The Image" + imgfile.FileName + "Added!";
        //        }
        //    }
        //    else
        //    {
        //        ViewData["Message"] = "The .File is not PNG/JPG!";
        //    }
        //    return View();
        //}