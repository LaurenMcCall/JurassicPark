using System;
using System.Collections.Generic;

namespace JurassicPark
{
    class DinosaurDatabase
    {
        // QUESTION ABOUT THIS...
        private List<Dinosaur> Dinosaurs { get; set; } = new List<Dinosaur>();

        // // METHOD for adding a dino
        // public void AddDinosaur(Dinosaur newDinosaur)
        // {
        //     Dinosaurs.Add(newDinosaur);
        // }

        // METHOD for deleting a dino
        public void RemoveDinosaur(Dinosaur removeDinosaur)
        {
            Dinosaurs.Remove(removeDinosaur);
        }

        // public void ViewDinosInThePark()
        // {

        // }
        public static void NoDinosInTheParkMessage()
        {
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("There are no dinos in the park, just dino eggs. Check back again once they've hatched 🐣 ");
        }

    }

}
