using IMSRepository;
using IMSRepository.Utilities;
using ItemManagementService.BusinessLayer;
using ItemManagementService.Interfaces;
using ItemManagementService.Models;
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
    public class InsertNewCategoriesTest
    {
        [Test]
        public void InsertNewCategory_WhenCategoryNameIsBlank_ReturnFieldIsBlankError()
        {
            CategoryModel input = new CategoryModel()
            {
                CategoryName = string.Empty,
                IsActive = true
            };

            Mock<ICategoryDataAccess> mockCategories = new Mock<ICategoryDataAccess>();

            ICategoryBusinessLayer app = new CategoryBusinessLayer(mockCategories.Object);

            var output = app.InsertNewCategory(input);

            Assert.AreEqual("Category Name should not be blank.", output.Message);
        }

        [Test]
        public void InsertNewCategory_WhenCategoryModelInputIsNull_ReturnInputIsNullError()
        {
            CategoryModel input = null;

            Mock<ICategoryDataAccess> mockCategories = new Mock<ICategoryDataAccess>();

            ICategoryBusinessLayer app = new CategoryBusinessLayer(mockCategories.Object);

            var output = app.InsertNewCategory(input);

            Assert.AreEqual("Input is null.", output.Message);
        }

        [Test]
        public void InsertNewcategory_WhenCategoryModelInputIsCorrect_ReturnSuccess()
        {
            CategoryModel input = new CategoryModel()
            {
                CategoryName = "Furniture",
                IsActive = true
            };

            Category mockInput = new Category()
            {
                CategoryName = "Furniture",
                IsActive = true
            };

            Mock<ICategoryDataAccess> mockCategories = new Mock<ICategoryDataAccess>();

            mockCategories.Setup(x => x.InsertNewCategory(mockInput)).Returns(new Category()
            {
                Id = 1,
                CategoryName = "Furniture",
                IsActive = true,
                CreateDttm = DateTime.UtcNow,
                CreateUserName = "ADMIN",
                UpdateDttm = DateTime.UtcNow,
                UpdateUserName = "ADMIN"
            });

            ICategoryBusinessLayer app = new CategoryBusinessLayer(mockCategories.Object);

            var output = app.InsertNewCategory(input);

            Assert.AreEqual("Success", output.Message);
        }
    }
}
