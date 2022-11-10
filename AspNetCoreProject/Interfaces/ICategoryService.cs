using AspNetCoreProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreProject.Interfaces
{
    public interface ICategoryService
    {
        IEnumerable<Animal> GetAnimalID(int id);
        Animal GetSpecificPet(int id);
        IEnumerable<Category> GetCategories();
    }
}
