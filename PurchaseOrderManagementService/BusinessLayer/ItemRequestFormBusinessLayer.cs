using IMSRepository;
using IMSRepository.Models;
using IMSRepository.Utilities;
using PurchaseOrderManagementService.Interfaces;
using PurchaseOrderManagementService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PurchaseOrderManagementService.BusinessLayer
{
    public class ItemRequestFormBusinessLayer : IItemRequestFormBusinessLayer
    {
        readonly IItemRequestFormDataAccess _itemRequestFormDataAccess;

        public ItemRequestFormBusinessLayer(IItemRequestFormDataAccess itemRequestFormDataAccess)
        {
            _itemRequestFormDataAccess = itemRequestFormDataAccess;
        }

        public ItemRequestFormModel GetItemRequestFormById(int id)
        {
            ItemRequestFormModel result = new ItemRequestFormModel();
            result.RequestFormItems = new List<ItemList>();
            result.RequestFormQuotations = new List<QuotationList>();
            QuotationList singleQuote = new QuotationList();
            CodeHeader ticketStatus = new CodeHeader();
            ItemList singleItem = new ItemList();
            
            var query = _itemRequestFormDataAccess.GetItemRequestFormById(id);

            result.Id = query.Id;
            result.Title = query.Title;
            result.DateCreated = query.CreateDttm;
            result.FollowupDttm = query.FollowupStartDttm.Value;
            result.Notes = query.Notes;

            for(int i = 0; i < query.Quotations.Count; i++)
            {
                singleQuote.Id = query.Quotations.ToList()[i].Id;
                singleQuote.Status = ticketStatus.CodeDetails.Where(x => x.Id == query.Quotations.ToList()[i].StatusCd)
                                     .Select(x => x.CodeValue).FirstOrDefault();
                singleQuote.Notes = query.Quotations.ToList()[i].Notes;
                singleQuote.Title = query.Quotations.ToList()[i].Title;
                singleQuote.SupplierName = query.Quotations.ToList()[i].Supplier.SupplierName;

                result.RequestFormQuotations.Add(singleQuote);
            }

            for(int i = 0; i < query.ItemRequestFormMappings.Count; i++)
            {
                singleItem.Id = query.ItemRequestFormMappings.ToList()[i].ItemID;
                singleItem.ItemName = query.ItemRequestFormMappings.ToList()[i].Item.ItemName;
                singleItem.StocksLeft = query.ItemRequestFormMappings.ToList()[i].Item.Quantity.Value;
                singleItem.BrandName = query.ItemRequestFormMappings.ToList()[i].Item.Brand.BrandName;
                singleItem.Notes = query.ItemRequestFormMappings.ToList()[i].Item.Notes;

                result.RequestFormItems.Add(singleItem);
            }

            return result;
        }

        public List<ItemRequestSearchResultModel> ItemRequestFormSearch(ItemRequestSearchQueryModel itemRequestForm)
        {
            ItemRequestFormSearchQueryModel query = new ItemRequestFormSearchQueryModel();
            ItemRequestSearchResultModel singleResult = new ItemRequestSearchResultModel();
            List<ItemRequestSearchResultModel> result = new List<ItemRequestSearchResultModel>();

            query.ModuleNm = "itemrequestformsearch";
            query.Id = itemRequestForm.Id;
            query.Title = itemRequestForm.Title;
            query.DateCreated = itemRequestForm.DateFrom;
            query.DateTo = itemRequestForm.DateTo;

            var items = _itemRequestFormDataAccess.GetItemRequestFormSearchResults(query);

            for(int i = 0; i < items.Count; i++)
            {
                singleResult.Id = items[i].Id;
                singleResult.Title = items[i].Title;
                singleResult.Status = items[i].Status;
                singleResult.DateCreated = items[i].DateCreated;

                result.Add(singleResult);
                singleResult = new ItemRequestSearchResultModel();
            }

            return result;
        }

        public List<ItemRequestSearchResultModel> GetItemRequestFormDelinquents()
        {
            ItemRequestFormSearchQueryModel query = new ItemRequestFormSearchQueryModel();
            ItemRequestDelinquentQueryModel delinquentQuery = new ItemRequestDelinquentQueryModel();
            ItemRequestSearchResultModel singleItem = new ItemRequestSearchResultModel();
            List<ItemRequestSearchResultModel> result = new List<ItemRequestSearchResultModel>();

            var followupDays = _itemRequestFormDataAccess.GetAllFollowupDetails().CodeDetails.ToList();

            DateTime FirstFollowup = DateTime.Now.AddDays(-(Int32.Parse(followupDays.Where(x => x.CodeDesc.Contains("First follow-up")).FirstOrDefault().CodeValue)));
            DateTime SecondFollowup = DateTime.Now.AddDays(-(Int32.Parse(followupDays.Where(x => x.CodeDesc.Contains("Second follow-up")).FirstOrDefault().CodeValue)));
            DateTime ThirdFollowup = DateTime.Now.AddDays(-(Int32.Parse(followupDays.Where(x => x.CodeDesc.Contains("Third follow-up")).FirstOrDefault().CodeValue)));

            delinquentQuery.ModuleNm = "itemrequestdelinquents";
            delinquentQuery.FirstFollowupDate = FirstFollowup;
            delinquentQuery.SecondFollowupDate = SecondFollowup;
            delinquentQuery.ThirdFollowupDate = ThirdFollowup;

            var items = _itemRequestFormDataAccess.GetItemRequestFormDelinquents(delinquentQuery);

            for (int i = 0; i < items.Count; i++)
            {
                singleItem.Id = items[i].Id;
                singleItem.Title = items[i].Title;
                singleItem.DateCreated = items[i].DateCreated;

                result.Add(singleItem);
                singleItem = new ItemRequestSearchResultModel();
            }

            return result;
        }

        public ItemRequestFormModel InsertNewItemRequest(InsertItemRequestModel itemRequest)
        {
            ItemRequestForm newItemRequest = new ItemRequestForm();
            ItemRequestFormModel result = new ItemRequestFormModel();
            var ticketStatusQuery = _itemRequestFormDataAccess.GetAllTicketStatus();

            int ticketStatusNew = ticketStatusQuery.CodeDetails.Where(x => x.CodeValue.Contains("New"))
                                    .Select(x => x.Id).FirstOrDefault();

            newItemRequest.Title = itemRequest.Title;
            newItemRequest.StatusCd = ticketStatusNew;
            newItemRequest.IsActive = true;
            newItemRequest.CreateUserName = "ADMIN";
            newItemRequest.CreateDttm = DateTime.UtcNow;
            newItemRequest.UpdateUserName = "ADMIN";
            newItemRequest.UpdateDttm = DateTime.UtcNow;

            var insertedItem = _itemRequestFormDataAccess.InsertNewItemRequest(newItemRequest);

            result.Id = insertedItem.Id;
            result.Title = insertedItem.Title;
            result.Notes = insertedItem.Notes;
            result.DateCreated = insertedItem.CreateDttm;
            result.RequestFormItems = new List<ItemList>();
            result.RequestFormQuotations = new List<QuotationList>();

            return result;
        }

        public bool UpdateItemRequestById(UpdateItemRequestModel itemRequest)
        {
            ItemRequestForm query = new ItemRequestForm();

            query.Id = itemRequest.Id;
            query.Title = itemRequest.Title;
            query.Notes = itemRequest.Notes;
            query.UpdateDttm = DateTime.UtcNow;
            query.UpdateUserName = "ADMIN";

            var result = _itemRequestFormDataAccess.UpdateItemRequestById(query);

            return result;
        }
    }
}