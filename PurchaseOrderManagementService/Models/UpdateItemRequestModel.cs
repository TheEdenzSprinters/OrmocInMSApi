using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PurchaseOrderManagementService.Models
{
    public class UpdateItemRequestModel : BaseItemRequestModel
    {
        public string Notes { get; set; }
    }
}