using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ItemManagementService.Models
{
    public class ItemSearchQueryModel
    {
        public int? Id { get; set; }
        public string ItemName { get; set; }
        public string Brand { get; set; }
        public int? CategoryId { get; set; }
        public int? SubCategoryId { get; set; }
        public string Tag { get; set; }
        public string Sku { get; set; }
        public int? Location { get; set; }
        public int? StatusCd { get; set; }
        public int NextBatch { get; set; }
    }
}