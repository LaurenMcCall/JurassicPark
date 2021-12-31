using System;
using System.Collections.Generic;
using System.Linq;

namespace JurassicPark
{
    // create dinosaur class
    class Dinosaur
    {
        public string Name { get; set; }
        public string DietType { get; set; }
        public DateTime WhenAcquired { get; set; }
        public int Weight { get; set; }
        public int EnclosureNumber { get; set; }

        //   - method called Description
        //   - within the Dinosaurs class 
        //   - prints out description of an individual dinosaur that includes 
        //     the properties in the Dinosaurs class.

    }

    class DinosaurDatabase
    {
        // QUESTION ABOUT THIS...
        private List<Dinosaur> Dinosaurs { get; set; } = new List<Dinosaur>();

        // METHOD for adding a dino
        // public void AddDinosaur(Dinosaur addDino)
        // {
        //     Dinosaurs.Add(addDino);
        // }

        // METHOD for deleting a dino
        // public void RemoveDinosaur(Dinosaur removeDino)
        // {
        //     Dinosaurs.Remove(removeDino);
        // }
    }

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



            DisplayGreeting();

            var keepGoing = true;

            while (keepGoing)
            {
                // - display menu  
                Console.WriteLine("");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("PLEASE MAKE A SELECTION: ");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("-------------------------------------------");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("(V)IEW dinosaurs in the park ");
                Console.WriteLine("(A)DD a dinosaur to the park ");
                Console.WriteLine("(R)EMOVE a dinosaur from the park ");
                Console.WriteLine("(T)RANSFER a dinosaur to a different enclosure ");
                Console.WriteLine("(S)UMMARIZE dinosaur diet types ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("(Q)UIT ");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("-------------------------------------------");
                Console.WriteLine("");
                Console.ForegroundColor = ConsoleColor.White;
                var choice = Console.ReadLine().ToUpper();

                switch (choice)
                {
                    case "V":

                        break;

                    case "A":
                        var dino = new Dinosaur();

                        dino.Name = PromptForString("What is your dino's name? ").ToUpper();
                        dino.DietType = PromptForString("Is your dino an (O)mnivore or a (C)arnivore? ").ToUpper();
                        dino.WhenAcquired = DateTime.Now;
                        dino.Weight = PromptForInteger("How much does your dino weigh in pounds? ");
                        dino.EnclosureNumber = PromptForInteger("Please assign an enclosure number to your dino: ");

                        dinosaurs.Add(dino);
                        break;

                    case "R":
                        var nameToSearch = PromptForString("What is the name of the dinosaur you'd like to remove? ").ToUpper();

                        Dinosaur foundDino = dinosaurs.FirstOrDefault(dinosaur => dinosaur.Name == nameToSearch);

                        if (foundDino == null)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("");
                            Console.WriteLine("❗No match found❗");
                        }
                        else
                        {
                            Console.WriteLine("");
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
                        var nameToMove = PromptForString("What is the name of the dinosaur you'd like to remove? ").ToUpper();

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
                            Console.WriteLine($"{moveDino.Name} is currently in {moveDino.EnclosureNumber}.");
                            moveDino.EnclosureNumber = PromptForInteger($"Please list {moveDino.Name}'s new enclosure number: ");
                            Console.WriteLine("");
                        }
                        break;

                    case "S":
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

// ALGORITHM
// - if (V)IEW is selected:
//   - would you like to see the dinosaurs in Name or EnclosureNumber order?
//     - (if Name) print out Dinos by Name
//     - (if EnclosureNumber) print out Dinos by EnclosureNumber
//     - (if there are no dinos in park) "I'm sorry, our park is only full of dino 
// eggs right now. Check by once they've hatched"
// - if (R)EMOVE is selected:
//   - Remove LINQ to remove dinosaur instance from the park list.

// - if (T)RANSFER is selected:
//   - PromptForString the dinosaur Name
//   - PromptForInteger the new EnclosureNumber 
// - if (S)UMMARY is selected:
//   - will display the number of carnivores and herbivores in the park list. 
// - if (Q)UIT is selected:
//   - stop running the program.