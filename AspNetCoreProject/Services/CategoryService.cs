using AspNetCoreProject.Data;
using AspNetCoreProject.Interfaces;
using AspNetCoreProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreProject.Services
{
    public class CategoryService : ICategoryService
    {
        public AnimalDBContext _context;
        public CategoryService(AnimalDBContext context)
        {
            _context = context;
        }
        public IEnumerable<Animal> GetAnimalID(int id)
        {
            return (_context.Animals.Where(a => a.CategoryID == id));
        }
        public Animal GetSpecificPet(int id)
        {
            return (_context.Animals.FirstOrDefault(a => a.AnimalID == id));
        }
        public IEnumerable<Category> GetCategories()
        {
            return _context.Categories.ToList();
        }
    }
}
