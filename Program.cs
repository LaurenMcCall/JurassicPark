using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using CsvHelper;
using CsvHelper.Configuration;

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

            database.LoadDinosaurs();

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
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine("");
                        var userViewPreference = PromptForString("Would you like to view the dinosaurs by (N)AME or (E)NCLOSURE NUMBER? ").ToUpper();
                        var viewByName = dinosaurs.OrderBy(dinosaur => dinosaur.Name);
                        var viewByEnclosureNumber = dinosaurs.OrderBy(dinosaur => dinosaur.EnclosureNumber);

                        if (dinosaurs.Count == 0)
                        {
                            DinosaurDatabase.NoDinosInTheParkMessage();
                        }
                        else if (userViewPreference == "N")
                        {
                            foreach (var viewDino in viewByName)
                            {
                                viewDino.DisplayDinosaurs();
                            }
                        }
                        else if (userViewPreference == "E")
                        {
                            foreach (var viewDino in viewByEnclosureNumber)
                            {
                                viewDino.DisplayDinosaurs();
                            }
                        }
                        database.SaveDinosaurs();
                        break;

                    case "A":
                        var addDino = new Dinosaur();

                        Console.WriteLine("");
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        addDino.Name = PromptForString("What is your dino's name? ").ToUpper();
                        addDino.DietType = PromptForString("Is your dino an (H)erbivore or a (C)arnivore? ").ToUpper();
                        if (addDino.DietType == "H")
                        {
                            addDino.DietType = "Herbivore";
                        }
                        else if (addDino.DietType == "C")
                        {
                            addDino.DietType = "Carnivore";
                        }
                        addDino.WhenAcquired = DateTime.Now;
                        addDino.Weight = PromptForInteger("How much does your dino weigh in pounds? ");
                        addDino.EnclosureNumber = PromptForInteger("Please assign an enclosure number to your dino: ");

                        // WANT TO PROMPT USER TO INPUT NEW NUMBER IF ENCLOSURE IS ALREADY TAKEN

                        // bool enclosureNumberAlreadyAssigned = dinosaurs.Any(cageNumber => cageNumber.EnclosureNumber == dino.EnclosureNumber);
                        // if (enclosureNumberAlreadyAssigned == true)
                        // {
                        //     Console.WriteLine("That enclosure number has already been assigned. Please input another one. ");
                        // }
                        Console.WriteLine("");

                        dinosaurs.Add(addDino);
                        database.SaveDinosaurs();
                        break;

                    case "R":
                        Console.WriteLine("");
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        var nameToSearch = PromptForString("What is the name of the dinosaur you'd like to remove? ").ToUpper();

                        Dinosaur foundDino = dinosaurs.FirstOrDefault(dinosaur => dinosaur.Name == nameToSearch);
                        if (dinosaurs.Count < 1)
                        {
                            DinosaurDatabase.NoDinosInTheParkMessage();
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
                        database.SaveDinosaurs();
                        break;

                    case "T":
                        Console.WriteLine("");
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        var nameToMove = PromptForString("What is the name of the dinosaur you'd like to transfer? ").ToUpper();

                        Dinosaur moveDino = dinosaurs.FirstOrDefault(dinosaur => dinosaur.Name == nameToMove);

                        if (dinosaurs.Count < 1)
                        {
                            DinosaurDatabase.NoDinosInTheParkMessage();
                        }
                        else if (moveDino == null)
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
                        database.SaveDinosaurs();
                        break;

                    case "S":
                        // count number of herbivores in dinosaurs list
                        var numberOfHerbivores = dinosaurs.Count(herbivores => herbivores.DietType == "Herbivore");
                        // count number of carnivores in dinosaurs list
                        var numberOfCarnivores = dinosaurs.Count(carnivores => carnivores.DietType == "Carnivore");
                        // display error if no dinos in park
                        if (dinosaurs.Count == 0)
                        {
                            DinosaurDatabase.NoDinosInTheParkMessage();
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
                        database.SaveDinosaurs();
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
                // database.SaveDinosaurs();

            }

        }
    }
}


