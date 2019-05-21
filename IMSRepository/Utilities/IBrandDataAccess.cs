using System.Collections.Generic;

namespace IMSRepository.Utilities
{
    public interface IBrandDataAccess
    {
        List<Brand> GetBrands();
        Brand InsertNewBrand(Brand brand);
        string UpdateBrandDetails(Brand brand);
        string DeleteBrand(int brandId);
        List<Brand> SearchBrands(string brandName);
    }
}