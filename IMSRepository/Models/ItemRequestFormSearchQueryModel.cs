using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMSRepository.Models
{
    public class ItemRequestFormSearchQueryModel
    {
        public string ModuleNm { get; set; }
        public int? Id { get; set; }
        public string Title { get; set; }
        public int? StatusCd { get; set; }
        public string DateCreated { get; set; }
        public string DateTo { get; set; }
        public int NextBatch { get; set; }
    }
}
