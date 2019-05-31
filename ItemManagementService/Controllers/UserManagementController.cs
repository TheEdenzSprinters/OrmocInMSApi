using Autofac;
using ItemManagementService.Interfaces;
using ItemManagementService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ItemManagementService.Controllers
{
    public class UserManagementController : ApiController
    {
       [Route("api/UserManagement/Login")]
       [HttpPost]
       public IHttpActionResult Login([FromBody]LoginModel loginToCompare)
        {
            var container = ContainerConfig.Configure();

            using (var scope = container.BeginLifetimeScope())
            {
                var login = scope.Resolve<ILoginBusinessLayer>();

                var result = login.AuthenticateUser(loginToCompare);

                return Json(new { Result = result });
            }
        }
    }
}
