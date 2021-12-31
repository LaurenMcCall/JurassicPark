using System;

namespace JurassicPark
{
    // create dinosaur class
    class Dino
    {
        public string Name { get; set; }
        public string DietType { get; set; }
        public DateTime WhenAcquired { get; set; }
        public int Weight { get; set; }
        public int EnclosureNumber { get; set; }
    }

    class Program
    {
        // - display welcome greeting
        static void DisplayGreeting()
        {
            Console.WriteLine();
            Console.WriteLine("🦴🦴🦴🦴🦴🦴🦴🦴🦴🦴🦴🦴🦴🦴🦴🦴🦴🦴🦴🦴🦴🦴🦴🦴🦴🦴🦴🦴🦴🦴🦴");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("  🦕🦖🦕🦖🦕🦖🦕🦖 Welcome to Jurassic Park 🦕🦖🦕🦖🦕🦖🦕🦖  ");
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
            var dino = new Dino();
            DisplayGreeting();

            // var keepGoing = true;

            // while (keepGoing)
            // {
            //     Console.WriteLine("working");
            // }

        }
    }
}

// ALGORITHM


// - display menu  
//   - "Please make a selection:
//     (V)IEW dinosaurs in the park  
//     (A)DD dinosaurs to the park 
//     (R)EMOVE dinosaurs from the park
//     (T)RANSFER dinosaurs 
//     (S)UMMARY Dinosaurs
//     (Q)UIT 
// - if (V)IEW is selected:
//   - would you like to see the dinosaurs in Name or EnclosureNumber order?
//     - (if Name) print out Dinos by Name
//     - (if EnclosureNumber) print out Dinos by EnclosureNumber
//     - (if there are no dinos in park) "I'm sorry, our park is only full dino eggs right now. Check by once they've hatched"
// - if (A)DD is selected:
//   - will prompt for the Name, DietType, Weight and EnclosureNumber. DateTime will be provided by code.
// - if (R)EMOVE is selected:
//   - Remove LINQ to remove dinosaur instance from the park list.
// - if (T)RANSFER is selected:
//   - PromptForString the dinosaur Name
//   - PromptForInteger the new EnclosureNumber 
// - if (S)UMMARY is selected:
//   - will display the number of carnivores and herbivores in the park list. 
// - if (Q)UIT is selected:
//   - stop running the program.