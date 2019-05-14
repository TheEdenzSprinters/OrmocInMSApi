using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMSRepository.Models
{
    public class ItemRequestDelinquentQueryModel
    {
        public string ModuleNm { get; set; }
        public DateTime FirstFollowupDate { get; set; }
        public DateTime SecondFollowupDate { get; set; }
        public DateTime ThirdFollowupDate { get; set; }
    }
}
