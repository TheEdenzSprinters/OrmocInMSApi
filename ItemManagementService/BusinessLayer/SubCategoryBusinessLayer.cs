using IMSRepository.Utilities;
using ItemManagementService.Interfaces;
using ItemManagementService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ItemManagementService.BusinessLayer
{
    public class SubCategoryBusinessLayer : ISubCategoryBusinessLayer
    {
        ISubCategoryDataAccess _subCategoryDataAccess;

        public SubCategoryBusinessLayer(ISubCategoryDataAccess subCategoryDataAccess)
        {
            _subCategoryDataAccess = subCategoryDataAccess;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<SubCategory> GetAllSubCategories()
        {
            List<SubCategory> result = new List<SubCategory>();
            SubCategory singleSub = new SubCategory();

            var subs = _subCategoryDataAccess.GetSubCategories();

            for(int i = 0; i < subs.Count; i++)
            {
                singleSub.Id = subs[i].Id;
                singleSub.CategoryId = subs[i].CategoryID;
                singleSub.SubCategoryName = subs[i].SubCategoryName;
                singleSub.IsActive = subs[i].IsActive;
                singleSub.CreateUserName = subs[i].CreateUserName;
                singleSub.CreateDttm = subs[i].CreateDttm;
                singleSub.UpdateUserName = subs[i].UpdateUserName;
                singleSub.UpdateDttm = subs[i].UpdateDttm;

                result.Add(singleSub);
            }

            return result;
        }

        public List<SubCategory> GetAllSubCategoriesByCategory(int CategoryId)
        {
            List<SubCategory> result = new List<SubCategory>();
            SubCategory singleSub = new SubCategory();


            var subs = _subCategoryDataAccess.GetSubCategoriesByCategory(CategoryId);

            for (int i = 0; i < subs.Count; i++)
            {
                singleSub.Id = subs[i].Id;
                singleSub.CategoryId = subs[i].CategoryID;
                singleSub.SubCategoryName = subs[i].SubCategoryName;
                singleSub.IsActive = subs[i].IsActive;
                singleSub.CreateUserName = subs[i].CreateUserName;
                singleSub.CreateDttm = subs[i].CreateDttm;
                singleSub.UpdateUserName = subs[i].UpdateUserName;
                singleSub.UpdateDttm = subs[i].UpdateDttm;

                result.Add(singleSub);
            }

            return result;
        }
    }
}