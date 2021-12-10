using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoCafe
{
    class KC_TestableRepo
    {
        public readonly List<KC_Poco> _menuRepo = new List<KC_Poco>();

        // Create: Program file that allows the cafe manager to ADD items in the Menu List
        public void AddItemsToMenu(KC_Poco items)
        {
            _menuRepo.Add(items);
        }

        // Read: SEE all items in the menu list
        public List<KC_Poco> GetCafeItems()
        {
            return _menuRepo;
        }

        // Update - Not needed in this case


        // Delete: DELETE menu items 
        public bool RemoveItemFromList(int number)
        {
            List<KC_Poco> _menuRepo = GetCafeItems();
            foreach (KC_Poco item in _menuRepo)
            {
                if (item.Number == number)
                {
                    _menuRepo.Remove(item);
                    return true;
                }
                else
                {
                    _menuRepo.Remove(item);
                    return false;
                }
            }
            return RemoveItemFromList(number);
        }
    }
}

