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
        static void Main(string[] args)
        {

            var database = new DinosaurDatabase();
            // var dinosaurs = new List<Dinosaur>();

            database.LoadDinosaurs();

            DinosaurDatabase.DisplayGreeting();

            var keepGoing = true;

            while (keepGoing)
            {
                // - display menu  
                DinosaurDatabase.DisplayMenu();

                var choice = Console.ReadLine().ToUpper();

                switch (choice)
                {
                    case "V":
                        DinosaurDatabase.ViewAllDinos(database.Dinosaurs);
                        break;
                    case "A":
                        DinosaurDatabase.AddNewDino(database);
                        break;
                    case "R":
                        DinosaurDatabase.RemoveDinosaur(database);
                        break;
                    case "T":
                        DinosaurDatabase.TransferDino(database);
                        break;
                    case "S":
                        DinosaurDatabase.ShowDinosByDietType(database);
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
                database.SaveDinosaurs();

            }

        }

    }
}


