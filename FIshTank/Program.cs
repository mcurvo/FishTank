using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace FishTankLibrary
{
    public class Fish
    {
        public string Name { get; set; }
        public string Type { get; set; }
    }

    public class Tank
    {
        private List<Fish> fishList;
        private Dictionary<string, double> fishTypeFoodDict;

        // Constructor that initializes the fish type food amounts
        public Tank()
        {
            fishList = new List<Fish>();
            fishTypeFoodDict = new Dictionary<string, double>
            {
                { "GoldFish", 0.1 },
                { "AngelFish", 0.2 },
                { "BabelFish", 0.3 }
            };
        }

        // Method to add a fish to the tank
        public void AddFish(Fish fish)
        {
            // Check if the fish type is valid
            while (!fishTypeFoodDict.ContainsKey(fish.Type))
            {
                Console.WriteLine($"\nInvalid fish type: {fish.Type}.\nValid types are:\n");
                foreach (string type in fishTypeFoodDict.Keys)
                {
                    Console.WriteLine(type);
                }
                // If the fish type is not valid, print an valid fish type
                Console.Write("\nPlease enter a valid fish type: ");
                fish.Type = Console.ReadLine();
            }
            // Add the fish to the fish list
            fishList.Add(fish);
            Console.Clear();
            Console.WriteLine($"Added {fish.Name} ({fish.Type}) to the tank.");

        }

        // Method to add a new fish type to the tank
        public void AddFishType(string type, double foodAmount)
        {
            // Check if the fish type already exists
            while (fishTypeFoodDict.ContainsKey(type))
            {
                // If the fish type already exists, print an error message and return
                Console.WriteLine($"Error: Fish type '{type}' already exists.\nEnter fish type:");
                type = Console.ReadLine();
            }
            // Add the new fish type and food amount to the fish type food dictionary
            fishTypeFoodDict.Add(type, foodAmount);
            Console.Clear();
            Console.WriteLine($"Added {type} to the tank with a food amount of {foodAmount}.");
        }

        // Method to calculate the total amount of food to feed the fish in the tank
        public void Feed()
        {
            double totalFoodWeight = 0.0;

            foreach (Fish fish in fishList)
            {
                if (fishTypeFoodDict.ContainsKey(fish.Type))
                {
                    totalFoodWeight += fishTypeFoodDict[fish.Type];
                }
                else
                {
                    Console.WriteLine("Unknown fish type.");
                }
            }
            Console.Clear();
            Console.WriteLine($"Put {Math.Round(totalFoodWeight, 3)} grams of fish food in the tank.");
        }

        // Method to list all the fish in the tank along with their names, types, and food amounts
        public void ListFish()
        {
            if (fishList.Count == 0)
            {
                Console.WriteLine("There are no fish in the tank.");
            }
            else
            {
                Console.WriteLine("Fish in the tank:");
                Dictionary<string, double> fishTypeFoodAmountDict = new Dictionary<string, double>();
                foreach (Fish fish in fishList)
                {
                    if (!fishTypeFoodAmountDict.ContainsKey(fish.Type))
                    {
                        fishTypeFoodAmountDict.Add(fish.Type, fishTypeFoodDict[fish.Type]);
                    }
                    else
                    {
                        fishTypeFoodAmountDict[fish.Type] += fishTypeFoodDict[fish.Type];
                    }
                    Console.WriteLine($"Name: {fish.Name}, Type: {fish.Type}, Food amount: {fishTypeFoodDict[fish.Type]} g");
                }
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Tank tank = new Tank();

            // Create 3 Fish objects, GoldFish, AngelFish, and BabelFish
            Fish goldFish = new Fish { Name = "Goldie", Type = "GoldFish" };
            Fish angelFish = new Fish { Name = "Angie", Type = "AngelFish" };
            Fish babelFish = new Fish { Name = "Babel", Type = "BabelFish" };
            tank.AddFish(goldFish);
            tank.AddFish(angelFish);
            tank.AddFish(babelFish);
            Console.Clear();
            //// Add a new FishType "Tetra"
            //tank.AddFishType("Tetra", 0.4);
            //Fish Tetra = new Fish { Name = "Champ", Type = "Tetra" };
            //tank.AddFish(Tetra);

            // Set the exit flag
            bool exit = false;
            
            // Loop until the exit flag is set to true
            while (!exit)
            {
                // Display the options to the user
                Console.WriteLine("What would you like to do?");
                Console.WriteLine("1 - Add a Fish");
                Console.WriteLine("2 - Add a Fish Type");
                Console.WriteLine("3 - Amount to feed the tank");
                Console.WriteLine("4 - List all fish in the tank");
                Console.WriteLine("5 - Exit");

                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        // Add a new Fish to the tank
                        Console.Write("Enter fish name: ");
                        string name = Console.ReadLine();
                        Console.Write("Enter fish type: ");
                        string type = Console.ReadLine();

                        Fish fish = new Fish { Name = name, Type = type };
                        tank.AddFish(fish);
                        break;

                    case 2:
                        // Add a new FishType to the tank
                        Console.Write("Enter fish type: ");
                        string newType = Console.ReadLine();
                        Console.Write("Enter food amount: ");
                        
                        double foodAmount = Convert.ToDouble(Console.ReadLine());

                        tank.AddFishType(newType, foodAmount);
                        break;

                    case 3:
                        // Get the amount of food to feed the tank
                        tank.Feed();
                        break;

                    case 4:
                        // List all the Fish objects in the Tank object
                        Console.Clear();
                        tank.ListFish();
                        break;
                    case 5:
                        // Set the exit flag to true to exit the loop
                        exit = true;
                        break;

                    default:
                        // Handle invalid choices
                        Console.WriteLine("Invalid choice.");
                        break;

                }

                Console.WriteLine();
            }
        }
    }
};