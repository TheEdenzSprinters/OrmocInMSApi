using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMSRepository.Models
{
    public class ItemRequestPullDelinquentsResponseModel
    {
        public int RecordCount { get; set; }
        public List<ItemRequestDelinquentQueryResultModel> SearchResult { get; set; }
    }
}
