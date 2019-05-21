using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMSRepository.Models
{
    public class ItemRequestDelinquentQueryResultModel : ItemRequestFormSearchResultModel
    {
        public string TicketStatus { get; set; }
    }
}
