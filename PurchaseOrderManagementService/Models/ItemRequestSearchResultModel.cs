﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PurchaseOrderManagementService.Models
{
    public class ItemRequestSearchResultModel : BaseItemRequestModel
    {
        public string Status { get; set; }
        public DateTime DateCreated { get; set; }
    }
}