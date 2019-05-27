using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMSRepository.Models
{
    public class ItemRequestSearchModel
    {
        public int RecordCount { get; set; }
        public List<ItemRequestFormSearchResultModel> SearchResult { get; set; }
    }
}
