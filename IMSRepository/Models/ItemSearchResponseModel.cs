using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMSRepository.Models
{
    public class ItemSearchResponseModel
    {
        public int RecordCount { get; set; }
        public List<ItemSearchResult> SearchResult { get; set; }
    }
}
