using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Reflection;
using PurchaseOrderManagementService.Interfaces;
using PurchaseOrderManagementService.BusinessLayer;

namespace PurchaseOrderManagementService
{
    public static class ContainerConfig
    {
        public static IContainer Configure()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<ItemRequestFormBusinessLayer>().As<IItemRequestFormBusinessLayer>();

            builder.RegisterAssemblyTypes(Assembly.Load(nameof(IMSRepository)))
                .Where(t => t.Namespace.Contains("Utilities"))
                .As(t => t.GetInterfaces().FirstOrDefault(i => i.Name == "I" + t.Name));

            return builder.Build();
        }
    }
}