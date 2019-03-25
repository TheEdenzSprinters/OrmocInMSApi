using IMSRepository;
using ItemManagementService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ItemManagementService.Interfaces
{
    public interface ISubCategoryBusinessLayer
    {
        List<SubCategory> GetAllSubCategories();
        List<SubCategory> GetAllSubCategoriesByCategory(int CategoryId);
        string InsertNewSubcategory(SubCategoryModel sub);
        string UpdateSubCategoryDetail(SubCategoryUpdateModel sub);
        string DeleteSubCategory(int Id);
    }
}