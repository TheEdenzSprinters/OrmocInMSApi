using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PurchaseOrderManagementService.Models
{
    public class ItemRequestSearchResponseModel
    {
        public int RecordCount { get; set; }
        public List<ItemRequestSearchResultModel> SearchResult { get; set; }
    }
}