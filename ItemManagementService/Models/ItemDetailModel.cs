using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ItemManagementService.Models
{
    public class ItemDetailModel : InsertItemDetailMappingModel
    {
        public int Id { get; set; }
        public bool ShowUnitsOfMeasure { get; set; }
        public string UnitOfMeasure { get; set; }
        public string ItemDetailName { get; set; }
    }
}