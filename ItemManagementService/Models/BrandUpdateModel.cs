using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ItemManagementService.Models
{
    public class BrandUpdateModel
    {
        public int Id { get; set; }
        public string BrandName { get; set; }
        public string Notes { get; set; }
        public bool IsActive { get; set; }
        public string CreateUserName { get; set; }
        public DateTime CreateDttm { get; set; }
        public string UpdateUserName { get; set; }
        public DateTime UpdateDttm { get; set; }
    }
}