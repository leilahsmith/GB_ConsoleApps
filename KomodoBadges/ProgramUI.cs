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
                        ViewAllBadges();
                        break;
                    case "3":
                        //Delete Exisitng Items
                        DeleteExistingAccessOnBadges();
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

        private BadgeRepo Get_listOfBadges()
        {
            return _listOfBadges;
        }

        // View current menu items that are saved
        public void ViewAllBadges()
        {
            Console.Clear();
            Console.WriteLine("=-=-=-=- View All Badges -=-=-=-=");
            Console.WriteLine("Badge#           Door Access:");
            Dictionary<int, List<string>> badges = _listOfBadges.ViewExistingBadges();
            foreach (KeyValuePair<int, List<string>> badge in badges)
            {
                string doorsResult = string.Join(",", badge.Value);
                Console.WriteLine($"{badge.Key}            {doorsResult}");

            }
            PressAnyKeyToReturnToMainMenu();
        }
        //Update existing items
        //*NEED TO WORK ON THIS PARTpublic void EditBadge()
        public void UpdateExistingBadge()
        {
            Console.Clear();
            Console.WriteLine("<--- Update a Badge --->");
            Console.WriteLine("What is the badge number you would like to update?:");
            int badgeNumber = Convert.ToInt32(Console.ReadLine());
            BadgeListPoco badgeToUpdate = _listOfBadges.GetABadgeByID(badgeNumber);
            List<string> doorsOnBadge = new List<string>();
            if (badgeToUpdate != null)
            {
                doorsOnBadge = badgeToUpdate.Doors;
                bool looper = true;
                while (looper)
                {

                    Console.Clear();
                    string doorsResult = string.Join(",", badgeToUpdate.Doors);
                    Console.WriteLine($"Badge #{badgeToUpdate.BadgeID} has access to doors: {doorsResult}.");
                    Console.WriteLine("What would you like to do?");
                    Console.WriteLine("     1. Remove a door");
                    Console.WriteLine("     2. Add a door");
                    Console.WriteLine("     3. Finish Updating Badge");
                    string menuSelect = Console.ReadLine();
                    switch (menuSelect)
                    {
                        case "1":
                            Console.WriteLine("Which door would you like to remove?");
                            string doorToRemove = Console.ReadLine();
                            doorsOnBadge.Remove(doorToRemove);
                            badgeToUpdate.Doors = doorsOnBadge;
                            Console.WriteLine("Door Removed");
                            doorsResult = string.Join(",", badgeToUpdate.Doors);
                            Console.WriteLine($"Badge #{badgeToUpdate.BadgeID} has access to doors: {doorsResult}.");
                            Console.WriteLine("Press any key to continue.");
                            Console.ReadKey();
                            break;
                        case "2":
                            Console.WriteLine("Which door would you like to add?");
                            string doorToAdd = Console.ReadLine();
                            doorsOnBadge.Add(doorToAdd);
                            badgeToUpdate.Doors = doorsOnBadge;
                            Console.WriteLine("Door Added");
                            doorsResult = string.Join(",", badgeToUpdate.Doors);
                            Console.WriteLine($"Badge #{badgeToUpdate.BadgeID} has access to doors: {doorsResult}.");
                            Console.WriteLine("Press any key to continue.");
                            Console.ReadKey();
                            break;
                        case "3":
                            looper = false;
                            break;
                    }

                }
                bool wasUpdate = _listOfBadges.UpdateExistingBadge(badgeNumber, badgeToUpdate);
                if (wasUpdate == true)
                {
                    Console.WriteLine("Badge updated successfully");
                }
                else
                {
                    Console.WriteLine("Sorry! Something went wrong.  Please try to update again.");
                }
            }
            else
            {
                Console.WriteLine("Sorry. Badge ID not found.");

            }
            Console.WriteLine("Press any key to return to the main menu");
            Console.ReadKey();
        }

        // Delete existing items
        private void DeleteExistingAccessOnBadges()
        {
            Console.Clear();
            Console.WriteLine("=-=-=-=- Delete All Doors From Badge -=-=-=-=");
            Console.WriteLine("What is the badge number you would like to update:");
            int badgeNumber = Convert.ToInt32(Console.ReadLine());
            BadgeListPoco badgeToUpdate = _listOfBadges.GetABadgeByID(badgeNumber);
            List<string> doorsOnBadge = new List<string>();
            if (badgeToUpdate != null)
            {
                string doorsResult = string.Join(",", badgeToUpdate.Doors);
                Console.WriteLine($"Badge #{badgeToUpdate.BadgeID} has access to doors: {doorsResult}.");
                Console.WriteLine($"Do you want to clear all doors from Badge #{badgeToUpdate.BadgeID}? (y/n)");
                string deleteAll = Console.ReadLine();
                if (deleteAll.ToLower() == "y")
                {
                    badgeToUpdate.Doors.Clear();
                    bool wasUpdate = _listOfBadges.UpdateExistingBadge(badgeNumber, badgeToUpdate);
                    if (wasUpdate == true)
                    {
                        Console.WriteLine($"All Doors Deleted from Badge #{badgeNumber}");
                    }
                    else
                    {
                        Console.WriteLine("Sorry! Something went wrong.  Please try update again.");
                    }

                }
                else
                {
                    Console.WriteLine("Cancel confirmed.");
                }
            }
            else
            {
                Console.WriteLine("Sorry, badge ID could not be found.");

            }
            Console.WriteLine("Press any key to return to the main menu");
            Console.ReadKey();
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


