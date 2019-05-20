using IMSRepository;
using ItemManagementService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ItemManagementService.Interfaces
{
    public interface IBrandBusinessLayer
    {
        List<Brand> GetAllBrands();
        Brand InsertNewBrand(BrandModel brand);
        string UpdateBrandDetail(BrandUpdateModel brand);
        string DeleteBrand(int Id);
        List<BrandModel> SearchBrands(string brandName);
    }
}