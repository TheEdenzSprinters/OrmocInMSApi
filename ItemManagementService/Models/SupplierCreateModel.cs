﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ItemManagementService.Models
{
    public class SupplierCreateModel
    {
        public string SupplierName { get; set; }
        public string SupplierAddress { get; set; }
        public string TelephoneNumber { get; set; }
        public string Email { get; set; }
        public string Notes { get; set; }       
    }
}