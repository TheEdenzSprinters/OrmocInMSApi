using System.Collections.Generic;

namespace IMSRepository.Utilities
{
    public interface ICategoryDataAccess
    {
        List<Category> GetCategories();
        Category InsertNewCategory(Category cat);
        string UpdateCategoryDetails(Category cat);
        string DeleteCategory(int categoryId);
    }
}