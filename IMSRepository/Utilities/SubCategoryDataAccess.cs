using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMSRepository.Utilities
{
    public class SubCategoryDataAccess : ISubCategoryDataAccess
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<SubCategory> GetSubCategories()
        {
            using (OrmocIMSEntities context = new OrmocIMSEntities())
            {
                var subs = context.SubCategories.Where(x => x.IsActive == true).ToList();
                return subs;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="categoryId"></param>
        /// <returns></returns>
        public List<SubCategory> GetSubCategoriesByCategory(int categoryId)
        {
            using (OrmocIMSEntities context = new OrmocIMSEntities())
            {
                var subs = context.SubCategories.Where(x => x.CategoryID == categoryId && x.IsActive == true).ToList();
                return subs;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sub"></param>
        /// <returns></returns>
        public SubCategory InsertNewSubCategory(SubCategory sub)
        {
            try
            {
                SubCategory insertSub = new SubCategory();

                insertSub.CategoryID = sub.CategoryID;
                insertSub.SubCategoryName = sub.SubCategoryName;
                insertSub.IsActive = sub.IsActive;
                insertSub.CreateUserName = sub.CreateUserName;
                insertSub.CreateDttm = sub.CreateDttm;
                insertSub.UpdateUserName = sub.UpdateUserName;
                insertSub.UpdateDttm = sub.UpdateDttm;

                using (OrmocIMSEntities context = new OrmocIMSEntities())
                {
                    context.SubCategories.Add(insertSub);
                    int result = context.SaveChanges();

                    return result > 0 ? insertSub : new SubCategory();
                }
            }
            catch (Exception ex)
            {
                return new SubCategory();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sub"></param>
        /// <returns></returns>
        public string UpdateSubCategoryDetails(SubCategory sub)
        {
            try
            {
                using (OrmocIMSEntities context = new OrmocIMSEntities())
                {
                    var updateSub = context.SubCategories.Where(x => x.Id == sub.Id && x.IsActive == true).FirstOrDefault();

                    if (updateSub == null)
                    {
                        return "No record found.";
                    }

                    updateSub.CategoryID = sub.CategoryID;
                    updateSub.SubCategoryName = sub.SubCategoryName;
                    updateSub.IsActive = sub.IsActive;
                    updateSub.UpdateUserName = sub.UpdateUserName;
                    updateSub.UpdateDttm = sub.UpdateDttm;

                    context.SubCategories.Attach(updateSub);
                    context.Entry(updateSub).State = EntityState.Modified;
                    int result = context.SaveChanges();

                    return result > 0 ? "SubCategory updated." : "Error saving SubCategory.";
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
        /// <param name="subCategoryId"></param>
        /// <returns></returns>
        public string DeleteSubCategory(int subCategoryId)
        {
            try
            {
                using (OrmocIMSEntities context = new OrmocIMSEntities())
                {
                    var selectedSub = context.SubCategories.Where(x => x.Id == subCategoryId && x.IsActive == true).FirstOrDefault();

                    if (selectedSub != null)
                    {
                        selectedSub.IsActive = false;
                        selectedSub.UpdateUserName = "ADMIN";
                        selectedSub.UpdateDttm = DateTime.UtcNow;

                        context.SubCategories.Attach(selectedSub);
                        context.Entry(selectedSub).State = EntityState.Modified;
                        var result = context.SaveChanges();

                        if (result > 0)
                        {
                            return "SubCategory deleted.";
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
