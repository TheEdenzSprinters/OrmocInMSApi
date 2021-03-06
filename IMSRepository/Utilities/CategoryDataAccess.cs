﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMSRepository.Utilities
{
    public class CategoryDataAccess : ICategoryDataAccess
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<Category> GetCategories()
        {
            ////list<category> cats = new list<category>();

            using (OrmocIMSEntities context = new OrmocIMSEntities())
            {
                var cats = context.Categories.Where(x => x.IsActive == true).ToList();
                return cats;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cat"></param>
        /// <returns></returns>
        public Category InsertNewCategory(Category cat)
        {
            try
            {
                Category insertCat = new Category();

                insertCat.CategoryName = cat.CategoryName;
                insertCat.IsActive = cat.IsActive;
                insertCat.CreateUserName = cat.CreateUserName;
                insertCat.CreateDttm = cat.CreateDttm;
                insertCat.UpdateUserName = cat.UpdateUserName;
                insertCat.UpdateDttm = cat.UpdateDttm;

                using (OrmocIMSEntities context = new OrmocIMSEntities())
                {
                    context.Categories.Add(insertCat);
                    int result = context.SaveChanges();

                    return result > 0 ? insertCat : new Category();
                }
            }
            catch (Exception ex)
            {
                return new Category();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cat"></param>
        /// <returns></returns>
        public string UpdateCategoryDetails(Category cat)
        {
            try
            {
                using (OrmocIMSEntities context = new OrmocIMSEntities())
                {
                    Category updateCat = context.Categories.Where(x => x.Id == cat.Id && x.IsActive == true).FirstOrDefault();

                    if (updateCat == null)
                    {
                        return "No record found.";
                    }

                    updateCat.CategoryName = cat.CategoryName;
                    updateCat.IsActive = cat.IsActive;
                    updateCat.UpdateUserName = cat.UpdateUserName;
                    updateCat.UpdateDttm = cat.UpdateDttm;

                    context.Categories.Attach(updateCat);
                    context.Entry(updateCat).State = System.Data.Entity.EntityState.Modified;
                    int result = context.SaveChanges();

                    return result > 0 ? "Category updated." : "Error saving Category.";
                }
            }
            catch (Exception ex)
            {
                return "Internal error encountered.";
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="categoryId"></param>
        /// <returns></returns>
        public string DeleteCategory(int categoryId)
        {
            try
            {
                using (OrmocIMSEntities context = new OrmocIMSEntities())
                {
                    var selectedCat = context.Categories.Where(x => x.Id == categoryId && x.IsActive == true).FirstOrDefault();

                    if (selectedCat != null)
                    {
                        selectedCat.IsActive = false;
                        selectedCat.UpdateUserName = "ADMIN";
                        selectedCat.UpdateDttm = DateTime.UtcNow;

                        context.Categories.Attach(selectedCat);
                        context.Entry(selectedCat).State = System.Data.Entity.EntityState.Modified;
                        var result = context.SaveChanges();

                        if (result > 0)
                        {
                            return "Category deleted.";
                        }
                        else
                        {
                            return "Error encountered during save.";
                        }
                    }
                    else
                    {
                        return "No record found.";
                    }
                }
            }
            catch (Exception ex)
            {
                return "Internal error encountered.";
            }
        }
    }
}
