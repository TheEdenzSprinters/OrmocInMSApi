using IMSRepository.Utilities;
using ItemManagementService.Interfaces;
using ItemManagementService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ItemManagementService.BusinessLayer
{
    public class CategoryBusinessLayer : ICategoryBusinessLayer
    {
        ICategoryDataAccess _CategoryDataAccess;

        public CategoryBusinessLayer(ICategoryDataAccess CategoryDataAccess)
        {
            _CategoryDataAccess = CategoryDataAccess;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<Category> GetAllCategories()
        {
            List<Category> result = new List<Category>();
            Category singleCat = new Category();

            var cats = _CategoryDataAccess.GetCategories();

            for(int i = 0; i < cats.Count; i++)
            {
                singleCat.Id = cats[i].Id;
                singleCat.CategoryName = cats[i].CategoryName;
                singleCat.IsActive = cats[i].IsActive;
                singleCat.CreateUserName = cats[i].CreateUserName;
                singleCat.CreateDttm = cats[i].CreateDttm;
                singleCat.UpdateUserName = cats[i].UpdateUserName;
                singleCat.UpdateDttm = cats[i].UpdateDttm;

                result.Add(singleCat);
            }

            return result;
        }
    }
}