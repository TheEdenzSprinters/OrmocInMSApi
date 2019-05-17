using PurchaseOrderManagementService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PurchaseOrderManagementService.Interfaces
{
    public interface IItemRequestFormBusinessLayer
    {
        ItemRequestFormModel GetItemRequestFormById(int id);
        List<ItemRequestSearchResultModel> ItemRequestFormSearch(ItemRequestSearchQueryModel itemRequestForm);
        List<ItemRequestSearchResultModel> GetItemRequestFormDelinquents();
        ItemRequestFormModel InsertNewItemRequest(InsertItemRequestModel itemRequest);
        bool UpdateItemRequestById(UpdateItemRequestModel itemRequest);
    }
}
