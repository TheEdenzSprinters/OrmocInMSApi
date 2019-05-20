using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PurchaseOrderManagementService.Models
{
    public class ItemRequestDelinquentResultModel : ItemRequestSearchResultModel
    {
        public string TicketStatus { get; set; }
    }
}