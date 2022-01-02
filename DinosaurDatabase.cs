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

        public void ViewDinosInThePark()
        {
            // NEED TO FIX SORTING BY NAME OR ENCLOSURE NUMBER
            // AND DISPLAY ERROR IF NO DINOS IN THE PARK

            // var howToView = PromptForString("Would you like to view the dinosaurs by (N)AME or (E)NCLOSURE NUMBER? ").ToUpper();
            // Dinosaur viewByName = dinosaurs.FirstOrDefault(dinosaur => dinosaur.Name == howToView);
            // else if (howToView == "N")
            if (Dinosaurs.Count == 0)
            {
                DinosaurDatabase.NoDinosInTheParkMessage();
            }
            else
            {
                foreach (var viewDino in Dinosaurs)
                {
                    // POSSIBLE LINQ FOR SEARCHING BY NAME (currently does not work):
                    // var viewByName = dinosaurs.OrderBy(dinosaur => dinosaur.Name);
                    viewDino.DisplayDinosaurs();
                }
            }

            // }
            // else if (howToView == "E")
            // {
            //     foreach (var viewDino in dinosaurs)
            //     {
            //         viewDino.DisplayDinosaurs();
            //     }
            // }
        }
        public static void NoDinosInTheParkMessage()
        {
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("There are no dinos in the park, just dino eggs. Check back again once they've hatched 🐣 ");
        }

    }

}
