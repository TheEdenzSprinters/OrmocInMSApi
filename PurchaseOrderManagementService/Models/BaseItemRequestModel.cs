using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PurchaseOrderManagementService.Models
{
    public abstract class BaseItemRequestModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int StatusCd { get; set; }
        public string Notes { get; set; }
        public DateTime FollowupDttm { get; set; }
        public DateTime DateCreated { get; set; }
    }
}