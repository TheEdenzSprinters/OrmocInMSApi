using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ItemManagementService.Models
{
    public class UpdateItemModel : BaseItemModel
    {
        public int Id { get; set; }
        public List<ItemDetailModel> ItemDetail { get; set; }
    }
}