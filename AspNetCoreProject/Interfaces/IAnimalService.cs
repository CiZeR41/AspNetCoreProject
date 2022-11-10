using AspNetCoreProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreProject.Interfaces
{
    public interface IAnimalService
    {
        IEnumerable<Animal> GetTopTwo();
        void AddPet(Animal a);
        void EditPet(Animal a);
    }

}
