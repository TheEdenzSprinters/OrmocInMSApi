using IMSRepository.Models;
using System.Collections.Generic;

namespace IMSRepository.Utilities
{
    public interface IItemRequestFormDataAccess
    {
        ItemRequestForm GetItemRequestFormById(int Id);
        ItemRequestSearchModel GetItemRequestFormSearchResults(ItemRequestFormSearchQueryModel query);
        CodeHeader GetAllFollowupDetails();
        List<ItemRequestDelinquentQueryResultModel> GetItemRequestFormDelinquents(ItemRequestDelinquentQueryModel query);
        CodeHeader GetAllTicketStatus();
        ItemRequestForm InsertNewItemRequest(ItemRequestForm itemRequest);
        bool UpdateItemRequestById(ItemRequestForm itemRequest);
        bool AttachItemToItemRequest(ItemRequestFormMapping item);
        ItemRequestFormMapping ValidateIfMappingExists(int itemId, int itemRequestId);
        bool DeleteItemFromItemRequest(int Id);
        bool CancelItemRequest(int Id);
        bool RejectItemRequest(int Id);
    }
}