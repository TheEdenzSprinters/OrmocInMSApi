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
    public class UpdateCategoryDetailTest
    {
        [Test]
        public void UpdateCategoryDetail_WhenCategoryNameIsNullOrEmpty_ReturnsCategoryNameIsBlankError()
        {
            CategoryUpdateModel input = new CategoryUpdateModel()
            {
                CategoryName = string.Empty,
                IsActive = true
            };

            Mock<ICategoryDataAccess> mockCategories = new Mock<ICategoryDataAccess>();

            ICategoryBusinessLayer app = new CategoryBusinessLayer(mockCategories.Object);

            var output = app.UpdateCategoryDetail(input);

            Assert.AreEqual("Category Name should not be blank.", output);
        }
        
        [Test]
        public void UpdateCategoryDetail_WhenCategoryModelInputIsNull_ReturnsInputIsNullError()
        {
            CategoryUpdateModel input = null;

            Mock<ICategoryDataAccess> mockCategories = new Mock<ICategoryDataAccess>();

            ICategoryBusinessLayer app = new CategoryBusinessLayer(mockCategories.Object);

            var output = app.UpdateCategoryDetail(input);

            Assert.AreEqual("Input is null.", output);
        }

        [Test]
        public void UpdateCategoryDetail_WhenCategoryIdDoesNotExist_ReturnsErrorCategoryNotFound()
        {
            CategoryUpdateModel input = new CategoryUpdateModel()
            {
                Id = 0,
                CategoryName = "Furniture",
                IsActive = true
            };

            Mock<ICategoryDataAccess> mockCategories = new Mock<ICategoryDataAccess>();

            mockCategories.Setup(x => x.UpdateCategoryDetails(It.IsAny<Category>())).Returns("No record found.");

            ICategoryBusinessLayer app = new CategoryBusinessLayer(mockCategories.Object);

            var output = app.UpdateCategoryDetail(input);

            Assert.AreEqual("No record found.", output);
        }

        [Test]
        public void UpdateCategoryDetail_WhenCategoryModelInputIsCorrect_ReturnsSuccess()
        {
            CategoryUpdateModel input = new CategoryUpdateModel()
            {
                Id = 1,
                CategoryName = "Furniture",
                IsActive = true
            };

            Mock<ICategoryDataAccess> mockCategories = new Mock<ICategoryDataAccess>();

            mockCategories.Setup(x => x.UpdateCategoryDetails(It.IsAny<Category>())).Returns("Category updated.");

            ICategoryBusinessLayer app = new CategoryBusinessLayer(mockCategories.Object);

            var output = app.UpdateCategoryDetail(input);

            Assert.AreEqual("Category updated.", output);
        }
    }
}
