using System.Collections.Generic;
using IMSRepository.Models;

namespace IMSRepository.Utilities
{
    public interface IItemDataAccess
    {
        Item GetItemById(int id);
        List<ItemSearchResult> AdvancedSearchItems(ItemSearchModel item);
        List<string> ItemAutoComplete(string word);
    }
}