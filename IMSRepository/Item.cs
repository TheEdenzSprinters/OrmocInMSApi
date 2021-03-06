//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace IMSRepository
{
    using System;
    using System.Collections.Generic;
    
    public partial class Item
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Item()
        {
            this.ItemDetailMappings = new HashSet<ItemDetailMapping>();
            this.ItemRequestFormMappings = new HashSet<ItemRequestFormMapping>();
            this.PurchaseOrderMappings = new HashSet<PurchaseOrderMapping>();
            this.QuotationsMappings = new HashSet<QuotationsMapping>();
            this.TagsMappings = new HashSet<TagsMapping>();
        }
    
        public int Id { get; set; }
        public string ItemName { get; set; }
        public int CategoryID { get; set; }
        public int SubCategoryID { get; set; }
        public int LocationID { get; set; }
        public int BrandID { get; set; }
        public int StatusCd { get; set; }
        public Nullable<int> Quantity { get; set; }
        public Nullable<int> ThresholdQty { get; set; }
        public Nullable<int> WarningThresholdQty { get; set; }
        public string MeasuredBy { get; set; }
        public Nullable<decimal> UnitPrice { get; set; }
        public Nullable<decimal> RetailPrice { get; set; }
        public string Sku { get; set; }
        public string Notes { get; set; }
        public string CreateUserName { get; set; }
        public System.DateTime CreateDttm { get; set; }
        public string UpdateUserName { get; set; }
        public System.DateTime UpdateDttm { get; set; }
    
        public virtual Brand Brand { get; set; }
        public virtual Category Category { get; set; }
        public virtual CodeDetail CodeDetail { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ItemDetailMapping> ItemDetailMappings { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ItemRequestFormMapping> ItemRequestFormMappings { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PurchaseOrderMapping> PurchaseOrderMappings { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<QuotationsMapping> QuotationsMappings { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TagsMapping> TagsMappings { get; set; }
        public virtual Location Location { get; set; }
        public virtual SubCategory SubCategory { get; set; }
    }
}
