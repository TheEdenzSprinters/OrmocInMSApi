using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ItemManagementService.Models
{
    public class InsertItemModel : BaseItemModel
    {
        public List<InsertItemDetailMappingModel> ItemDetail { get; set; }
    }
}