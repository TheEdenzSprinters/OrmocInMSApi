using Autofac;
using IMSRepository.Utilities;
using ItemManagementService.BusinessLayer;
using ItemManagementService.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace ItemManagementService
{
    public class ContainerConfig
    {
        public static IContainer Configure()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<SubCategoryBusinessLayer>().As<ISubCategoryBusinessLayer>();

            builder.RegisterAssemblyTypes(Assembly.Load(nameof(IMSRepository)))
                .Where(t => t.Namespace.Contains("Utilities"))
                .As(t => t.GetInterfaces().FirstOrDefault(i => i.Name == "I" + t.Name));

            return builder.Build();
        }
    }
}