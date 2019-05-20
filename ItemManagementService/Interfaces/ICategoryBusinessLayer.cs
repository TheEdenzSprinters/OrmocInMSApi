using IMSRepository;
using ItemManagementService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ItemManagementService.Interfaces
{
    public interface ICategoryBusinessLayer
    {
        List<Category> GetAllCategories();
        Category InsertNewCategory(CategoryModel cat);
        string UpdateCategoryDetail(CategoryUpdateModel cat);
        string DeleteCategory(int Id);
    }
}