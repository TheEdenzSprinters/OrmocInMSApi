using IMSRepository;
using IMSRepository.Utilities;
using ItemManagementService.Interfaces;
using ItemManagementService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ItemManagementService.BusinessLayer
{
    public class BrandBusinessLayer : IBrandBusinessLayer
    {
        readonly IBrandDataAccess _brandDataAccess;

        public BrandBusinessLayer(IBrandDataAccess BrandDataAccess)
        {
            _brandDataAccess = BrandDataAccess;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<BrandModel> GetAllBrands()
        {
            return _brandDataAccess.GetBrands().Select(x => MapBrandToBrandModel(x)).ToList(); 
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="brand"></param>
        /// <returns></returns>
        public Brand InsertNewBrand(BrandModel brand)
        {
            Brand brandToInsert = new Brand();
            Brand result = new Brand();

            brandToInsert.BrandName = brand.BrandName;
            brandToInsert.Notes = brand.Notes;
            brandToInsert.IsActive = true;
            brandToInsert.CreateUserName = "ADMIN";
            brandToInsert.CreateDttm = DateTime.UtcNow;
            brandToInsert.UpdateUserName = "ADMIN";
            brandToInsert.UpdateDttm = DateTime.UtcNow;

            var insertBrand = _brandDataAccess.InsertNewBrand(brandToInsert);

            result = insertBrand;

            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="brand"></param>
        /// <returns></returns>
        public string UpdateBrandDetail(BrandModel brand)
        {
            Brand brandToUpdate = new Brand();

            brandToUpdate.Id = brand.Id;
            brandToUpdate.BrandName = brand.BrandName;
            brandToUpdate.Notes = brand.Notes;
            brandToUpdate.IsActive = true;
            brandToUpdate.UpdateUserName = "ADMIN";
            brandToUpdate.UpdateDttm = DateTime.UtcNow;

            string result = _brandDataAccess.UpdateBrandDetails(brandToUpdate);

            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public string DeleteBrand(int Id)
        {
            string result = _brandDataAccess.DeleteBrand(Id);
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="brandName"></param>
        /// <returns></returns>
        public List<BrandModel> SearchBrands(string brandName)
        {
            var result = _brandDataAccess.SearchBrands(brandName).Select(x => MapBrandToBrandModel(x)).ToList();

            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="brand"></param>
        /// <returns></returns>
        private BrandModel MapBrandToBrandModel(Brand brand)
        {
            return new BrandModel
            {
                Id = brand.Id,
                BrandName = brand.BrandName,
                Notes = brand.Notes,
                IsActive = brand.IsActive,
                CreateDttm = brand.CreateDttm,
                UpdateDttm = brand.UpdateDttm,
            };
        }
    }
}