using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PurchaseOrderManagementService.Models
{
    public class ItemToItemRequestModel
    {
        public int ItemId { get; set; }
        public int ItemRequestId { get; set; }
    }
}