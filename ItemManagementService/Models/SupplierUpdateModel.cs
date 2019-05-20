﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ItemManagementService.Models
{
    public class SupplierUpdateModel
    {
        public int Id { get; set; }
        public string SupplierName { get; set; }
        public bool IsActive { get; set; }
        public string TelephoneNumber { get; set; }
        public DateTime CreateDttm { get; set; }
        public string UpdateUserName { get; set; }
        public DateTime UpdateDttm { get; set; }
    }
}