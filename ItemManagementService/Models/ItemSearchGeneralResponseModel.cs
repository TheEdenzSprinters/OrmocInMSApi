using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ItemManagementService.Models
{
    public class ItemSearchGeneralResponseModel
    {
        public int RecordCount { get; set; }
        public List<ItemSearchResultModel> SearchResult { get; set; }
    }
}