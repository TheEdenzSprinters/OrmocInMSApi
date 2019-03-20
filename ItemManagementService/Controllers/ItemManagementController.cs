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
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Route("api/ItemManagement/GetAllCategories")]
        [HttpGet]
        public IHttpActionResult GetAllCategories()
        {
            var container = ContainerConfig.Configure();

            using (var scope = container.BeginLifetimeScope())
            {
                var app = scope.Resolve<ICategoryBusinessLayer>();

                var result = app.GetAllCategories();

                return Json(result);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="categoryId"></param>
        /// <returns></returns>
        [Route("api/ItemManagement/GetAllSubCategoriesByCategory")]
        [HttpPost]
        public IHttpActionResult GetAllSubCategoriesByCategory([FromBody]int categoryId)
        {
            var container = ContainerConfig.Configure();

            using(var scope = container.BeginLifetimeScope())
            {
                var app = scope.Resolve<ISubCategoryBusinessLayer>();

                var result = app.GetAllSubCategoriesByCategory(categoryId);

                return Json(result);
            }

        }

    }
}
