using System.Runtime.CompilerServices;

List <Plant> plants = new List<Plant>()
{
    new Plant()
    {
        Species = "Monstera Deliciosa",
        LightNeeds = 3,
        AskingPrice =  35.50M,
        City = "Los Angeles",
        ZIP = "90001",
        Sold = false,
        AvailableUntil = new DateTime(2024, 12, 31)
    },
    new Plant()
    {
        Species = "Snake Plant",
        LightNeeds = 2,
        AskingPrice = 20.00M,
        City = "Austin",
        ZIP = "77301",
        Sold = true,
        AvailableUntil = new DateTime(2024, 11, 12)
    },
    new Plant()
    {
        Species = "Rose Bush",
        LightNeeds = 5,
        AskingPrice = 15.65M,
        City = "Phoenix",
        ZIP = "85001",
        Sold = false,
        AvailableUntil = new DateTime(2025, 01, 15)
    },
    new Plant()
    {
        Species = "Fiddle Leaf Fig",
        LightNeeds = 4, 
        AskingPrice = 50.00M,
        City = "New York",
        ZIP = "10001",
        Sold = false,
        AvailableUntil = new DateTime(2023, 02, 02)
    },
    new Plant()
    {
        Species = "Succulent",
        LightNeeds = 5, 
        AskingPrice = 10.25M,
        City = "San Diego",
        ZIP = "92101",
        Sold = false,
        AvailableUntil = new DateTime(2024, 10, 31)
    }
};

string greeting = @"Welcome to ExtraVert
We're a plant shop!";

Console.WriteLine(greeting);

//Menu
string choice = null;
while(choice != "0")
{
    Console.WriteLine(@"Choose an option:
    0. Exit
    1. display all plants
    2. Post a plant to be adopted
    3. Adopt a plant
    4. Delist a plant
    5. View a random plant");

    choice = Console.ReadLine();
    if (choice == "0")
    {
        Console.WriteLine("Goodbye!");
    }
    else if (choice == "1")
    {
        ViewAllPlants();
    }
    else if (choice == "2")
    {
        PostPlant();
    }
    else if (choice == "3")
    {
        AdoptPlant();
    }
    else
    {
        Console.Clear();
        Console.WriteLine("Invalid option, please choose a valid number");
    }
}

void ViewAllPlants()
{
    Console.Clear();
    Console.WriteLine("Plants:");
    for (int i = 0; i < plants.Count; i++)
    {
        Console.WriteLine($"{i + 1}. {PlantDetails(plants[i])}");
    }
}

void PostPlant()
{
    Console.Clear();
    Console.WriteLine("Post a plant for adoption:");

    Console.WriteLine("Enter the plant species:");
    string species = Console.ReadLine();

    Console.WriteLine("Enter the light needs of the plant");
    int lightNeeds;
    while (!int.TryParse(Console.ReadLine(), out lightNeeds) || lightNeeds < 1 || lightNeeds > 5)
    {
        Console.WriteLine("Please enter a valid light needs value between 1 and 5.");
    }

    Console.WriteLine("ENter the asking price: ");
    decimal askingPrice;
    while (!decimal.TryParse(Console.ReadLine(), out askingPrice) || askingPrice < 0)
    {
        Console.WriteLine("Please enter a valid price.");
    }
    
    Console.WriteLine("Enter the city: ");
    string city = Console.ReadLine();

    Console.WriteLine("Enter ZIP Code: ");
    string zip = Console.ReadLine();
 
    DateTime  availableUntil;
    while (true)
    {
        try
        {
            Console.WriteLine("Enter the date the plant is available until;");

            Console.Write("Year: ");
            int year = int.Parse(Console.ReadLine());

            Console.Write("Month");
            int month = int.Parse(Console.ReadLine());

            Console.Write("Day");
            int day = int.Parse(Console.ReadLine());

            availableUntil = new DateTime(year, month, day);
            break;
        }
        catch (ArgumentException)
        {
            Console.WriteLine("Invalid date entered. Please enter a valid date.");
        }
        catch (FormatException)
        {
            Console.WriteLine("Please enter only numbers for the year, month , and day");
        }
    }

    Plant newPlant = new Plant()
    {
        Species = species,
        LightNeeds = lightNeeds,
        AskingPrice = askingPrice,
        City = city,
        ZIP = zip,
        Sold = false, 
        AvailableUntil = availableUntil
         
    };

    plants.Add(newPlant);

    Console.Clear();
    Console.WriteLine($"The plant {species} has been posted for adoption in {city} with a price of ${askingPrice}");
}

void AdoptPlant()
{
    Console.Clear();
    Console.WriteLine("Adopt plant:");
}





string PlantDetails(Plant plant)
{
    string plantString = $"{plant.Species} in {plant.City} {(plant.Sold ? "was sold" : "is available")} for {plant.AskingPrice:C}, available until {plant.AvailableUntil.ToShortDateString()}";
    return plantString;
}