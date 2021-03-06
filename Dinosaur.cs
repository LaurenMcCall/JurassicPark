using System;

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

        public void DisplayDinosaurs()
        {
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"Name: {Name} ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"Diet: {DietType} ");
            Console.WriteLine($"Acquired: {WhenAcquired} ");
            Console.WriteLine($"Weight: {Weight} lbs ");
            Console.WriteLine($"Enclosure #: {EnclosureNumber} ");
            Console.WriteLine("");
        }
    }
}

// ALGORITHM


// - if (S)UMMARY is selected:
//   - will display the number of carnivores and herbivores in the park list. 
