using AspNetCoreProject.Data;
using AspNetCoreProject.Interfaces;
using AspNetCoreProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreProject.Services
{
    public class AnimalService : IAnimalService
    {
        public AnimalDBContext _context;

        public AnimalService(AnimalDBContext context)
        {
            _context = context;
        }
        public IEnumerable<Animal> GetTopTwo()
        {
            IEnumerable<Animal> toptwo;
            toptwo = _context.Animals.OrderByDescending(a => a.Comments.Count).Take(2).ToList();
            return toptwo;
        }
        public void EditPet(Animal a)
        {
            _context.Animals.Update(a);
            _context.SaveChanges();
        }
        public void AddPet(Animal a)
        {
            _context.Animals.Add(a);
            _context.SaveChanges();
        }
        
    }
}
