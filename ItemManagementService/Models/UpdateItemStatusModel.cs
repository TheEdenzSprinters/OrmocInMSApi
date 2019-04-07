using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ItemManagementService.Models
{
    public class UpdateItemStatusModel
    {
        public int Id { get; set; }
        public int StatusCd { get; set; }
    }
}