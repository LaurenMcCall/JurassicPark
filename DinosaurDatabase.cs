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
    }
}

// ALGORITHM


// - if (S)UMMARY is selected:
//   - will display the number of carnivores and herbivores in the park list. 
