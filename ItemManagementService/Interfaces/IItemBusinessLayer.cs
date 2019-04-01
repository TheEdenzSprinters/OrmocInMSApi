using IMSRepository.Models;
using ItemManagementService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItemManagementService.Interfaces
{
    public interface IItemBusinessLayer
    {
        ItemSingleModel GetItemById(int id);
        List<ItemSearchResultModel> ItemAdvancedSearch(ItemSearchQueryModel item);
        List<string> ItemAutoComplete(string word);
    }
}
