﻿using Autofac;
using IMSRepository.Models;
using ItemManagementService.Interfaces;
using ItemManagementService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
        public IHttpActionResult GetAllSubCategoriesByCategory([FromBody]SubCategoryByCategoryIdModel categoryId)
        {
            var container = ContainerConfig.Configure();

            using (var scope = container.BeginLifetimeScope())
            {
                var app = scope.Resolve<ISubCategoryBusinessLayer>();

                var result = app.GetAllSubCategoriesByCategory(categoryId.CategoryId);

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

            using (var scope = container.BeginLifetimeScope())
            {
                var app = scope.Resolve<ISubCategoryBusinessLayer>();

                var result = app.InsertNewSubCategory(subcategory);

                return Json(new { Result = result });
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="subcategory"></param>
        /// <returns></returns>
        [Route("api/ItemManagement/UpdateSubCategory")]
        [HttpPost]
        public IHttpActionResult UpdateSubCategory([FromBody]SubCategoryUpdateModel subcategory)
        {
            var container = ContainerConfig.Configure();

            using (var scope = container.BeginLifetimeScope())
            {
                var app = scope.Resolve<ISubCategoryBusinessLayer>();

                var result = app.UpdateSubCategoryDetail(subcategory);

                return Json(new { Result = result });
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("api/ItemManagement/DeleteSubCategory")]
        [HttpPost]
        public IHttpActionResult DeleteSubCategory([FromBody]int id)
        {
            var container = ContainerConfig.Configure();

            using (var scope = container.BeginLifetimeScope())
            {
                var app = scope.Resolve<ISubCategoryBusinessLayer>();

                var result = app.DeleteSubCategory(id);

                return Json(new { Result = result });
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("api/ItemManagement/GetItemById")]
        [HttpPost]
        public IHttpActionResult GetItemById([FromBody]SearchItemByIdModel item)
        {
            var container = ContainerConfig.Configure();

            using (var scope = container.BeginLifetimeScope())
            {
                var app = scope.Resolve<IItemBusinessLayer>();

                var result = app.GetItemById(item.Id);

                return Json(new { Result = result });
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        [Route("api/ItemManagement/ItemsByAdvancedSearch")]
        [HttpPost]
        public IHttpActionResult ItemsByAdvancedSearch([FromBody]ItemSearchQueryModel item)
        {
            var container = ContainerConfig.Configure();

            using (var scope = container.BeginLifetimeScope())
            {
                var app = scope.Resolve<IItemBusinessLayer>();

                var result = app.ItemAdvancedSearch(item);

                return Json(result);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        [Route("api/ItemManagement/ItemsBySimpleSearch")]
        [HttpPost]
        public IHttpActionResult ItemsBySimpleSearch([FromBody]ItemSimpleSearchModel item)
        {
            var container = ContainerConfig.Configure();

            using (var scope = container.BeginLifetimeScope())
            {
                var app = scope.Resolve<IItemBusinessLayer>();

                var result = app.ItemBySimpleSearch(item);

                return Json(result);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="word"></param>
        /// <returns></returns>
        [Route("api/ItemManagement/ItemAutoComplete")]
        [HttpPost]
        public IHttpActionResult ItemAutoComplete([FromBody]InputQueryModel query)
        {
            if (query.SearchString == "" || query.SearchString.Length < 3) { return Json(new { Result = "" }); };

            var container = ContainerConfig.Configure();

            using (var scope = container.BeginLifetimeScope())
            {
                var app = scope.Resolve<IItemBusinessLayer>();

                var result = app.ItemAutoComplete(query.SearchString);

                return Json(new { Result = result });
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Route("api/ItemManagement/GetAllLocations")]
        [HttpGet]
        public IHttpActionResult GetAllLocations()
        {
            var container = ContainerConfig.Configure();

            using (var scope = container.BeginLifetimeScope())
            {
                var app = scope.Resolve<IItemBusinessLayer>();

                var result = app.GetAllLocations();

                return Json(new { Result = result });
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Route("api/ItemManagement/GetAllItemStatus")]
        [HttpGet]
        public IHttpActionResult GetAllItemStatus()
        {
            var container = ContainerConfig.Configure();

            using (var scope = container.BeginLifetimeScope())
            {
                var app = scope.Resolve<IItemBusinessLayer>();

                var result = app.GetAllItemStatus();

                return Json(new { Result = result });
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("api/ItemManagement/GetItemDetailBySubCategoryId")]
        [HttpPost]
        public IHttpActionResult GetItemDetailBySubCategoryId([FromBody]ItemDetailBySubCategoryModel subCategory)
        {
            var container = ContainerConfig.Configure();

            using (var scope = container.BeginLifetimeScope())
            {
                var app = scope.Resolve<IItemBusinessLayer>();

                var result = app.GetItemDetailBySubCategoryId(subCategory.SubCategoryId);

                return Json(new { Result = result });
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        [Route("api/ItemManagement/InsertNewItem")]
        [HttpPost]
        public IHttpActionResult InsertNewItem([FromBody]InsertItemModel item)
        {
            var container = ContainerConfig.Configure();

            using (var scope = container.BeginLifetimeScope())
            {
                var app = scope.Resolve<IItemBusinessLayer>();

                var result = app.InsertNewItem(item);

                return Json(new { Result = result });
            }
        }

        public IHttpActionResult UpdateExistingItem([FromBody]UpdateItemModel item)
        {
            var container = ContainerConfig.Configure();

            using (var scope = container.BeginLifetimeScope())
            {
                var app = scope.Resolve<IItemBusinessLayer>();

                var result = app.UpdateExistingItem(item);

                return Json(new { Result = result });
            }
        }

        [Route("api/ItemManagement/UpdateItemStatusById")]
        [HttpPost]
        public IHttpActionResult UpdateItemStatusById([FromBody]UpdateItemStatusModel status)
        {
            var container = ContainerConfig.Configure();

            using (var scope = container.BeginLifetimeScope())
            {
                var app = scope.Resolve<IItemBusinessLayer>();

                var result = app.UpdateItemStatusById(status);

                return Json(new { Result = result });
            }
        }

        [Route("api/ItemManagement/TagsAutoComplete")]
        [HttpPost]
        public IHttpActionResult TagsAutoComplete([FromBody]string word)
        {
            if(word.Length < 3) { return Json(new { Result = "" }); }

            var container = ContainerConfig.Configure();

            using (var scope = container.BeginLifetimeScope())
            {
                var app = scope.Resolve<IItemBusinessLayer>();

                var result = app.TagsAutoComplete(word);

                return Json(new { Result = result });
            }
        }

        [Route("api/ItemManagement/AddNewTagging")]
        [HttpPost]
        public IHttpActionResult AddNewTagging([FromBody]TagsMappingModel tags)
        {
            var container = ContainerConfig.Configure();

            using (var scope = container.BeginLifetimeScope())
            {
                var app = scope.Resolve<IItemBusinessLayer>();

                var result = app.AddNewTagToItem(tags);

                return Json(new { Result = result });
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Route("api/ItemManagement/GetAllBrands")]
        [HttpGet]
        public IHttpActionResult GetAllBrands()
        {
            var container = ContainerConfig.Configure();

            using (var scope = container.BeginLifetimeScope())
            {
                var app = scope.Resolve<IBrandBusinessLayer>();

                var result = app.GetAllBrands();

                return Json(new { Result = result });
            }
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="brand"></param>
        /// <returns></returns>
        [Route("api/ItemManagement/InsertNewBrand")]
        [HttpPost]
        public IHttpActionResult InsertNewBrand([FromBody]BrandModel brand)
        {
            var container = ContainerConfig.Configure();

            using (var scope = container.BeginLifetimeScope())
            {
                var app = scope.Resolve<IBrandBusinessLayer>();

                var result = app.InsertNewBrand(brand);

                return Json(new { Result = result });
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="brand"></param>
        /// <returns></returns>
        [Route("api/ItemManagement/UpdateBrand")]
        [HttpPost]
        public IHttpActionResult UpdateBrand([FromBody]BrandModel brand)
        {
            var container = ContainerConfig.Configure();

            using (var scope = container.BeginLifetimeScope())
            {
                var app = scope.Resolve<IBrandBusinessLayer>();

                var result = app.UpdateBrandDetail(brand);

                return Json(new { Result = result });
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("api/ItemManagement/DeleteBrand")]
        [HttpPost]
        public IHttpActionResult DeleteBrand([FromBody]int id)
        {
            var container = ContainerConfig.Configure();

            using (var scope = container.BeginLifetimeScope())
            {
                var app = scope.Resolve<IBrandBusinessLayer>();

                var result = app.DeleteBrand(id);

                return Json(new { Result = result });
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="brandName"></param>
        /// <returns></returns>
        [Route("api/ItemManagement/SearchBrands")]
        [HttpPost]
        public IHttpActionResult GetSearchBrands([FromBody]Newtonsoft.Json.Linq.JObject brand)
        {
            var container = ContainerConfig.Configure();

            using (var scope = container.BeginLifetimeScope())
            {
                var app = scope.Resolve<IBrandBusinessLayer>();

                var result = app.SearchBrands(brand.GetValue("brandName").ToString());

                return Json(new { Result = result });
            }
        }
    }
}
