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
        public List<Brand> GetAllBrands()
        {
            List<Brand> result = new List<Brand>();
            Brand singleBrand = new Brand();

            var brands = _brandDataAccess.GetBrands();

            for (int i = 0; i < brands.Count; i++)
            {
                singleBrand.Id = brands[i].Id;
                singleBrand.BrandName = brands[i].BrandName;
                singleBrand.Notes = brands[i].Notes;
                singleBrand.IsActive = brands[i].IsActive;
                singleBrand.CreateUserName = brands[i].CreateUserName;
                singleBrand.CreateDttm = brands[i].CreateDttm;
                singleBrand.UpdateUserName = brands[i].UpdateUserName;
                singleBrand.UpdateDttm = brands[i].UpdateDttm;

                result.Add(singleBrand);
                singleBrand = new Brand();
            }

            return result;
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
        public string UpdateBrandDetail(BrandUpdateModel brand)
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


        public List<BrandModel> SearchBrands(string brandName)
        {
            List<BrandModel> result = new List<BrandModel>();
            BrandModel search = new BrandModel();

            var brands = _brandDataAccess.SearchBrands(brands);

            for (int i = 0; i < brands.Count; i++)
            {
                search.Id = brands[i].Id;
                search.BrandName = brands[i].BrandName;
                search.Notes = brands[i].Notes;
                search.IsActive = brands[i].IsActive;
                search.CreateDttm = brands[i].CreateDttm;

                result.Add(search);
                search = new BrandModel();
            }

            return result;
        }
    }
}