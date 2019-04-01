using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ItemManagementService.Models
{
    public class ItemSingleModel
    {
        public int Id { get; set; }
        public string ItemName { get; set; }
        public string CategoryName { get; set; }
        public string SubCategoryName { get; set; }
        public string LocationName { get; set; }
        public string BrandName { get; set; }
        public bool IsActive { get; set; }
        public int Quantity { get; set; }
        public string MeasuredBy { get; set; }
        public string Sku { get; set; }
        public string Notes { get; set; }
        public string CreateUserName { get; set; }
        public DateTime CreateDttm { get; set; }
        public string UpdateUserName { get; set; }
        public DateTime UpdateDttm { get; set; }
    }
}