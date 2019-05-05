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

        public int InsertNewItem(InsertItemModel item)
        {
            Item newItem = new Item();
            List<ItemDetailMapping> detail = new List<ItemDetailMapping>();
            ItemDetailMapping singleDetail = new ItemDetailMapping();

            newItem.ItemName = item.ItemName;
            newItem.CategoryID = item.CategoryId;
            newItem.SubCategoryID = item.SubCategoryId;
            newItem.StatusCd = item.StatusCd;
            newItem.LocationID = item.LocationId;
            newItem.BrandID = item.BrandId;
            newItem.Quantity = item.Quantity;
            newItem.MeasuredBy = item.MeasuredBy;
            newItem.ThresholdQty = item.ThresholdQty;
            newItem.Notes = item.Notes;
            newItem.Sku = item.Sku;
            newItem.CreateUserName = "ADMIN";
            newItem.CreateDttm = DateTime.UtcNow;
            newItem.UpdateUserName = "ADMIN";
            newItem.UpdateDttm = DateTime.UtcNow;

            var insertedItem = _itemDataAccess.InsertNewItem(newItem);

            if (insertedItem != null)
            {
                for (int i = 0; i < item.ItemDetail.Count; i++)
                {
                    singleDetail.ItemDetailID = item.ItemDetail[i].ItemDetailId;
                    singleDetail.ItemDetailValue = item.ItemDetail[i].ItemDetailValue;
                    singleDetail.ItemID = insertedItem.Id;
                    singleDetail.IsActive = true;
                    singleDetail.CreateUserName = "ADMIN";
                    singleDetail.CreateDttm = DateTime.UtcNow;
                    singleDetail.UpdateUserName = "ADMIN";
                    singleDetail.UpdateDttm = DateTime.Now;

                    detail.Add(singleDetail);

                    singleDetail = new ItemDetailMapping();
                }

                var insertedDetail = _itemDataAccess.InsertNewItemDetailMapping(detail);

                if (insertedDetail)
                {
                    return insertedItem.Id;
                }
            }
            return 0;
        }

        public ItemSingleModel GetItemById(int id)
        {
            ItemSingleModel result = new ItemSingleModel();
            ItemDetailModel singleItemDetail = new ItemDetailModel();
            List<ItemDetailModel> completeItemDetail = new List<ItemDetailModel>();

            var query = _itemDataAccess.GetItemById(id);
            var itemDetailQuery = _itemDataAccess.GetItemDetailByItemId(query.Id);
            var uom = _itemDataAccess.GetItemUnitsOfMeasure(itemDetailQuery);

            result.Id = query.Id;
            result.ItemName = query.ItemName;
            result.CategoryId = query.CategoryID;
            result.SubCategoryId = query.SubCategoryID;
            result.BrandId = query.BrandID;
            result.LocationId = query.LocationID;
            result.Quantity = query.Quantity.HasValue ? query.Quantity.Value : 0;
            result.ThresholdQty = query.ThresholdQty.HasValue ? query.ThresholdQty.Value : 0;
            result.MeasuredBy = query.MeasuredBy;
            result.Sku = query.Sku;
            result.Notes = query.Notes;
            result.StatusCd = query.StatusCd;
            result.CreateUserName = query.CreateUserName;
            result.CreateDttm = query.CreateDttm;
            result.UpdateUserName = query.UpdateUserName;
            result.UpdateDttm = query.UpdateDttm;

            for (int i = 0; i < itemDetailQuery.Count; i++)
            {
                singleItemDetail.ItemDetailId = itemDetailQuery[i].ItemDetail.Id;
                singleItemDetail.ShowUnitsOfMeasure = itemDetailQuery[i].ItemDetail.ShowUnitsOfMeasure;
                singleItemDetail.ItemDetailName = itemDetailQuery[i].ItemDetail.ItemDetailName;
                singleItemDetail.ItemDetailValue = itemDetailQuery[i].ItemDetailValue;
                singleItemDetail.UnitOfMeasure = uom.Where(x => x.Id == itemDetailQuery[i].ItemDetail.UnitsOfMeasureID)
                                                .Select(x => x.UnitOfMeasure).FirstOrDefault();

                completeItemDetail.Add(singleItemDetail);
                singleItemDetail = new ItemDetailModel();
            }

            result.ItemDetail = completeItemDetail;

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
            searchTerm.StatusCd = item.StatusCd;

            var query = _itemDataAccess.AdvancedSearchItems(searchTerm);
            var codeDetail = _itemDataAccess.GetAllItemStatus();

            for (int i = 0; i < query.Count; i++)
            {
                singleItem.Id = query[i].Id;
                singleItem.ItemName = query[i].ItemName;
                singleItem.Brand = query[i].Brand;
                singleItem.Status = codeDetail.Where(x => x.Id == query[i].Status).Select(x => x.CodeValue).FirstOrDefault();
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

        public List<LocationModel> GetAllLocations()
        {
            LocationModel lineItem = new LocationModel();
            List<LocationModel> result = new List<LocationModel>();

            var query = _itemDataAccess.GetAllLocations();

            for (int i = 0; i < query.Count; i++)
            {
                lineItem.Id = query[i].Id;
                lineItem.LocationName = query[i].LocationName;

                result.Add(lineItem);
                lineItem = new LocationModel();
            }

            return result;
        }

        public List<ItemStatus> GetAllItemStatus()
        {
            ItemStatus lineItem = new ItemStatus();
            List<ItemStatus> result = new List<ItemStatus>();

            var query = _itemDataAccess.GetAllItemStatus();

            for (var i = 0; i < query.Count; i++)
            {
                lineItem.Id = query[i].Id;
                lineItem.Status = query[i].CodeValue;

                result.Add(lineItem);
                lineItem = new ItemStatus();
            }

            return result;
        }

        public List<ItemDetailModel> GetItemDetailBySubCategoryId(int Id)
        {
            ItemDetailModel singleItem = new ItemDetailModel();
            List<ItemDetailModel> result = new List<ItemDetailModel>();

            var query = _itemDataAccess.GetItemDetailBySubCategoryId(Id);

            for (int i = 0; i < query.Count; i++)
            {
                singleItem.ItemDetailId = query[i].Id;
                singleItem.ItemDetailName = query[i].ItemDetailName;
                singleItem.ShowUnitsOfMeasure = query[i].ShowUnitsOfMeasure;
                singleItem.UnitOfMeasure = query[i].UnitsOfMeasure.UnitOfMeasure;

                result.Add(singleItem);
                singleItem = new ItemDetailModel();
            }

            return result;
        }

        public string UpdateItemStatusById(UpdateItemStatusModel status)
        {
            bool isUpdated = _itemDataAccess.UpdateItemStatusById(status.Id, status.StatusCd);

            return isUpdated ? "Item status updated." : "Error updating item status.";
        }

        public List<TagsModel> TagsAutoComplete(string word)
        {
            List<TagsModel> result = new List<TagsModel>();
            TagsModel singleTag = new TagsModel();

            var query = _itemDataAccess.TagsAutoComplete(word);

            for (int i = 0; i < query.Count; i++)
            {
                singleTag.Id = query[i].Id;
                singleTag.TagValue = query[i].TagValue;

                result.Add(singleTag);
                singleTag = new TagsModel();
            }

            return result;
        }

        public TagsModel AddNewTagToItem(TagsMappingModel tag)
        {
            Tag input = new Tag();
            TagsModel result = new TagsModel();

            input.Id = tag.Id;
            input.TagValue = tag.TagValue;

            var checkNewTag = _itemDataAccess.AddNewTag(input);

            if(checkNewTag != 0)
            {
                var addNewMapping = _itemDataAccess.AddTaggingByItemId(checkNewTag, tag.ItemId);

                if (addNewMapping)
                {
                    result.Id = checkNewTag;
                    result.TagValue = input.TagValue;

                    return result;
                }
            }
            return null;
        }

        public List<ItemSearchResultModel> ItemBySimpleSearch(ItemSimpleSearchModel item)
        {
            ItemSearchResultModel singleItem = new ItemSearchResultModel();
            List<ItemSearchResultModel> result = new List<ItemSearchResultModel>();

            var query = _itemDataAccess.SimpleSearchItems(item.ItemName);
            var codeDetail = _itemDataAccess.GetAllItemStatus();

            for (int i = 0; i < query.Count; i++)
            {
                singleItem.Id = query[i].Id;
                singleItem.ItemName = query[i].ItemName;
                singleItem.Brand = query[i].Brand;
                singleItem.Status = codeDetail.Where(x => x.Id == query[i].Status).Select(x => x.CodeValue).FirstOrDefault();
                singleItem.CreateDttm = query[i].CreateDttm;

                result.Add(singleItem);
                singleItem = new ItemSearchResultModel();
            }

            return result;
        }
    }
}