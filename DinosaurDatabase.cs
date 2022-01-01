using System;
using System.Collections.Generic;

namespace JurassicPark
{
    class DinosaurDatabase
    {
        // QUESTION ABOUT THIS...
        private List<Dinosaur> Dinosaurs { get; set; } = new List<Dinosaur>();

        // METHOD for adding a dino
        public void AddDinosaur(Dinosaur newDinosaur)
        {
            Dinosaurs.Add(newDinosaur);
        }

        // // METHOD for viewing all dinos
        // public void ViewDinosaurs(List<Dinosaur> dinosaurs)
        // {
        //     foreach (var dino in dinosaurs)
        //     {
        //         DisplayDinosaurs();
        //     }
        // }

        // METHOD for deleting a dino
        public void RemoveDinosaur(Dinosaur removeDinosaur)
        {
            Dinosaurs.Remove(removeDinosaur);
        }
        public void NoDinosInTheParkMessage()
        {
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("There are no dinos in the park, just dino eggs. Check back again once they've hatched 🐣 ");
        }
    }

}

// ALGORITHM


// - if (S)UMMARY is selected:
//   - will display the number of carnivores and herbivores in the park list. 
