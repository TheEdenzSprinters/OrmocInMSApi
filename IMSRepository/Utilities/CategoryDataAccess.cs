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
            }

            return cats;
        }
    }
}
