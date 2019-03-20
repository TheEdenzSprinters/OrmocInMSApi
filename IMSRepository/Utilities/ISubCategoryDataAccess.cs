using System.Collections.Generic;

namespace IMSRepository.Utilities
{
    public interface ISubCategoryDataAccess
    {
        List<SubCategory> GetSubCategories();
        List<SubCategory> GetSubCategoriesByCategory(int categoryId);
        string InsertNewSubCategory(SubCategory sub);
    }
}