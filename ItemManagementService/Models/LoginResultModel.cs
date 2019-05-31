using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ItemManagementService.Models
{
    public class LoginResultModel
    {
        public string Message { get; set; }
        public string Token { get; set; }
    }
}