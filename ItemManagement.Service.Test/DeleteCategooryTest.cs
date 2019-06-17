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
    public class DeleteCategooryTest
    {
        [Test]
        public void DeleteCategory_WhenCategoryIdInputIsZero_ReturnsIdShouldNotBeZero()
        {
            int input = 0;

            Mock<ICategoryDataAccess> mockCategories = new Mock<ICategoryDataAccess>();

            mockCategories.Setup(x => x.DeleteCategory(input)).Returns("No record found.");

            ICategoryBusinessLayer app = new CategoryBusinessLayer(mockCategories.Object);

            var output = app.DeleteCategory(input);

            Assert.AreEqual("No record found.", output);
        }

        [Test]
        public void DeleteCategory_WhenCategoryIdDoesNotExist_ReturnsIdShouldNotBeZero()
        {
            Mock<ICategoryDataAccess> mockCategories = new Mock<ICategoryDataAccess>();

            mockCategories.Setup(x => x.DeleteCategory(It.IsAny<int>())).Returns("No record found.");

            ICategoryBusinessLayer app = new CategoryBusinessLayer(mockCategories.Object);

            var output = app.DeleteCategory(It.IsAny<int>());

            Assert.AreEqual("No record found.", output);
        }

        [Test]
        public void DeleteCategory_WhenCategoryIdIsCorrect_ReturnsSuccess()
        {
            Mock<ICategoryDataAccess> mockCategories = new Mock<ICategoryDataAccess>();

            mockCategories.Setup(x => x.DeleteCategory(It.IsAny<int>())).Returns("Category deleted.");

            ICategoryBusinessLayer app = new CategoryBusinessLayer(mockCategories.Object);

            var output = app.DeleteCategory(It.IsAny<int>());

            Assert.AreEqual("Category deleted.", output);
        }
    }
}
