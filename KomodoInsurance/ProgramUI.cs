using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoInsurance
{
    public class ProgramUI
    {
        private ClaimRepo _claimRepo = new ClaimRepo();
        private bool isValid;

        public void Run()
        {
            // Seeds data into our app.
            SeedClaimQueue();

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
                    "1. Create New Claim\n" +
                    "2. See All Claims\n" +
                    "3. Settle Next Claim\n" +
                    "4. Exit");

                //Get user's input
                string input = Console.ReadLine();

                //Evaluate the user's input and act accordingly. 
                switch (input)
                {
                    case "1":
                        //Create New Items
                        CreateNewClaim();
                        break;
                    case "2":
                        //View all items
                        SeeAllClaims();
                        break;
                    case "3":
                        //Update Exisitng Items
                        SettleNextClaim();
                        break;
                    case "4":
                        //Exit
                        Console.WriteLine("Thank you, goodbye.");
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

        private void CreateNewClaim()
        {
            Console.Clear();

            //ClaimID
            Console.WriteLine("Enter the New Claim ID#:");
            int claimId = Int32.Parse(Console.ReadLine());

            //ClaimType
            Console.WriteLine("Enter a claim type (Ex: Car, Auto, Theft):");
            string claimType = Console.ReadLine();

            //Description
            Console.WriteLine("Enter a brief description for the new claim:");
            string description = Console.ReadLine();

            //ClaimAmount
            Console.WriteLine("Enter the amount of damages in the new claim: $");
            double claimAmt = double.Parse(Console.ReadLine());

            //DateOfIncident
            Console.WriteLine("Enter the date of the incident:");
            DateTime dateOfIncident = DateTime.Parse(Console.ReadLine());

            //DateOfClaim
            Console.WriteLine("Enter the date of the claim:");
            DateTime dateOfClaim = DateTime.Parse(Console.ReadLine());

            ClaimClass newClaim = new ClaimClass(claimId, claimType, description, claimAmt, dateOfIncident, dateOfClaim, isValid);

            _claimRepo.CreateNewClaim(newClaim);

            PressAnyKeyToReturnToMainMenu();
        }
        // View current claims items that are saved
        private void SeeAllClaims()
        {
            Console.Clear();
            Queue<ClaimClass> _QueueOfClaims = _claimRepo.SeeAllClaims();

            foreach (ClaimClass items in _QueueOfClaims)
            {
                Console.WriteLine($"{items.ClaimId}.\n" + $"{items.ClaimType}\n" + $"{items.Description}\n" + $"{items.ClaimAmt}\n" + $"{items.DateOfIncident}\n" + $"{items.DateOfClaim}\n" + $"{ items.IsValid}");
            }



        }
        //Update: Take Care of Next Claim.
        //Needs to be able to pull up the next claim in the repo to be taken care of.
        public bool SettleNextClaim()
        {
            Console.Clear();

            //Ask the user what claim they are settling.
            Console.WriteLine("Which claim would you like to settle? (Enter Claim ID #");
            int input = Int32.Parse(Console.ReadLine());



            //Print out the claims, they type the number they want
            Console.WriteLine("Would you like to deal with this claim now (y/n?)");
            string answer = Console.ReadLine().ToLower();

            if (answer == "y")
            {
                ClaimClass claim = _claimRepo.SettleNextClaim();
                Console.WriteLine($"{claim.ClaimId}.\n" + $"{claim.ClaimType}\n" + $"{claim.Description}\n" + $"{claim.ClaimAmt}\n" + $"{claim.DateOfIncident}\n" + $"{claim.DateOfClaim}\n" + $"{claim.IsValid}");
                return true;
            }
            else
            {
                PressAnyKeyToReturnToMainMenu();
                return false;
            }
        }





        /*Delete existing items
        private void DeleteExistingItems()
        {
            ViewAllClaims();
            // Get the item they want to remove
            Console.WriteLine("\nEnter the name of the item you'd like to remove:");
            int input = Int32.Parse(Console.ReadLine());
            // Call the delete method
            bool deleteConfirm = _menuRepo.SettleNextClaim(input);
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
        }*/
        public void PressAnyKeyToReturnToMainMenu()
        {
            Console.WriteLine("Press any key to return to Main Menu.");
            Console.ReadKey();
            RunMenu();
        }

        //Seed Method
        public void SeedClaimQueue()
        {
            ClaimClass claim1 = new ClaimClass(12345, "Car", "Car accident on 465.", 4575.00, new DateTime(18, 4, 25), new DateTime(18, 4, 27), true);
            ClaimClass claim2 = new ClaimClass(22345, "Home", "House fire in attic.", 9450.00, new DateTime(18, 4, 11), new DateTime(18, 4, 12), true);
            ClaimClass claim3 = new ClaimClass(32345, "Theft", "Stolen catalytic converter", 850.00, new DateTime(18, 4, 27), new DateTime(18, 6, 01), false);

        }
    }
}

