using Autofac;
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
        /// Gets the specific Item record by ID.
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
        /// Gets all items and returns the result as per search field queries.
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
        /// Gets all items and returns the result as per simple search by Item Name.
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
        /// Gets a list of suggested Item Name for auto-suggest in Item Simple Search.
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
        /// Gets all active Locations key-value pair.
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
        /// Gets all active Item Status key-value pair.
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
        /// Gets all Item Details Mapping per Sub-Category. Item Details Mapping contains 
        /// the mapping of several key-value pair for the fields specific per Sub-Category 
        /// (e.g. height, width and length for all Sub-Category under plywood).
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
        /// Inserts new Item record into the database.
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

        /// <summary>
        /// Updates fields for an existing Item record.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        [Route("api/ItemManagement/UpdateExistingItem")]
        [HttpPost]
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

        /// <summary>
        /// Updates status of an item record.
        /// </summary>
        /// <param name="status"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Gets a list of suggested Tag Name for auto-suggest in Tags field under Item Advanced Search.
        /// </summary>
        /// <param name="word"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Add new Tags for specific Item record.
        /// </summary>
        /// <param name="tags"></param>
        /// <returns></returns>
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

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Route("api/ItemManagement/GetAllSuppliers")]
        [HttpGet]
        public IHttpActionResult GetSuppliers()
        {
            var container = ContainerConfig.Configure();

            using (var scope = container.BeginLifetimeScope())
            {
                var app = scope.Resolve<ISupplierBusinessLayer>();

                var result = app.GetSuppliers();

                return Json(new { Result = result });
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="supplier"></param>
        /// <returns></returns>
        [Route("api/ItemManagement/CreateNewSupplier")]
        [HttpPost]
        public IHttpActionResult CreateNewSupplier([FromBody]SupplierModel supplier)
        {
            var container = ContainerConfig.Configure();

            using (var scope = container.BeginLifetimeScope())
            {
                var app = scope.Resolve<ISupplierBusinessLayer>();

                var result = app.CreateNewSupplier(supplier);

                return Json(new { Result = result });
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="supplier"></param>
        /// <returns></returns>
        [Route("api/ItemManagement/SuppliersSearch")]
        [HttpPost]
        public IHttpActionResult GetSupplierSearch([FromBody]SupplierSimpleSearchModel supplier)
        {
            var container = ContainerConfig.Configure();

            using (var scope = container.BeginLifetimeScope())
            {
                var app = scope.Resolve<ISupplierBusinessLayer>();

                var result = app.SuppliersSearch(supplier);

                return Json(new { Result = result });
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="supplierUpdate"></param>
        /// <returns></returns>
        [Route("api/ItemManagement/UpdateSupplier")]
        [HttpPost]
        public IHttpActionResult UpdateSupplier([FromBody]SupplierUpdateModel supplierUpdate)
        {
            var container = ContainerConfig.Configure();

            using (var scope = container.BeginLifetimeScope())
            {
                var app = scope.Resolve<ISupplierBusinessLayer>();

                var result = app.UpdateSupplier(supplierUpdate);

                return Json(new { Result = result });
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sup"></param>
        /// <returns></returns>
        [Route("api/ItemManagement/ViewSupplierById")]
        [HttpPost]
        public IHttpActionResult ViewSupplierById([FromBody]SearchSupplierByIdModel sup)
        {
            var container = ContainerConfig.Configure();

            using (var scope = container.BeginLifetimeScope())
            {
                var app = scope.Resolve<ISupplierBusinessLayer>();

                var result = app.ViewSupplierById(sup.Id);

                return Json(new { Result = result });
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Route("api/ItemManagement/GetRedLevelItems")]
        [HttpGet]
        public IHttpActionResult GetRedLevelItems()
        {
            var container = ContainerConfig.Configure();

            using (var scope = container.BeginLifetimeScope())
            {
                var app = scope.Resolve<IItemBusinessLayer>();

                var result = app.GetRedLevelItems();

                return Json(result);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Route("api/ItemManagement/GetAmberLevelItems")]
        [HttpGet]
        public IHttpActionResult GetAmberLevelItems()
        {
            var container = ContainerConfig.Configure();

            using (var scope = container.BeginLifetimeScope())
            {
                var app = scope.Resolve<IItemBusinessLayer>();

                var result = app.GetAmberLevelItems();

                return Json(result);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Route("api/ItemManagement/GetOldestStocks")]
        [HttpGet]
        public IHttpActionResult GetOldestStocks()
        {
            var container = ContainerConfig.Configure();

            using (var scope = container.BeginLifetimeScope())
            {
                var app = scope.Resolve<IItemBusinessLayer>();

                var result = app.GetOldestStocks();

                return Json(result);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="brand"></param>
        /// <returns></returns>
        [Route("api/ItemManagement/ValidateBrandNameExist")]
        [HttpPost]
        public IHttpActionResult ValidateBrandNameExist([FromBody]BrandModel brand)
        {
            var container = ContainerConfig.Configure();

            using (var scope = container.BeginLifetimeScope())
            {
                var app = scope.Resolve<IBrandBusinessLayer>();

                var result = app.ValidateBrandNameExist(brand);

                return Json(new { Result = result });
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="brand"></param>
        /// <returns></returns>
        [Route("api/ItemManagement/BrandsAutoComplete")]
        [HttpPost]
        public IHttpActionResult BrandsAutoComplete([FromBody]BrandModel brand)
        {
            var container = ContainerConfig.Configure();

            using (var scope = container.BeginLifetimeScope())
            {
                var app = scope.Resolve<IBrandBusinessLayer>();

                var result = app.GetBrandNamesList(brand);

                return Json(result);
            }
        }
    }
}
