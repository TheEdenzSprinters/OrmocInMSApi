using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ItemManagementService.Models
{
    public class ItemSearchResultModel
    {
        public int Id { get; set; }
        public string ItemName { get; set; }
        public string Brand { get; set; }
        public DateTime CreateDttm { get; set; }
        public string Status { get; set; }
        public string LocationName { get; set; }
        public int StocksLeft { get; set; }
        public string Notes { get; set; }
    }
}