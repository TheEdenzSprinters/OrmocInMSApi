using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ItemManagementService.Models
{
    public abstract class BaseItemModel
    {
        public string ItemName { get; set; }
        public int CategoryId { get; set; }
        public int SubCategoryId { get; set; }
        public int LocationId { get; set; }
        public string BrandName { get; set; }
        public string StatusCd { get; set; }
        public int Quantity { get; set; }
        public int ThresholdQty { get; set; }
        public int WarningThresholdQty { get; set; }
        public string MeasuredBy { get; set; }
        public string Sku { get; set; }
        public string Notes { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal RetailPrice { get; set; }
    }
}