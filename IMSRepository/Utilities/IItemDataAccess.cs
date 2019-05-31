using System.Collections.Generic;
using IMSRepository.Models;

namespace IMSRepository.Utilities
{
    public interface IItemDataAccess
    {
        Item GetItemById(int id);
        ItemSearchResponseModel AdvancedSearchItems(ItemSearchModel item);
        List<string> ItemAutoComplete(string word);
        List<Location> GetAllLocations();
        List<CodeDetail> GetAllItemStatus();
        List<ItemDetailMapping> GetItemDetailByItemId(int itemId);
        List<UnitsOfMeasure> GetItemUnitsOfMeasure(List<ItemDetailMapping> item);
        List<ItemDetail> GetItemDetailBySubCategoryId(int id);
        Item InsertNewItem(Item item);
        bool InsertNewItemDetailMapping(List<ItemDetailMapping> itemDetail);
        bool UpdateItemStatusById(int id, string StatusCd);
        bool UpdateItemById(Item item);
        bool UpdateItemDetailMappingByItemId(ItemDetailMapping item);
        bool RemoveTaggingByItemId(int itemId, int tagId);
        int AddNewTag(Tag tag);
        bool AddTaggingByItemId(int tagId, int itemId);
        List<Tag> TagsAutoComplete(string word);
        ItemSearchResponseModel SimpleSearchItems(string itemName, int skip);
        Brand GetBrandByName(string brandName);
        List<Item> GetRedLevelItems();
        List<Item> GetAmberLevelItems();
        List<Item> GetOldestStocks();
    }
}