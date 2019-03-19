using Autofac;
using ItemManagementService.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ItemManagementService.Controllers
{
    public class ItemManagementController : ApiController
    {
        // GET: api/ItemManagement
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/ItemManagement/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/ItemManagement
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/ItemManagement/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/ItemManagement/5
        public void Delete(int id)
        {
        }


        [Route("api/ItemManagement/GetAllSubCategories")]
        [HttpGet]
        public IHttpActionResult GetAllSubCategories()
        {
            var container = ContainerConfig.Configure();

            using (var scope = container.BeginLifetimeScope())
            {
                var app = scope.Resolve<ISubCategoryBusinessLayer>();

                var result = app.GetAllSubCategories();

                return Json(result);
            }
        }
    }
}
