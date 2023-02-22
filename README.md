# Fish Tank

This is a C# class library for managing a fish tank. It provides the ability to add different types of fish to the tank and calculate the amount of food needed to feed the fish in the tank.

## User Storie

The application should provide a feature that enables the user to add three different types of fish, which are Gold fish, Angel fish, and Babel fish to the tank. Additionally, the user should be able to name each fish added to the tank. To calculate the amount of food needed for the fish in the tank, the application should provide a Tank.Feed() method that returns the weight in grams of the total required fish food. Specifically, each Gold fish requires 0.1 grams of fish food, each Angel fish requires 0.2 grams, and each Babel fish requires 0.3 grams. The application also allows for the addition of new fish types without requiring modifications to the Tank class.

## Usage

To use the library, create a new instance of the `Tank` class and call its methods to add fish, add fish types, feed the fish, and list the fish in the tank.

```csharp
// Example usage:
using FishTankManager;

// Create a new instance of the Tank class
Tank tank = new Tank();

// Add fish to the tank
Fish goldFish = new Fish { Name = "Goldie", Type = "GoldFish" };
tank.AddFish(goldFish);

// Add a custom fish type
tank.AddFishType("Tetra", 0.4);

// Add a fish of the custom type to the tank
Fish Tetra = new Fish { Name = "Champ", Type = "Tetra" };
tank.AddFish(Tetra);

// Get the total amount of food needed for the tank
double foodWeight = tank.Feed();

// List all fish in the tank
tank.ListFish();
