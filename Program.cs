using System;

namespace JurassicPark
{
    class Program
    {
        static void Main(string[] args)
        {

            var database = new DinosaurDatabase();

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


