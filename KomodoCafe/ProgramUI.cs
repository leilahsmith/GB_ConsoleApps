using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoCafe
{
    private KomodoCafeRepo _menuRepo = new KomodoCafeRepo();

    public void Run()
    {
        // Seeds data into our app.
        SeedItemList();

        // Run Menu Method
        RunMenu();
    }
    //Menu
    private void RunMenu()
    {
        bool keepRunning = true;
        while (keepRunning)
        {
            //Display our options to the user
            Console.WriteLine("Select a menu option:\n +" +
                "1. Create New Items\n" +
                "2. View All Items\n" +
                "3. Delete Existing Items\n" +
                "4. Exit");

            //Get user's input
            string input = Console.ReadLine();

            //Evaluate the user's input and act accordingly. 
            switch (input)
            {
                case "1":
                    //Create New Items
                    CreateNewItems();
                    break;
                case "2":
                    //View all items
                    ViewAllItems();
                    break;
                case "3":
                    //Delete Exisitng Items
                    DeleteExistingItems();
                    break;
                case "4":
                    //Exit
                    Console.WriteLine("So long for now!");
                    keepRunning = false;
                    break;
                default:
                    Console.WriteLine("Please enter a valid number.");
                    break;
            }

            Console.WriteLine("Please press any key to continue.");
            Console.ReadKey();
            Console.Clear();

        }
    }

    private void CreateNewItems()
    {
        Console.Clear();

        //Name
        Console.WriteLine("Enter a name for the new menu item:");
        string name = Console.ReadLine();

        //Meal Number
        Console.WriteLine("Enter a number for the new menu item:");
        int number = Int32.Parse(Console.ReadLine());

        //Description
        Console.WriteLine("Enter the description for the new menu item:");
        string description = Console.ReadLine();

        //Ingredients
        Console.WriteLine("Enter the ingredients for the new menu item:");
        string ingredients = Console.ReadLine();

        //Price
        Console.WriteLine("Enter the price for the new menu item:");
        double price = double.Parse(Console.ReadLine());

        KC_Poco newItem = new KC_Poco(name, number, description, ingredients, price);

        _menuRepo.AddItemsToMenu(newItem);

        PressAnyKeyToReturnToMainMenu();
    }
    // View current menu items that are saved
    private void ViewAllItems()
    {
        Console.Clear();
        List<KC_Poco> listOfItems = _menuRepo.GetMenuItems();

        foreach (KC_Poco items in listOfItems)
        {
            Console.WriteLine($"{items.Name}.\n" + $"{items.Number}\n" + $"{items.Description}\n" + $"{items.Description}\n" + $"{items.Price}\n");
        }
    }

    // Delete existing items
    private void DeleteExistingItems()
    {
        ViewAllItems();
        // Get the item they want to remove
        Console.WriteLine("\nEnter the ID Number of the badge you'd like to remove door access from:");
        int input = Int32.Parse(Console.ReadLine());

        // Call the delete method
        bool deleteConfirm = _menuRepo.RemoveItemFromList(input);

        // If the content was deleted, say so
        // Otherwise state it couldn't be deleted. 

        if (deleteConfirm)
        {
            Console.WriteLine("The item was successfully deleted.");
        }
        else
        {
            Console.WriteLine("The item was not deleted successfully. Please try again.");
        }

    }
    public void PressAnyKeyToReturnToMainMenu()
    {
        Console.WriteLine("Press any key to return to Main Menu.");
        Console.ReadKey();
        RunMenu();
    }

    //Seed Method
    private void SeedItemList()
    {
        KC_Poco cafeAmericano = new KC_Poco("Cafe Americano", 1, "Rich espresso with artisan water heated perfectly for a delcious and bold flavor", "Espresso & water", 3.99);
        KC_Poco cafeMocha = new KC_Poco("Cafe Mocha", 2, "Iced or hot mocha latte", "Chocolate, espresso, milk, whipped cream, drizzle", 4.99);
        KC_Poco cortado = new KC_Poco("Cortado", 3, "A short cup of bold espresso balanced with just a touch of milk", "Espresso & milk", 3.99);
        KC_Poco singleEspresso = new KC_Poco("Single Espresso", 4, "A single 1 ounce of full-bodied espresso from the highest regions of heaven", "Just espresso", 1.50);
        KC_Poco doubleEspresso = new KC_Poco("Double Espresso", 5, "Can't handle just one? Give yourself TWO ounces of the best espresso to ever grace your lips.", "Literally still just espresso", 3.00);
        KC_Poco breakfastSandwich = new KC_Poco("BreakfastSandwich", 6, "Ham & cheese on a croissant.", "Ham, Cheese, Croissant", 5.99);
        KC_Poco muffin = new KC_Poco("Blueberry Muffin", 7, "Artisan Blueberries also from the highest peak in heaven", "Blueberries, Gluten, Carbs, and Surprise... sugar", 3.50);
        KC_Poco fruitCup = new KC_Poco("Fruit Cup", 8, "Fruit, it's the healthy option.", "Grapes, Canteloupe, Strawberries, kiwi, and melon", 5.50);



        _menuRepo.AddItemsToMenu(cafeAmericano);
        _menuRepo.AddItemsToMenu(cafeMocha);
        _menuRepo.AddItemsToMenu(cortado);
        _menuRepo.AddItemsToMenu(singleEspresso);
        _menuRepo.AddItemsToMenu(doubleEspresso);
        _menuRepo.AddItemsToMenu(breakfastSandwich);
        _menuRepo.AddItemsToMenu(muffin);
        _menuRepo.AddItemsToMenu(fruitCup);
    }
}
}
