using System.Collections.Generic;

namespace IMSRepository.Utilities
{
    public interface ISubCategoryDataAccess
    {
        List<SubCategory> GetSubCategories();
        List<SubCategory> GetSubCategoriesByCategory(int categoryId);
        SubCategory InsertNewSubCategory(SubCategory sub);
        string UpdateSubCategoryDetails(SubCategory sub);
        string DeleteSubCategory(int subCategoryId);
    }
}