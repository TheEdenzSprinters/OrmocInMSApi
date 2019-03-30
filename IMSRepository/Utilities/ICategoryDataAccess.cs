using System.Collections.Generic;

namespace IMSRepository.Utilities
{
    public interface ICategoryDataAccess
    {
        List<Category> GetCategories();
        string InsertNewCategory(Category cat);
        string UpdateCategoryDetails(Category cat);
        string DeleteCategory(int categoryId);
    }
}