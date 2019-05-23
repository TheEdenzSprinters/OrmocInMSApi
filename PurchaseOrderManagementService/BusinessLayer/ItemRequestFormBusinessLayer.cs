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
            result.StatusCd = query.StatusCd;
            result.Notes = query.Notes;

            for (int i = 0; i < query.Quotations.Count; i++)
            {
                singleQuote.Id = query.Quotations.ToList()[i].Id;
                singleQuote.Status = ticketStatus.CodeDetails.Where(x => x.Id == query.Quotations.ToList()[i].StatusCd)
                                     .Select(x => x.CodeValue).FirstOrDefault();
                singleQuote.Notes = query.Quotations.ToList()[i].Notes;
                singleQuote.Title = query.Quotations.ToList()[i].Title;
                singleQuote.SupplierName = query.Quotations.ToList()[i].Supplier.SupplierName;

                result.RequestFormQuotations.Add(singleQuote);
                singleQuote = new QuotationList();
            }

            for (int i = 0; i < query.ItemRequestFormMappings.Count; i++)
            {
                singleItem.Id = query.ItemRequestFormMappings.ToList()[i].ItemID;
                singleItem.ItemName = query.ItemRequestFormMappings.ToList()[i].Item.ItemName;
                singleItem.StocksLeft = query.ItemRequestFormMappings.ToList()[i].Item.Quantity.Value;
                singleItem.BrandName = query.ItemRequestFormMappings.ToList()[i].Item.Brand.BrandName;
                singleItem.Notes = query.ItemRequestFormMappings.ToList()[i].Item.Notes;

                result.RequestFormItems.Add(singleItem);
                singleItem = new ItemList();
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

            for (int i = 0; i < items.Count; i++)
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

        public List<ItemRequestDelinquentResultModel> GetItemRequestFormDelinquents()
        {
            ItemRequestFormSearchQueryModel query = new ItemRequestFormSearchQueryModel();
            ItemRequestDelinquentQueryModel delinquentQuery = new ItemRequestDelinquentQueryModel();
            ItemRequestDelinquentResultModel singleItem = new ItemRequestDelinquentResultModel();
            List<ItemRequestDelinquentResultModel> result = new List<ItemRequestDelinquentResultModel>();

            var followupDays = _itemRequestFormDataAccess.GetAllFollowupDetails().CodeDetails.ToList();

            DateTime FirstFollowup = DateTime.Now.AddDays(-(Int32.Parse(followupDays.Where(x => x.CodeDesc.Contains("First follow-up")).FirstOrDefault().CodeValue)));
            DateTime SecondFollowup = DateTime.Now.AddDays(-(Int32.Parse(followupDays.Where(x => x.CodeDesc.Contains("Second follow-up")).FirstOrDefault().CodeValue)));
            DateTime ThirdFollowup = DateTime.Now.AddDays(-(Int32.Parse(followupDays.Where(x => x.CodeDesc.Contains("Third follow-up")).FirstOrDefault().CodeValue)));

            delinquentQuery.ModuleNm = "itemrequestdelinquents";
            delinquentQuery.FirstFollowupDate = FirstFollowup;
            delinquentQuery.SecondFollowupDate = SecondFollowup;
            delinquentQuery.ThirdFollowupDate = ThirdFollowup;

            var items = _itemRequestFormDataAccess.GetItemRequestFormDelinquents(delinquentQuery).OrderBy(x => x.Status).ToList();

            for (int i = 0; i < items.Count; i++)
            {
                singleItem.Id = items[i].Id;
                singleItem.Title = items[i].Title;
                singleItem.DateCreated = items[i].DateCreated;
                singleItem.Status = items[i].Status;

                switch (items[i].TicketStatus.ToLower())
                {
                    case "other":
                        singleItem.TicketStatus = "Incomplete ticket";
                        break;
                    case "first":
                        singleItem.TicketStatus = "First follow-up";
                        break;
                    case "second":
                        singleItem.TicketStatus = "Second follow-up";
                        break;
                    case "third":
                        singleItem.TicketStatus = "Third follow-up";
                        break;
                    default:
                        singleItem.TicketStatus = "";
                        break;
                }

                result.Add(singleItem);
                singleItem = new ItemRequestDelinquentResultModel();
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
            newItemRequest.Notes = itemRequest.Notes;
            newItemRequest.FollowupStartDttm = DateTime.UtcNow;
            newItemRequest.CreateUserName = "ADMIN";
            newItemRequest.CreateDttm = DateTime.UtcNow;
            newItemRequest.UpdateUserName = "ADMIN";
            newItemRequest.UpdateDttm = DateTime.UtcNow;

            var insertedItem = _itemRequestFormDataAccess.InsertNewItemRequest(newItemRequest);

            result.Id = insertedItem.Id;
            result.Title = insertedItem.Title;
            result.Notes = insertedItem.Notes;
            result.DateCreated = insertedItem.CreateDttm;
            result.StatusCd = insertedItem.StatusCd;
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
            query.FollowupStartDttm = DateTime.UtcNow;

            var result = _itemRequestFormDataAccess.UpdateItemRequestById(query);

            return result;
        }

        public StandardRequestResultModel ValidateStatusChangeItemRequest(UpdateItemRequestModel itemRequest)
        {
            StandardRequestResultModel result = new StandardRequestResultModel();

            var selectedCodeDetail = _itemRequestFormDataAccess.GetAllTicketStatus()
                                        .CodeDetails.Where(x => x.Id == itemRequest.StatusCd)
                                        .Select(x => x.CodeValue).FirstOrDefault();

            var quotationSentCd = _itemRequestFormDataAccess.GetAllTicketStatus()
                                        .CodeDetails.Where(x => x.CodeValue.Equals("Quotations Sent"))
                                        .Select(x => x.Id).FirstOrDefault();

            var quotationCompleteCd = _itemRequestFormDataAccess.GetAllTicketStatus()
                                        .CodeDetails.Where(x => x.CodeValue.Equals("Completed"))
                                        .Select(x => x.Id).FirstOrDefault();

            var selectedItemRequest = _itemRequestFormDataAccess.GetItemRequestFormById(itemRequest.Id);

            switch (selectedCodeDetail)
            {
                case "Supervisor Review":
                    int quotationCount = selectedItemRequest.Quotations.Count;

                    if (quotationCount > 0)
                    {
                        result.isSuccess = true;
                    }
                    else
                    {
                        result.isSuccess = false;
                        result.Message = "Item Request does not have Quotations for review.";
                    }
                    break;
                case "Quotations Sent":
                    int quotesSent = selectedItemRequest.Quotations.Where(x => x.StatusCd == quotationSentCd).Count();

                    if (quotesSent > 0)
                    {
                        result.isSuccess = true;
                    }
                    else
                    {
                        result.isSuccess = false;
                        result.Message = "Item Request has Quotations not set to Quotations Sent status.";
                    }
                    break;
                case "Completed":
                    int quotesComplete = selectedItemRequest.Quotations.Where(x => x.StatusCd == quotationCompleteCd).Count();

                    if (quotesComplete > 0)
                    {
                        result.isSuccess = true;
                    }
                    else
                    {
                        result.isSuccess = false;
                        result.Message = "Item Request has Quotations not set to Completed status.";
                    }
                    break;
                default:
                    result.isSuccess = false;
                    result.Message = "Unknown ticket status.";
                    break;
            }

            return result;
        }

        public List<ItemRequestStatusModel> GetItemRequestTicketSatus()
        {
            ItemRequestStatusModel singleItem = new ItemRequestStatusModel();
            List<ItemRequestStatusModel> result = new List<ItemRequestStatusModel>();

            var query = _itemRequestFormDataAccess.GetAllTicketStatus();

            for (int i = 0; i < query.CodeDetails.Count; i++)
            {
                singleItem.Id = query.CodeDetails.ToList()[i].Id;
                singleItem.Status = query.CodeDetails.ToList()[i].CodeValue;

                result.Add(singleItem);
                singleItem = new ItemRequestStatusModel();
            }

            return result;
        }

        public StandardRequestResultModel AttachItemToItemRequest(ItemToItemRequestModel item)
        {
            var checkQuery = _itemRequestFormDataAccess.ValidateIfMappingExists(item.ItemId, item.ItemRequestId);
            StandardRequestResultModel result = new StandardRequestResultModel();

            if (checkQuery != null)
            {
                result.isSuccess = false;
                result.Message = "Item already exists in Item Request.";

                return result;
            }

            else
            {
                ItemRequestFormMapping query = new ItemRequestFormMapping();

                query.ItemID = item.ItemId;
                query.IRFID = item.ItemRequestId;
                query.CreateUserName = "ADMIN";
                query.CreateDttm = DateTime.UtcNow;
                query.UpdateUserName = "ADMIN";
                query.UpdateDttm = DateTime.UtcNow;

                var addQuery = _itemRequestFormDataAccess.AttachItemToItemRequest(query);


                if (addQuery)
                {
                    result.isSuccess = true;
                    result.Message = "Item added to Item Request.";
                }
                else
                {
                    result.isSuccess = false;
                    result.Message = "Error while adding Item to Item Request.";
                }
                return result;
            }
        }

        public StandardRequestResultModel DeleteItemFromItemRequest(ItemToItemRequestModel item)
        {
            var checkQuery = _itemRequestFormDataAccess.ValidateIfMappingExists(item.ItemId, item.ItemRequestId);
            StandardRequestResultModel result = new StandardRequestResultModel();

            if (checkQuery == null)
            {
                result.isSuccess = false;
                result.Message = "Item does not exist in Item Request.";

                return result;
            }
            else
            {
                var deleteQuery = _itemRequestFormDataAccess.DeleteItemFromItemRequest(checkQuery.Id);

                if (deleteQuery)
                {
                    result.isSuccess = true;
                    result.Message = "Item successfully removed from Item Request.";
                }
                else
                {
                    result.isSuccess = false;
                    result.Message = "Error occured while removing Item from Item Request.";
                }

                return result;
            }
        }
    }
}