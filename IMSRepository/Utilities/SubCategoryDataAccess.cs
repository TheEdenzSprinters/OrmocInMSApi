using System;
using System.Collections.Generic;
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
        public string InsertNewSubCategory(SubCategory sub)
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

                    return result > 0 ? "SubCategory successfully added." : "No SubCategory added.";
                }
            }
            catch(Exception ex)
            {
                return "Error while saving SubCategory.";
            }
        }
    }
}
