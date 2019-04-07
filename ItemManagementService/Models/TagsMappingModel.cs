using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ItemManagementService.Models
{
    public class TagsMappingModel
    {
        public int Id { get; set; }
        public int ItemId { get; set; }
        public string TagValue { get; set; }
    }
}