using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreProject.Models
{
    public class Animal
    {
        [Key]
        public int AnimalID { get; set; }

        [Required(ErrorMessage = "Please enter a name.")]
        public string Name { get; set; }
        [Required]
        [Range(0, 150)]
        public int Age { get; set; }

        [Required]
        public string PictureName { get; set; }
        [Required]
        [DataType(DataType.MultilineText)]
        [StringLength(400)]
        public string Description { get; set; }

        public int CategoryID { get; set; }
        public virtual Category Category { get; set;}

        public enum CategoryName
        {
            Mammls,
            Rodent,
            Fish,
            Reptils
        } // Here for testing.

        public virtual ICollection<Comment> Comments { get; set; }

    }
}
