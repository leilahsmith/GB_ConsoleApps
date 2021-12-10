using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoCafe
{
    public class KC_Repo : IKC_Repo
    {
        private List<KC_Poco> _menuRepo = new List<KC_Poco>();


        // Create: Program file that allows the cafe manager to ADD items in the Menu List
        public bool AddItemsToMenu(KC_Poco items)
        {
            int startingCount = _menuRepo.Count;

            _menuRepo.Add(items);
            bool wasAdded = (_menuRepo.Count > startingCount) ? true : false;
            return wasAdded;
        }

        // Read: SEE all items in the menu list
        public List<KC_Poco> GetCafeItems()
        {
            return _menuRepo;
        }

        //  Get cafeItem by Item Number
        public KC_Poco GetCafeItemsByItemNumber(int itemNum)
        {
            foreach (KC_Poco cafeItem in _menuRepo)
            {
                if (cafeItem.Number == itemNum)
                {
                    return cafeItem;
                }
            }
            return null;
        }

        // Update - Not needed in this case
        public bool UpdateExistingCafeItem(int oldItemNum, KC_Poco newItem)
        {
            KC_Poco oldItem = GetCafeItemsByItemNumber(oldItemNum);

            if (oldItem != null)
            {
                oldItem.Number = newItem.Number;
                oldItem.Name = newItem.Name;
                oldItem.Description = newItem.Description;
                oldItem.Ingredients = newItem.Ingredients;
                oldItem.Price = newItem.Price;
                return true;
            }
            else { return false; }
        }

        // Delete: DELETE menu items 
        public bool RemoveItemFromList(KC_Poco item)
        {
            bool deleteItem = _menuRepo.Remove(item);
            return deleteItem;
        }
    }
}

