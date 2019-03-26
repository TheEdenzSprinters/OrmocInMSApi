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
        /// <param name="category"></param>
        /// <returns></returns>
        [Route("api/ItemManagement/InsertNewCategory")]
        [HttpPost]
        public IHttpActionResult InsertNewCategory([FromBody]CategoryModel category)
        {
            var container = ContainerConfig.Configure();

            using (var scope = container.BeginLifetimeScope())
            {
                var app = scope.Resolve<ICategoryBusinessLayer>();

                var result = app.InsertNewCategory(category);

                return Json(new { Result = result });
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        [Route("api/ItemManagement/UpdateCategory")]
        [HttpPost]
        public IHttpActionResult UpdateCategory([FromBody]CategoryUpdateModel category)
        {
            var container = ContainerConfig.Configure();

            using (var scope = container.BeginLifetimeScope())
            {
                var app = scope.Resolve<ICategoryBusinessLayer>();

                var result = app.UpdateCategoryDetail(category);

                return Json(new { Result = result });
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("api/ItemManagement/DeleteCategory")]
        [HttpPost]
        public IHttpActionResult DeleteCategory([FromBody]int id)
        {
            var container = ContainerConfig.Configure();

            using (var scope = container.BeginLifetimeScope())
            {
                var app = scope.Resolve<ICategoryBusinessLayer>();

                var result = app.DeleteCategory(id);

                return Json(new { Result = result });
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="subcategory"></param>
        /// <returns></returns>
        [Route("api/ItemManagement/InsertNewSubCategory")]
        [HttpPost]
        public IHttpActionResult InsertNewSubCategory([FromBody]SubCategoryModel subcategory)
        {
            var container = ContainerConfig.Configure();

            using(var scope = container.BeginLifetimeScope())
            {
                var app = scope.Resolve<ISubCategoryBusinessLayer>();

                var result = app.InsertNewSubCategory(subcategory);

                return Json(new { Result = result });
            }
        }

        [Route("api/ItemManagement/UpdateSubCategory")]
        [HttpPost]
        public IHttpActionResult UpdateSubCategory([FromBody]SubCategoryUpdateModel subcategory)
        {
            var container = ContainerConfig.Configure();

            using(var scope = container.BeginLifetimeScope())
            {
                var app = scope.Resolve<ISubCategoryBusinessLayer>();

                var result = app.UpdateSubCategoryDetail(subcategory);

                return Json(new { Result = result }); 
            }
        }

        [Route("api/ItemManagement/DeleteSubCategory")]
        [HttpPost]
        public IHttpActionResult DeleteSubCategory([FromBody]int id)
        {
            var container = ContainerConfig.Configure();

            using(var scope = container.BeginLifetimeScope())
            {
                var app = scope.Resolve<ISubCategoryBusinessLayer>();

                var result = app.DeleteSubCategory(id);

                return Json(new { Result = result });
            }
        }
    }
}
