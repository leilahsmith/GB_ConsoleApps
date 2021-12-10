using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoCafe
{
    public class ProgramUI
    {

        private KC_Repo _menuRepo = new KC_Repo();

        public void Run()
        {
            // Seeds data into our app.
            SeedCafeMenu();

            // Run Menu Method
            RunMenu();
        }
        //Menu
        private void RunMenu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                Console.Clear();
                Console.WriteLine("-- Main Menu --");
                //Display our options to the user
                Console.WriteLine("Select a menu option:\n +" +
                    "1. Create New Items\n" +
                    "2. View All Items\n" +
                    "3. Update Exising Menu Item\n" +
                    "4. Delete Existing Items\n" +
                    "5. Exit");

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
                        //Update Existing Items
                        UpdateCafeItem();
                        break;
                    case "4":
                        //Delete Exisitng Items
                        DeleteExistingItems();
                        break;
                    case "5":
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
            KC_Poco items = new KC_Poco();
            bool looper = true;

            while (looper)
            {

                Console.Clear();
                Console.WriteLine("<-- Adding New Menu Item -->");
                Console.WriteLine("Enter Cafe Menu #:");
                items.Number = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter Item Name:");
                items.Name = Console.ReadLine();
                Console.WriteLine("Enter Item Description:");
                items.Description = Console.ReadLine();
                Console.WriteLine("Enter list of item ingredients:");
                items.Ingredients = Console.ReadLine();
                Console.WriteLine("Enter price of item:");
                items.Price = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("-- New Item --");
                Console.WriteLine("Item #:            " + items.Number);
                Console.WriteLine("Item Name:         " + items.Name);
                Console.WriteLine("Item Description:  " + items.Description);
                Console.WriteLine("Item Ingredients:  " + items.Ingredients);
                Console.WriteLine("Item Price:        $" + items.Price);
                Console.WriteLine("");
                Console.WriteLine("Is the new menu item correct? \nEnter Y to continue adding the new item to the cafe menu. Enter N to start over with creating the new item.");
                
                string isCorrect = Console.ReadLine();
                if (isCorrect.ToLower() == "y")
                {
                    looper = false;
                }
            }

            bool wasAdded = _menuRepo.AddItemsToMenu(items);
            if (wasAdded == true)
            {
                Console.WriteLine("Menu Item added successfully");
                Console.WriteLine("Press any key to return to the main menu");
            }
            else
            {
                Console.WriteLine("Oops! Something went wrong. Your new item was not added to the menu. Please try again.");
                Console.WriteLine("Press any key to return to the main menu");
            }

            Console.ReadKey();

            PressAnyKeyToReturnToMainMenu();
        }
        // View current menu items that are saved
        private void ViewAllItems()
        {
            Console.Clear();
            Console.WriteLine("<--- Displaying all Menu Items --->");
            List<KC_Poco> menuRepo = _menuRepo.GetCafeItems();

            foreach (KC_Poco items in menuRepo)
            {
                Console.WriteLine($"{items.Name}.\n" +
                    $"{items.Number}\n" +
                    $"{items.Description}\n" +
                    $"{items.Ingredients}\n" +
                    $"{items.Price}\n");
            }

            Console.WriteLine("Press Enter to return to main menu.");
            Console.ReadKey();
        }

        //Update Cafe Items
        public void UpdateCafeItem()
        {
            KC_Poco oldItem = new KC_Poco();
            Console.Clear();
            Console.WriteLine("-- Update Existing Menu Item --");
            Console.WriteLine("Enter the Item # for the Menu Item you'd like to update:");
            int oldItemNumber = Convert.ToInt32(Console.ReadLine());
            oldItem = _menuRepo.GetCafeItemsByItemNumber(oldItemNumber);
            bool looper = true;
            while (looper)
            {
                Console.Clear();
                Console.WriteLine("-- Menu Item --");
                Console.WriteLine("1. Item #:            " + oldItem.Number);
                Console.WriteLine("2. Item Name:         " + oldItem.Name);
                Console.WriteLine("3. Item Description:  " + oldItem.Description);
                Console.WriteLine("4. Item Ingredients:  " + oldItem.Ingredients);
                Console.WriteLine("5. Item Price:        $" + oldItem.Price);
                Console.WriteLine("6. Finished editing");
                Console.WriteLine("Please enter the number for the value you'd like to edit");
                string menuSelection = Console.ReadLine();
                switch (menuSelection)
                {
                    case "1":
                        Console.WriteLine("Enter new Item #:");
                        oldItem.Number = Convert.ToInt32(Console.ReadLine());
                        break;
                    case "2":
                        Console.WriteLine("Enter new Name:");
                        oldItem.Name = Console.ReadLine();
                        break;
                    case "3":
                        Console.WriteLine("Enter new item Description:");
                        oldItem.Description = Console.ReadLine();
                        break;
                    case "4":
                        Console.WriteLine("Enter new Ingredients:");
                        oldItem.Ingredients = Console.ReadLine();
                        break;
                    case "5":
                        Console.WriteLine("Enter new Price:");
                        oldItem.Price = Convert.ToDouble(Console.ReadLine());
                        break;
                    case "6":
                        looper = false;
                        break;
                }
            }
            bool wasUpdate = _menuRepo.UpdateExistingCafeItem(oldItemNumber, oldItem);
            if (wasUpdate == true)
            {
                Console.WriteLine("Item updated. \nPress any key to continue");
            }
            else
            {
                Console.WriteLine("Sorry, something went wrong. Please try updating again. \nPress any key to continue");
            }

            Console.ReadKey();
        }


        // Delete existing items
        private void DeleteExistingItems()
        {
            KC_Poco oldItem = new KC_Poco();
            Console.Clear();
            ViewAllItems();
            // Get the item they want to remove
            Console.WriteLine("\nEnter the number of the item you'd like to remove from the cafe menu:");
            int itemNumber = Int32.Parse(Console.ReadLine());
            oldItem = _menuRepo.GetCafeItemsByItemNumber(itemNumber);

            // Call the delete method
            bool deleteConfirm = _menuRepo.RemoveItemFromList(oldItem);

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
        private void SeedCafeMenu()
        {
            KC_Poco cafeAmericano = new KC_Poco("Cafe Americano", 1, "Rich espresso with artisan water heated perfectly for a delcious and bold flavor", "Espresso & water", 3.99);
            KC_Poco cafeMocha = new KC_Poco("Cafe Mocha", 2, "Iced or hot mocha latte", "Chocolate, espresso, milk, whipped cream, drizzle", 4.99);
            KC_Poco cortado = new KC_Poco("Cortado", 3, "A short cup of bold espresso balanced with just a touch of milk", "Espresso & milk", 3.99);
            KC_Poco singleEspresso = new KC_Poco("Single Espresso", 4, "A single 1 ounce of full-bodied espresso from the highest regions of heaven", "Just espresso", 1.50);
            KC_Poco doubleEspresso = new KC_Poco("Double Espresso", 5, "Can't handle just one? Give yourself TWO ounces of the best espresso to ever grace your lips.", "Literally still just espresso", 3.00);
            KC_Poco breakfastSandwich = new KC_Poco("Breakfast Sandwich", 6, "Ham & cheese on a croissant.", "Ham, Cheese, Croissant", 5.99);
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

