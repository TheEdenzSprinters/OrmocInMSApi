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
            List<SubCategory> subs = new List<SubCategory>();

            using(OrmocIMSEntities context = new OrmocIMSEntities())
            {
                subs = context.SubCategories.Where(x => x.IsActive == true).ToList();
            }

            return subs;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="categoryId"></param>
        /// <returns></returns>
        public List<SubCategory> GetSubCategoriesByCategory(int categoryId)
        {
            List<SubCategory> subs = new List<SubCategory>();

            using(OrmocIMSEntities context = new OrmocIMSEntities())
            {
                subs = context.SubCategories.Where(x => x.CategoryID == categoryId && x.IsActive == true).ToList();
            }

            return subs;
        }
    }
}
