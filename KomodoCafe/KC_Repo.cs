using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoCafe
{
    class KC_Repo
    {
        private List<KC_Poco> _listOfItems = new List<KC_Poco>();

        // Create: Program file that allows the cafe manager to ADD items in the Menu List
        public void AddItemsToMenu(KC_Poco items)
        {
            _listOfItems.Add(items);
        }

        // Read: SEE all items in the menu list
        public List<KC_Poco> GetMenuItems()
        {
            return _listOfItems;
        }

        // Update - Not needed in this case


        // Delete: DELETE menu items 
        public bool RemoveItemFromList(int number)
        {
            List<KC_Poco> _listofItems = GetMenuItems();
            foreach (KC_Poco item in _listofItems)
            {
                if (item.Number == number)
                {
                    _listOfItems.Remove(item);
                    return true;
                }
                else
                {
                    _listOfItems.Remove(item);
                    return false;
                }
            }

            return RemoveItemFromList(number);


        }
    }
}
