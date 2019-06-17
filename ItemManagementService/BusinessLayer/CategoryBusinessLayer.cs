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
    public class CategoryBusinessLayer : ICategoryBusinessLayer
    {
        readonly ICategoryDataAccess _CategoryDataAccess;

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
                singleCat = new Category();
            }

            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cat"></param>
        /// <returns></returns>
        public InsertCategoryResultModel InsertNewCategory(CategoryModel cat)
        {
            Category catToInsert = new Category();
            InsertCategoryResultModel result = new InsertCategoryResultModel();

            if(cat == null)
            {
                result.IsSuccess = false;
                result.Message = "Input is null.";
                return result;
            }
            else if (string.IsNullOrEmpty(cat.CategoryName))
            {
                result.IsSuccess = false;
                result.Message = "Category Name should not be blank.";
                return result;
            }
            else
            {
                catToInsert.CategoryName = cat.CategoryName;
                catToInsert.IsActive = true;
                catToInsert.CreateUserName = "ADMIN";
                catToInsert.CreateDttm = DateTime.UtcNow;
                catToInsert.UpdateUserName = "ADMIN";
                catToInsert.UpdateDttm = DateTime.UtcNow;

                var query = _CategoryDataAccess.InsertNewCategory(catToInsert);

                result.IsSuccess = true;
                result.NewCategory = query;
                result.Message = "Success";

                return result;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cat"></param>
        /// <returns></returns>
        public string UpdateCategoryDetail(CategoryUpdateModel cat)
        {
            Category catToUpdate = new Category();
            string result;

            if (cat == null)
            {
                result = "Input is null.";
                return result;
            }
            else if (string.IsNullOrEmpty(cat.CategoryName))
            {
                result = "Category Name should not be blank.";
                return result;
            }
            else
            {
                catToUpdate.Id = cat.Id;
                catToUpdate.CategoryName = cat.CategoryName;
                catToUpdate.IsActive = true;
                catToUpdate.UpdateUserName = "ADMIN";
                catToUpdate.UpdateDttm = DateTime.UtcNow;

                result = _CategoryDataAccess.UpdateCategoryDetails(catToUpdate);

                return result;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public string DeleteCategory(int Id)
        {
            string result = _CategoryDataAccess.DeleteCategory(Id);
            return result;
        }
    }
}