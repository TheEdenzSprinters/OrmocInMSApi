using System;
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
            List<Category> cats = new List<Category>();

            using(OrmocIMSEntities context = new OrmocIMSEntities())
            {
                cats = context.Categories.Where(x => x.IsActive == true).ToList();
                return cats;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cat"></param>
        /// <returns></returns>
        public string InsertNewCategory(Category cat)
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

                    return result > 0 ? "Category successfully added." : "No Category added.";
                }
            }
            catch(Exception ex)
            {
                return "Error while saving Category.";
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
                using (OrmocIMSEntities contex = new OrmocIMSEntities())
                {
                    Category updateCat = contex.Categories.Where(x => x.Id == cat.Id && x.IsActive == true).FirstOrDefault();

                    if(updateCat == null)
                    {
                        return "No record found.";
                    }

                    updateCat.CategoryName = cat.CategoryName;
                    updateCat.IsActive = cat.IsActive;
                    updateCat.CreateUserName = cat.CreateUserName;
                    updateCat.CreateDttm = cat.CreateDttm;
                    updateCat.UpdateUserName = cat.UpdateUserName;
                    updateCat.UpdateDttm = cat.UpdateDttm;

                    contex.Categories.Attach(updateCat);
                    contex.Entry(updateCat).State = System.Data.Entity.EntityState.Modified;
                    int result = contex.SaveChanges();

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

                    if(selectedCat != null)
                    {
                        selectedCat.IsActive = false;
                        selectedCat.UpdateUserName = "ADMIN";
                        selectedCat.UpdateDttm = DateTime.UtcNow;

                        context.Categories.Attach(selectedCat);
                        context.Entry(selectedCat).State = System.Data.Entity.EntityState.Modified;
                        var result = context.SaveChanges();

                        if(result > 0)
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
            catch(Exception ex)
            {
                return "Internal error encountered.";
            }
        }
    }
}
