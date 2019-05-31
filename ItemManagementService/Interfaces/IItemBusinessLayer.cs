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
        ItemSearchGeneralResponseModel ItemAdvancedSearch(ItemSearchQueryModel item);
        List<string> ItemAutoComplete(string word);
        List<LocationModel> GetAllLocations();
        List<ItemStatus> GetAllItemStatus();
        List<ItemDetailModel> GetItemDetailBySubCategoryId(int Id);
        ItemSingleModel InsertNewItem(InsertItemModel item);
        bool UpdateExistingItem(UpdateItemModel item);
        string UpdateItemStatusById(UpdateItemStatusModel status);
        List<TagsModel> TagsAutoComplete(string word);
        TagsModel AddNewTagToItem(TagsMappingModel tag);
        ItemSearchGeneralResponseModel ItemBySimpleSearch(ItemSimpleSearchModel item);
        List<ItemSingleModel> GetRedLevelItems();
        List<ItemSingleModel> GetAmberLevelItems();
        List<ItemSingleModel> GetOldestStocks();
    }
}
