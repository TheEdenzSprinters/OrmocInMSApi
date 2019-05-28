using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PurchaseOrderManagementService.Models
{
    public class ItemRequestDelinquentSearchResponseModel
    {
        public int RecordCount { get; set; }
        public List<ItemRequestDelinquentResultModel> SearchResult { get; set; }
    }
}