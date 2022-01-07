using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using CsvHelper;

namespace JurassicPark
{
    class DinosaurDatabase
    {
        // QUESTION ABOUT THIS...
        public List<Dinosaur> Dinosaurs { get; set; } = new List<Dinosaur>();

        private string FileName = "dinosaur.csv";

        // METHOD FOR ADDING DINO
        private void AddDinosaur(Dinosaur newDinosaur)
        {
            Dinosaurs.Add(newDinosaur);
        }

        // METHOD FOR DELETING DINO
        private void RemoveDinosaur(Dinosaur removeDinosaur)
        {
            Dinosaurs.Remove(removeDinosaur);
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"{removeDinosaur.Name} has been removed from the park. Bye, {removeDinosaur.Name}! We'll miss you 💙 ");
            Console.WriteLine("");
        }

        // METHOD TO FIND DINO BY NAME
        Dinosaur FindOneDinosaur(string dinoName)
        {
            Dinosaur foundDinosaur = Dinosaurs.FirstOrDefault(dinosaur => dinosaur.Name.ToUpper().Contains(dinoName.ToUpper()));

            return foundDinosaur;
        }

        public void LoadDinosaurs()
        {
            if (File.Exists(FileName))
            {
                var fileReader = new StreamReader(FileName);

                var csvReader = new CsvReader(fileReader, CultureInfo.InvariantCulture);

                Dinosaurs = csvReader.GetRecords<Dinosaur>().ToList();

                fileReader.Close();
            }
        }

        public void SaveDinosaurs()
        {
            var fileWriter = new StreamWriter(FileName);

            var csvWriter = new CsvWriter(fileWriter, CultureInfo.InvariantCulture);

            csvWriter.WriteRecords(Dinosaurs);

            fileWriter.Close();
        }

        public static void NoDinosInTheParkMessage()
        {
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("There are no dinos in the park, just dino eggs. Check back again once they've hatched 🐣 ");
        }

        // // - display welcome greeting
        public static void DisplayGreeting()

        {
            Console.WriteLine();
            Console.WriteLine("🦴🦴🦴🦴🦴🦴🦴🦴🦴🦴🦴🦴🦴🦴🦴🦴🦴🦴🦴🦴🦴🦴🦴🦴🦴🦴🦴🦴🦴🦴🦴");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("  🦕🦖🦕🦖🦕🦖🦕🦖 WELCOME TO JURASSIC PARK 🦕🦖🦕🦖🦕🦖🦕🦖  ");
            Console.WriteLine("🦴🦴🦴🦴🦴🦴🦴🦴🦴🦴🦴🦴🦴🦴🦴🦴🦴🦴🦴🦴🦴🦴🦴🦴🦴🦴🦴🦴🦴🦴🦴");
            Console.WriteLine();
        }

        public static void DisplayMenu()
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

        public static void NoMatchFound()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("");
            Console.WriteLine("❗No match found❗");
        }

        // prompt for string method
        public static string PromptForString(string prompt)
        {
            Console.Write(prompt);
            var userInput = Console.ReadLine();

            return userInput;
        }

        // prompt for integer
        public static int PromptForInteger(string prompt)
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
        public static void ShowDinosByDietType(DinosaurDatabase database)
        {
            // count number of herbivores in dinosaurs list
            var numberOfHerbivores = database.Dinosaurs.Count(herbivores => herbivores.DietType == "Herbivore");
            // count number of carnivores in dinosaurs list
            var numberOfCarnivores = database.Dinosaurs.Count(carnivores => carnivores.DietType == "Carnivore");
            // display error if no dinos in park
            if (database.Dinosaurs.Count == 0)
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
        }

        public static void TransferDino(DinosaurDatabase database)
        {
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.Cyan;
            var nameToMove = PromptForString("What is the name of the dinosaur you'd like to transfer? ").ToUpper();

            Dinosaur moveDino = database.FindOneDinosaur(nameToMove);

            if (database.Dinosaurs.Count < 1)
            {
                DinosaurDatabase.NoDinosInTheParkMessage();
            }
            else if (moveDino == null)
            {
                NoMatchFound();
            }
            else
            {
                Console.WriteLine("");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine($"{moveDino.Name} is currently in enclosure {moveDino.EnclosureNumber}.");
                moveDino.EnclosureNumber = PromptForInteger($"Please list {moveDino.Name}'s new enclosure number: ");
                Console.WriteLine("");
            }
        }

        public static void RemoveDinosaur(DinosaurDatabase database)
        {
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.Cyan;
            var nameToSearch = PromptForString("What is the name of the dinosaur you'd like to remove? ").ToUpper();

            Dinosaur foundDino = database.FindOneDinosaur(nameToSearch);
            // Dinosaur foundDino = dinosaurs.FirstOrDefault(dinosaur => dinosaur.Name == nameToSearch);
            if (database.Dinosaurs.Count == 0)
            {
                DinosaurDatabase.NoDinosInTheParkMessage();
            }

            // WHY ISN'T THIS SHOWING UP WHEN THERE ARE NO DINOs IN THE LIST?
            if (foundDino == null)
            {
                NoMatchFound();
            }
            else
            {
                Console.WriteLine("");
                Console.ForegroundColor = ConsoleColor.Cyan;
                var confirmRemoval = PromptForString($"Are you sure you want to remove {foundDino.Name} from the park? (Y)ES or (N)O ").ToUpper();
                if (confirmRemoval == "Y")
                {
                    database.RemoveDinosaur(foundDino);
                }
            }
        }

        public static void AddNewDino(DinosaurDatabase database)
        {
            var addDinosaur = new Dinosaur();

            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.Cyan;
            addDinosaur.Name = PromptForString("What is your dino's name? ").ToUpper();
            addDinosaur.DietType = PromptForString("Is your dino an (H)erbivore or a (C)arnivore? ").ToUpper();
            if (addDinosaur.DietType == "H")
            {
                addDinosaur.DietType = "Herbivore";
            }
            else if (addDinosaur.DietType == "C")
            {
                addDinosaur.DietType = "Carnivore";
            }
            addDinosaur.WhenAcquired = DateTime.Now;
            addDinosaur.Weight = PromptForInteger("How much does your dino weigh in pounds? ");
            addDinosaur.EnclosureNumber = PromptForInteger("Please assign an enclosure number to your dino: ");
            // WANT TO PROMPT USER TO INPUT NEW NUMBER IF ENCLOSURE IS ALREADY TAKEN

            // bool enclosureNumberAlreadyAssigned = dinosaurs.Any(cageNumber => cageNumber.EnclosureNumber == dino.EnclosureNumber);
            // if (enclosureNumberAlreadyAssigned == true)
            // {
            //     Console.WriteLine("That enclosure number has already been assigned. Please input another one. ");
            // }
            Console.WriteLine("");
            database.AddDinosaur(addDinosaur);
        }

        public static void ViewAllDinos(List<Dinosaur> dinosaurs)
        {
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
        }

    }

}
