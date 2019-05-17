using IMSRepository.Models;
using System.Collections.Generic;

namespace IMSRepository.Utilities
{
    public interface IItemRequestFormDataAccess
    {
        ItemRequestForm GetItemRequestFormById(int Id);
        List<ItemRequestFormSearchResultModel> GetItemRequestFormSearchResults(ItemRequestFormSearchQueryModel query);
        CodeHeader GetAllFollowupDetails();
        List<ItemRequestFormSearchResultModel> GetItemRequestFormDelinquents(ItemRequestDelinquentQueryModel query);
        CodeHeader GetAllTicketStatus();
        ItemRequestForm InsertNewItemRequest(ItemRequestForm itemRequest);
        bool UpdateItemRequestById(ItemRequestForm itemRequest);
    }
}