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
        List<BrandModel> GetAllBrands();
        Brand InsertNewBrand(BrandModel brand);
        string UpdateBrandDetail(BrandModel brand);
        string DeleteBrand(int Id);
        List<BrandModel> SearchBrands(string brandName);
        int ValidateBrandNameExist(BrandModel brand);
        List<string> GetBrandNamesList(BrandModel brand);
    }
}