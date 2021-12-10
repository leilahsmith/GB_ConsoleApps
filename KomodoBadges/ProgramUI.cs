using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoBadges
{
    public class ProgramUI
    {
        public BadgeRepo _listOfBadges = new BadgeRepo();

        public void Run()
        {
            // Seeds data into our app.
            SeedBadgeList();

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
                Console.WriteLine("<-- Main Menu -->");
                //Display our options to the user
                Console.WriteLine("Hello Security Admin, What would you like to do?:\n +" +
                    "1. Add a badge\n" +
                    "2. Edit a badge\n" +
                    "3. View all badges\n" +
                    "4. Exit");

                //Get user's input
                string input = Console.ReadLine();

                //Evaluate the user's input and act accordingly. 
                switch (input)
                {
                    case "1":
                        //Create New Items
                        AddBadgeToList();
                        break;
                    case "2":
                        //View all items
                        ViewExistingBadges();
                        break;
                    case "3":
                        //Delete Exisitng Items
                        DeleteExistingBadges();
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

        private void AddBadgeToList()
        {
            int badgeNum = Convert.ToInt32(Console.ReadLine());
            if (_listOfBadges.GetABadgeByID(badgeNum) != null)
            {
                Console.WriteLine("Badge already exists. Try Updating badge instead of Adding");
                Console.WriteLine("Press any key to return to main menu.");
            }
            else
            {

                BadgeListPoco newBadge = new BadgeListPoco(badgeNum);
                bool looper = true;
                List<string> doors = new List<string>();
                while (looper)
                {
                    Console.WriteLine("Enter a door that Badge #" + badgeNum + " needs access to: ");
                    doors.Add(Console.ReadLine());
                    Console.WriteLine("Any other doors (y/n)?");
                    string moreDoors = Console.ReadLine();
                    if (moreDoors.ToLower() == "n")
                    {
                        looper = false;
                    }
                }
                newBadge.Doors = doors;
                string doorResult = string.Join(",", doors);
                bool wasAdded = _listOfBadges.AddBadgeToList(newBadge);
                if (wasAdded == true)
                {
                    Console.WriteLine($"Badge #{newBadge.BadgeID} added Successfully with access to Doors: {doorResult}.");

                }
                else
                {
                    Console.WriteLine($"Oops! Something went wrong adding Badge #{newBadge.BadgeID}. Please try again.");
                }
                Console.WriteLine("Press any key to return to the main menu.");
            }
            Console.ReadKey();
        }

        // View current menu items that are saved
        private void ViewExistingBadges()
        {
            Console.Clear();
            List<BadgeListPoco> listOfItems = _listOfBadges.ViewExistingBadges();

            foreach (BadgeListPoco badges in _listOfBadges)
            {
                Console.WriteLine($"{badges.BadgeNumber}.\n" + $"{badges.Doors}\n");
            }
        }
        //Update existing items
        //*NEED TO WORK ON THIS PART


        // Delete existing items
        private void DeleteExistingBadges()
        {
            ViewExistingBadges();
            // Get the item they want to remove
            Console.WriteLine("\nEnter the number of the badge you'd like to remove:");
            int input = Int32.Parse(Console.ReadLine());

            // Call the delete method
            bool deleteConfirm = _listOfBadges.DeleteExistingBadges(input);

            // If the content was deleted, say so
            // Otherwise state it couldn't be deleted. 

            if (deleteConfirm)
            {
                Console.WriteLine("The access was successfully deleted from the badge.");
            }
            else
            {
                Console.WriteLine("The access was not deleted successfully from the badge. Please try again.");
            }

        }
        public void PressAnyKeyToReturnToMainMenu()
        {
            Console.WriteLine("Press any key to return to Main Menu.");
            Console.ReadKey();
            RunMenu();
        }

        //Seed Method
        private void SeedBadgeList()
        {
            BadgeListPoco badgeAlpha = new BadgeListPoco(12345, new List<string> { "A7" });
            BadgeListPoco badgeBravo = new BadgeListPoco(22345, new List<string> { "A1", "A4", "B1", "B2" });
            BadgeListPoco badgeCharlie = new BadgeListPoco(32345, new List<string> { "A4", "A5" });

            _listOfBadges.AddBadgeToList(badgeAlpha);
            _listOfBadges.AddBadgeToList(badgeBravo);
            _listOfBadges.AddBadgeToList(badgeCharlie);
        }
    }
}


