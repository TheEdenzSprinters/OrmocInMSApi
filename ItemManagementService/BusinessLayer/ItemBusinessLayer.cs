using IMSRepository;
using IMSRepository.Models;
using IMSRepository.Utilities;
using ItemManagementService.Interfaces;
using ItemManagementService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ItemManagementService.BusinessLayer
{
    public class ItemBusinessLayer : IItemBusinessLayer
    {
        readonly IItemDataAccess _itemDataAccess;

        public ItemBusinessLayer(IItemDataAccess itemDataAccess)
        {
            _itemDataAccess = itemDataAccess;
        }

        public ItemSingleModel GetItemById(int id)
        {
            ItemSingleModel result = new ItemSingleModel();

            var query = _itemDataAccess.GetItemById(id);

            result.Id = query.Id;
            result.ItemName = query.ItemName;
            result.CategoryName = query.Category.CategoryName;
            result.SubCategoryName = query.SubCategory.SubCategoryName;
            result.BrandName = query.Brand.BrandName;
            result.LocationName = query.Location.LocationName;
            result.Quantity = query.Quantity.Value;
            result.MeasuredBy = query.MeasuredBy;
            result.Sku = query.Sku;
            result.Notes = query.Notes;
            result.IsActive = query.IsActive;
            result.CreateUserName = query.CreateUserName;
            result.CreateDttm = query.CreateDttm;
            result.UpdateUserName = query.UpdateUserName;
            result.UpdateDttm = query.UpdateDttm;

            return result;
        }

        public List<ItemSearchResultModel> ItemAdvancedSearch(ItemSearchQueryModel item)
        {
            ItemSearchResultModel singleItem = new ItemSearchResultModel();
            List<ItemSearchResultModel> result = new List<ItemSearchResultModel>();
            ItemSearchModel searchTerm = new ItemSearchModel();

            searchTerm.ModuleName = "items";
            searchTerm.Id = item.Id;
            searchTerm.ItemName = item.ItemName;
            searchTerm.Brand = item.Brand;
            searchTerm.CategoryId = item.CategoryId;
            searchTerm.SubCategoryId = item.SubCategoryId;
            searchTerm.Location = item.Location;
            searchTerm.Tag = item.Tag;
            searchTerm.Sku = item.Sku;

            var query = _itemDataAccess.AdvancedSearchItems(searchTerm);

            for(int i = 0; i < query.Count; i++)
            {
                singleItem.Id = query[i].Id;
                singleItem.ItemName = query[i].ItemName;
                singleItem.Brand = query[i].Brand;
                singleItem.Status = query[i].Status;
                singleItem.CreateDttm = query[i].CreateDttm;

                result.Add(singleItem);
                singleItem = new ItemSearchResultModel();
            }

            return result;
        }

        public List<string> ItemAutoComplete(string word)
        {
            var result = _itemDataAccess.ItemAutoComplete(word);
            return result;
        }
    }
}