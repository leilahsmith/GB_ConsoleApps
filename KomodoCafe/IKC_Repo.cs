using System.Collections.Generic;

namespace KomodoCafe
{
    public interface IKC_Repo
    {
        bool AddItemsToMenu(KC_Poco items);
        List<KC_Poco> GetCafeItems();
        KC_Poco GetCafeItemsByItemNumber(int itemNum);
        bool RemoveItemFromList(KC_Poco item);
        bool UpdateExistingCafeItem(int oldItemNum, KC_Poco newItem);
    }
}