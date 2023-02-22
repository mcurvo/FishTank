# Fish Tank

This is a C# class library for managing a fish tank. It provides the ability to add different types of fish to the tank and calculate the amount of food needed to feed the fish in the tank.

## User Storie

- A user should be able to add 3 types of fish to the tank (Gold fish, Angel fish, Babel fish) and name the fish
- A user should be able to see how much food to put in the tank with a `Tank.Feed()` method. This should return the weight in grams of the total required fish food.
  - 0.1 g for each Gold fish
  - 0.2 g for each Angel fish
  - 0.3 g for each Babel fish
- Ensure the design allows adding more types of fish in the future without having to change the tank class

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
