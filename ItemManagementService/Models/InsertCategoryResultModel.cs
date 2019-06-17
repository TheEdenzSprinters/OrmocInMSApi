using IMSRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ItemManagementService.Models
{
    public class InsertCategoryResultModel
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public Category NewCategory { get; set; }
    }
}