using Autofac;
using PurchaseOrderManagementService.Interfaces;
using PurchaseOrderManagementService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PurchaseOrderManagementService.Controllers
{
    public class PurchaseOrderManagementController : ApiController
    {
        [Route("api/PurchaseOrderManagement/ItemRequestFormSearch")]
        [HttpPost]
        public IHttpActionResult ItemRequestFormSearch([FromBody]ItemRequestSearchQueryModel itemRequest)
        {
            var container = ContainerConfig.Configure();

            using(var scope = container.BeginLifetimeScope())
            {
                var app = scope.Resolve<IItemRequestFormBusinessLayer>();

                var result = app.ItemRequestFormSearch(itemRequest);

                return Json(result);
            }
        }

        [Route("api/PurchaseOrderManagement/GetItemRequestFormDelinquents")]
        [HttpGet]
        public IHttpActionResult GetItemRequestFormDelinquents()
        {
            var container = ContainerConfig.Configure();

            using (var scope = container.BeginLifetimeScope())
            {
                var app = scope.Resolve<IItemRequestFormBusinessLayer>();

                var result = app.GetItemRequestFormDelinquents();

                return Json(result);
            }
        }

        [Route("api/PurchaseOrderManagement/GetItemRequestFormById")]
        [HttpPost]
        public IHttpActionResult GetItemRequestFormById([FromBody]ItemRequestByIdModel itemRequest)
        {
            var container = ContainerConfig.Configure();

            using (var scope = container.BeginLifetimeScope())
            {
                var app = scope.Resolve<IItemRequestFormBusinessLayer>();

                var result = app.GetItemRequestFormById(itemRequest.Id);

                return Json(result);
            }
        }

        [Route("api/PurchaseOrderManagement/InsertNewItemRequest")]
        [HttpPost]
        public IHttpActionResult InsertNewItemRequest([FromBody]InsertItemRequestModel itemRequest)
        {
            var container = ContainerConfig.Configure();

            using (var scope = container.BeginLifetimeScope())
            {
                var app = scope.Resolve<IItemRequestFormBusinessLayer>();

                var result = app.InsertNewItemRequest(itemRequest);

                return Json(result);
            }
        }

        [Route("api/PurchaseOrderManagement/UpdateItemRequestById")]
        [HttpPost]
        public IHttpActionResult UpdateItemRequestById([FromBody]UpdateItemRequestModel itemRequest)
        {
            var container = ContainerConfig.Configure();

            using (var scope = container.BeginLifetimeScope())
            {
                var app = scope.Resolve<IItemRequestFormBusinessLayer>();

                var result = app.UpdateItemRequestById(itemRequest);

                return Json(result);
            }
        }

        [Route("api/PurchaseOrderManagement/ValidateStatusChangeItemRequest")]
        [HttpPost]
        public IHttpActionResult ValidateStatusChangeItemRequest([FromBody]UpdateItemRequestModel itemRequest)
        {
            var container = ContainerConfig.Configure();

            using (var scope = container.BeginLifetimeScope())
            {
                var app = scope.Resolve<IItemRequestFormBusinessLayer>();

                var result = app.ValidateStatusChangeItemRequest(itemRequest);

                return Json(new { Result = result });
            }
        }

        [Route("api/PurchaseOrderManagement/GetItemRequestTicketSatus")]
        [HttpGet]
        public IHttpActionResult GetItemRequestTicketSatus()
        {
            var container = ContainerConfig.Configure();

            using (var scope = container.BeginLifetimeScope())
            {
                var app = scope.Resolve<IItemRequestFormBusinessLayer>();

                var result = app.GetItemRequestTicketSatus();

                return Json(result);
            }
        }

        [Route("api/PurchaseOrderManagement/AttachItemToItemRequest")]
        [HttpPost]
        public IHttpActionResult AttachItemToItemRequest([FromBody]ItemToItemRequestModel item)
        {
            var container = ContainerConfig.Configure();

            using (var scope = container.BeginLifetimeScope())
            {
                var app = scope.Resolve<IItemRequestFormBusinessLayer>();

                var result = app.AttachItemToItemRequest(item);

                return Json(result);
            }
        }

        [Route("api/PurchaseOrderManagement/DeleteItemFromItemRequest")]
        [HttpPost]
        public IHttpActionResult DeleteItemFromItemRequest([FromBody]ItemToItemRequestModel item)
        {
            var container = ContainerConfig.Configure();

            using (var scope = container.BeginLifetimeScope())
            {
                var app = scope.Resolve<IItemRequestFormBusinessLayer>();

                var result = app.DeleteItemFromItemRequest(item);

                return Json(result);
            }
        }
    }
}
