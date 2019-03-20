using System.Collections.Generic;

namespace IMSRepository.Utilities
{
    public interface ICategoryDataAccess
    {
        List<Category> GetCategories();
    }
}