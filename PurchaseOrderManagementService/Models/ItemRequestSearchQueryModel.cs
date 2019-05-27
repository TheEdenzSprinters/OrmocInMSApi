using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PurchaseOrderManagementService.Models
{
    public class ItemRequestSearchQueryModel
    {
        public int? Id { get; set; }
        public string Title { get; set; }
        public int? StatusCd { get; set; }
        public string DateFrom { get; set; }
        public string DateTo { get; set; }
        public int NextBatch { get; set; }
    }
}