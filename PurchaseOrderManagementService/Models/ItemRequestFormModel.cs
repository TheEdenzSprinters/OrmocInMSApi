using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PurchaseOrderManagementService.Models
{
    public class ItemRequestFormModel : BaseItemRequestModel
    {
        public DateTime FollowupDttm { get; set; }
        public DateTime DateCreated { get; set; }
        public List<ItemList> RequestFormItems { get; set; }
        public List<QuotationList> RequestFormQuotations { get; set; }
        public List<PriceScoreSheet> RequestFormPriceScoreSheet { get; set; }
    }

    public class ItemList
    {
        public int Id { get; set; }
        public string ItemName { get; set; }
        public string BrandName { get; set; }
        public int StocksLeft { get; set; }
        public string Notes { get; set; }
    }

    public class QuotationList
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Status { get; set; }
        public string SupplierName { get; set; }
        public string Notes { get; set; }
        public DateTime FollowupDttm { get; set; }
    }

    public class PriceScoreSheet
    {
        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public int SupplierId { get; set; }
        public string SupplierName { get; set; }
        public int QuantityOrdered { get; set; }
        public int SupplierPrice { get; set; }
        public string PaymentTerms { get; set; }
    }
}