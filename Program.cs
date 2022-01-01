using System;
using System.Collections.Generic;
using System.Linq;

namespace JurassicPark
{
    class Program
    {
        // - display welcome greeting
        static void DisplayGreeting()

        {
            Console.WriteLine();
            Console.WriteLine("🦴🦴🦴🦴🦴🦴🦴🦴🦴🦴🦴🦴🦴🦴🦴🦴🦴🦴🦴🦴🦴🦴🦴🦴🦴🦴🦴🦴🦴🦴🦴");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("  🦕🦖🦕🦖🦕🦖🦕🦖 WELCOME TO JURASSIC PARK 🦕🦖🦕🦖🦕🦖🦕🦖  ");
            Console.WriteLine("🦴🦴🦴🦴🦴🦴🦴🦴🦴🦴🦴🦴🦴🦴🦴🦴🦴🦴🦴🦴🦴🦴🦴🦴🦴🦴🦴🦴🦴🦴🦴");
            Console.WriteLine();
        }

        static void DisplayMenu()
        {
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("PLEASE MAKE A SELECTION: ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("-----------------------------------------------");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("(V)IEW dinosaurs in the park ");
            Console.WriteLine("(A)DD a dinosaur to the park ");
            Console.WriteLine("(R)EMOVE a dinosaur from the park ");
            Console.WriteLine("(T)RANSFER a dinosaur to a different enclosure ");
            Console.WriteLine("(S)UMMARIZE dinosaur diet types ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("(Q)UIT ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("-----------------------------------------------");
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.White;
        }

        // prompt for string method
        static string PromptForString(string prompt)
        {
            Console.Write(prompt);
            var userInput = Console.ReadLine();

            return userInput;
        }

        // prompt for integer
        static int PromptForInteger(string prompt)
        {
            Console.Write(prompt);
            int userInput;
            var isThisGoodInput = Int32.TryParse(Console.ReadLine(), out userInput);

            if (isThisGoodInput)
            {
                return userInput;
            }
            else
            {
                Console.WriteLine("Sorry, that isn't a valid input, I'm using 0 as your answer. ");
                return 0;
            }
        }

        static void Main(string[] args)
        {
            //   - List<Dinosaurs>
            //     - keeps track of my Dinosaurs
            var dinosaurs = new List<Dinosaur>();

            var database = new DinosaurDatabase();

            DisplayGreeting();

            var keepGoing = true;

            while (keepGoing)
            {
                // - display menu  
                DisplayMenu();

                var choice = Console.ReadLine().ToUpper();

                switch (choice)
                {
                    case "V":
                        // NEED TO FIX SORTING BY NAME OR ENCLOSURE NUMBER
                        // AND DISPLAY ERROR IF NO DINOS IN THE PARK
                        // Console.WriteLine("");
                        // var howToView = PromptForString("Would you like to view the dinosaurs by (N)AME or (E)NCLOSURE NUMBER? ").ToUpper();

                        // // Dinosaur viewByName = dinosaurs.FirstOrDefault(dinosaur => dinosaur.Name == howToView);

                        // else if (howToView == "N")
                        // {
                        // if (!dinosaurs.Any())
                        if (dinosaurs.Count == 0)
                        {
                            database.NoDinosInTheParkMessage();
                        }
                        else
                        {
                            foreach (var viewDino in dinosaurs)
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
                        break;

                    case "A":
                        var dino = new Dinosaur();

                        Console.WriteLine("");
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        dino.Name = PromptForString("What is your dino's name? ").ToUpper();
                        dino.DietType = PromptForString("Is your dino an (H)erbivore or a (C)arnivore? ").ToUpper();
                        if (dino.DietType == "H")
                        {
                            dino.DietType = "Herbivore";
                        }
                        else if (dino.DietType == "C")
                        {
                            dino.DietType = "Carnivore";
                        }
                        dino.WhenAcquired = DateTime.Now;
                        dino.Weight = PromptForInteger("How much does your dino weigh in pounds? ");
                        dino.EnclosureNumber = PromptForInteger("Please assign an enclosure number to your dino: ");

                        // WANT TO PROMPT USER TO INPUT NEW NUMBER IF ENCLOSURE IS ALREADY TAKEN

                        // bool enclosureNumberAlreadyAssigned = dinosaurs.Any(cageNumber => cageNumber.EnclosureNumber == dino.EnclosureNumber);
                        // if (enclosureNumberAlreadyAssigned == true)
                        // {
                        //     Console.WriteLine("That enclosure number has already been assigned. Please input another one. ");
                        // }
                        Console.WriteLine("");

                        dinosaurs.Add(dino);
                        break;

                    case "R":
                        Console.WriteLine("");
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        var nameToSearch = PromptForString("What is the name of the dinosaur you'd like to remove? ").ToUpper();

                        Dinosaur foundDino = dinosaurs.FirstOrDefault(dinosaur => dinosaur.Name == nameToSearch);
                        if (dinosaurs.Count < 1)
                        {
                            database.NoDinosInTheParkMessage();
                        }

                        // WHY ISN'T THIS SHOWING UP WHEN THERE ARE NO DINOs IN THE LIST?
                        else if (foundDino == null)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("");
                            Console.WriteLine("❗No match found❗");
                        }
                        else
                        {
                            Console.WriteLine("");
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            var confirmRemoval = PromptForString($"Are you sure you want to remove {foundDino.Name} from the park? (Y)ES or (N)O ").ToUpper();
                            if (confirmRemoval == "Y")
                            {
                                dinosaurs.Remove(foundDino);
                                Console.WriteLine("");
                                Console.ForegroundColor = ConsoleColor.Cyan;
                                Console.WriteLine($"{foundDino.Name} has been removed from the park. Bye, {foundDino.Name}! We'll miss you 💙 ");
                                Console.WriteLine("");
                            }
                        }
                        break;

                    case "T":
                        Console.WriteLine("");
                        var nameToMove = PromptForString("What is the name of the dinosaur you'd like to transfer? ").ToUpper();

                        Dinosaur moveDino = dinosaurs.FirstOrDefault(dinosaur => dinosaur.Name == nameToMove);

                        if (moveDino == null)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("");
                            Console.WriteLine("❗No match found❗");
                        }
                        else
                        {
                            Console.WriteLine("");
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.WriteLine($"{moveDino.Name} is currently in enclosure {moveDino.EnclosureNumber}.");
                            moveDino.EnclosureNumber = PromptForInteger($"Please list {moveDino.Name}'s new enclosure number: ");
                            Console.WriteLine("");
                        }
                        break;

                    case "S":
                        // count number of herbivores in dinosaurs list
                        var numberOfHerbivores = dinosaurs.Count(herbivores => herbivores.DietType == "Herbivore");
                        // count number of carnivores in dinosaurs list
                        var numberOfCarnivores = dinosaurs.Count(carnivores => carnivores.DietType == "Carnivore");
                        // display error if no dinos in park
                        if (dinosaurs.Count == 0)
                        {
                            database.NoDinosInTheParkMessage();
                        }
                        // display counts of herbs and carns to user.
                        else if (numberOfHerbivores > 0 || numberOfCarnivores > 0)
                        {
                            Console.WriteLine("");
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.WriteLine("Here is a breakdown of our dinosaurs by diet types: ");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine($"🍃 Herbivores: {numberOfHerbivores} ");
                            Console.WriteLine($"🍖 Carnivores: {numberOfCarnivores} ");
                        }
                        break;

                    case "Q":
                        keepGoing = false;
                        break;

                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("");
                        Console.WriteLine("❗That is not a valid selection. Try again❗");
                        break;
                }
            }
        }
    }
}


