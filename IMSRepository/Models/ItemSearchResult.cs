using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMSRepository.Models
{
    public class ItemSearchResult
    {
        public int Id { get; set; }
        public string ItemName { get; set; }
        public string Brand { get; set; }
        public DateTime CreateDttm { get; set; }
        public string Status { get; set; }
    }
}
