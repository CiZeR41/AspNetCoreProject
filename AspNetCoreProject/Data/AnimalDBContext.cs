using AspNetCoreProject.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreProject.Data
{
    public class AnimalDBContext : DbContext
    {
        public AnimalDBContext(DbContextOptions<AnimalDBContext> options) : base(options)
        {
        }

        public virtual DbSet<Animal> Animals { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Animal>().HasData(
                                                        // CSS The size of the image !!
                new Animal { AnimalID = 1, PictureName = "African helmet turtle.jpg", Name = "Helmet Turtle", Age = 31, CategoryID = 4, Description = "The African Helmet Turtle is the only species in the genus Turtle family. This turtle lives in ponds and swamps in sub-Saharan Africa and may even be inhabited in Madagascar and Yemen and is characterized by its long neck and nose inclined upwards." },
                new Animal { AnimalID = 2, PictureName = "Chinchilla.jpg", Name = "Chinchilla", Age = 2, CategoryID = 2, Description = "A chinchilla or chinchilla is a small rodent found in the Andes of South America. The genus Chinchilla has two species: long-tailed chinchilla or common chinchilla, and short-tailed chinchilla. The chinchilla is a social animal that lives in larger pairs or family groups. Their natural habitat is rocky places" },
                new Animal { AnimalID = 3, PictureName = "Donkey.jpg", Name = "Donkey", Age = 3, CategoryID = 1, Description = "The donkey is a type of porcupine from the reindeer family and subfamily Old World reindeer, living in the forests of Eurasia. The donkeys are moose with fur in the color of hamra dotted with white, hence the popular name will donkey." },
                new Animal { AnimalID = 4, PictureName = "Pufferfish.jpg", Name = "Pufferfish", Age = 2, CategoryID = 3, Description = "Puffin is a family of fin-radiated fish that belong to the puffed series. These fish are mainly common in the tropics, and in Israel mainly in the Gulf of Eilat." },
                new Animal { AnimalID = 5, PictureName = "Dolphin.jpg", Name = "Dolphin", Age = 5, CategoryID = 3, Description = "Dolphins are a prophylactic group of marine mammals belonging to the whale series, and a subset of toothed whales." },
                new Animal { AnimalID = 6, PictureName = "The Crocodile of Light.jpg", Name = "Light Crocodile", Age = 8, CategoryID = 4, Description = "The light crocodile is a species of crocodile in the series of crocodiles, which lives in Africa. It is the second largest species of crocodile; Only the sea crocodile is bigger than him. The average length of an adult male ranges from 4.1 to 5 meters and his average weight is about 450 kilograms." },
                new Animal { AnimalID = 7, PictureName = "Armadillo.jpg", Name = "Armadillo", Age = 2, CategoryID = 1, Description = "Armadillas are a series of mammals best known for their body armor. Some of the species in the series have reached an impressive size and are considered to be part of the mega-fauna in their habitat, such as the glyptidones and pampered. But all have long since become extinct, except for the giant armadillo that lives on to this day." },
                new Animal { AnimalID = 8, PictureName = "Vole.jpg", Name = "Vole", Age = 5, CategoryID = 2, Description = "Navarns is a collective name for several types of the subarachnoid subfamily of the Ugaritic family. The barnacles are small rodents that resemble a mouse, but have a more plump body, a shorter, hairy tail, a rounder head, smaller ears and eyes, and a different shape of their molars." },
                new Animal { AnimalID = 9, PictureName = "Spur.jpg", Name = "Spur", Age = 4, CategoryID = 2, Description = "The spur is a type of rodent in the spur family and the largest type in the family. Their distribution is in warm regions throughout Africa and South Asia. In the genus Eight species which are the largest in their family and also the largest in the rodents of the Old World. The largest of these is the spoon spur, which reaches a maximum length of 80 cm and a weight of 24 kg." },
                new Animal { AnimalID = 10, PictureName = "Giant Panda.jpg", Name = "Giant Panda", Age = 4, CategoryID = 1, Description = "The giant panda is a species of mammal and the only surviving species in the genus Panda, which is classified in the bear family and resides in central China. The panda lives in mountainous areas, such as Sichuan and Tibet." }
             );
            modelBuilder.Entity<Category>().HasData(
            new Category { CategoryID = 1, Name = "Mammals" }, // יונק
            new Category { CategoryID = 2, Name = "Rodent" }, // מכרסם
            new Category { CategoryID = 3, Name = "Fish" }, // דגים
            new Category { CategoryID = 4, Name = "Reptiles" } // זוחל
            );
            
            modelBuilder.Entity<Comment>().HasData(
            new Comment { CommentID = 1 , AnimalID = 1 , Content = "I love the look of the Helmet Turtle, great animal." },
            new Comment { CommentID = 2, AnimalID = 1, Content = "I love the look of the Helmet Turtle, great animal." },
            new Comment { CommentID = 3, AnimalID = 2, Content = "I love the look of the Helmet Turtle, great animal." },
            new Comment { CommentID = 4, AnimalID = 1, Content = "I love the look of the Helmet Turtle, great animal." },
            new Comment { CommentID = 5, AnimalID = 2, Content = "I love the look of the Helmet Turtle, great animal." },
            new Comment { CommentID = 6, AnimalID = 1, Content = "I love the look of the Helmet Turtle, great animal." },
            new Comment { CommentID = 7, AnimalID = 2, Content = "I love the look of the Helmet Turtle, great animal." },

            new Comment { CommentID = 8, AnimalID = 9, Content = "I love the look of the Helmet Turtle, great animal." },
            new Comment { CommentID = 9, AnimalID = 9, Content = "I love the look of the Helmet Turtle, great animal." },
            new Comment { CommentID = 10, AnimalID = 9, Content = "I love the look of the Helmet Turtle, great animal." },
            new Comment { CommentID = 11, AnimalID = 9, Content = "I love the look of the Helmet Turtle, great animal." },
            new Comment { CommentID = 12, AnimalID = 5, Content = "I love the look of the Helmet Turtle, great animal." },
            new Comment { CommentID = 13, AnimalID = 5, Content = "I love the look of the Helmet Turtle, great animal." },
            new Comment { CommentID = 14, AnimalID = 5, Content = "I love the look of the Helmet Turtle, great animal." },
            new Comment { CommentID = 15, AnimalID = 5, Content = "I love the look of the Helmet Turtle, great animal." },
            new Comment { CommentID = 16, AnimalID = 9, Content = "I love the look of the Helmet Turtle, great animal." },
            new Comment { CommentID = 17, AnimalID = 9, Content = "I love the look of the Helmet Turtle, great animal." },
            new Comment { CommentID = 18, AnimalID = 9, Content = "I love the look of the Helmet Turtle, great animal." },
            new Comment { CommentID = 19, AnimalID = 10, Content = "I love the look of the Helmet Turtle, great animal." },
            new Comment { CommentID = 20, AnimalID = 10, Content = "I love the look of the Helmet Turtle, great animal." }
            );
        }

    }
}
