using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ItemManagementService.Models
{
    public class ItemSingleModel : BaseItemModel
    {
        public int Id { get; set; }
        public string CreateUserName { get; set; }
        public DateTime CreateDttm { get; set; }
        public string UpdateUserName { get; set; }
        public DateTime UpdateDttm { get; set; }
        public List<ItemDetailModel> ItemDetail { get; set; }
    }
}