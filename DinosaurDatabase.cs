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
        private List<Dinosaur> Dinosaurs { get; set; } = new List<Dinosaur>();

        private string FileName = "dinosaur.csv";

        // METHOD FOR ADDING DINO
        public void AddDinosaur(Dinosaur newDinosaur)
        {
            Dinosaurs.Add(newDinosaur);
        }

        // METHOD FOR DELETING DINO
        public void RemoveDinosaur(Dinosaur removeDinosaur)
        {
            Dinosaurs.Remove(removeDinosaur);
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"{removeDinosaur.Name} has been removed from the park. Bye, {removeDinosaur.Name}! We'll miss you 💙 ");
            Console.WriteLine("");
        }

        // METHOD TO FIND DINO BY NAME
        public Dinosaur FindOneDinosaur(string dinoName)
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

    }

}
