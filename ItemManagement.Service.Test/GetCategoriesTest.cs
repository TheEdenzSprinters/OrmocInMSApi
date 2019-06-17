using IMSRepository;
using IMSRepository.Utilities;
using ItemManagementService.BusinessLayer;
using ItemManagementService.Interfaces;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItemManagement.Service.Test
{
    [TestFixture]
    public class GetCategoriesTest
    {
        [Test]
        public void GetAllCategories_ReturnsAllCategories()
        {
            Mock<ICategoryDataAccess> categories = new Mock<ICategoryDataAccess>();
            ICategoryBusinessLayer app = new CategoryBusinessLayer(categories.Object);
            List<Category> mockCategories = new List<Category>
            {
                new Category
                {
                    Id = 1,
                    CategoryName = "Hardware",
                    IsActive = true,
                },
                new Category
                {
                    Id = 1,
                    CategoryName = "Electrical",
                    IsActive = true,
                },
                new Category
                {
                    Id = 1,
                    CategoryName = "Industrial Tools",
                    IsActive = true,
                },
                new Category
                {
                    Id = 1,
                    CategoryName = "Auto Parts",
                    IsActive = true,
                }
            };

            

            categories.Setup(x => x.GetCategories()).Returns(mockCategories);

            var output = app.GetAllCategories();

            Assert.IsNotNull(output);
        }
    }
}
