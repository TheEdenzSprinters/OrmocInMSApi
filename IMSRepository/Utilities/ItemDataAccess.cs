using IMSRepository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMSRepository.Utilities
{
    public class ItemDataAccess : IItemDataAccess
    {
        public Item GetItemById(int id)
        {
            using (OrmocIMSEntities context = new OrmocIMSEntities())
            {
                var result = context.Items.Include("Category").Include("SubCategory")
                    .Include("Location").Include("Brand").Where(x => x.Id == id && x.IsActive == true).FirstOrDefault();

                return result;
            }
        }

        public List<ItemSearchResult> AdvancedSearchItems(ItemSearchModel item)
        {
            using (OrmocIMSEntities context = new OrmocIMSEntities())
            {
                var result = context.AdvancedSearch_SP(item.ModuleName, item.Id.HasValue ? item.Id.Value.ToString() : null,
                    null, string.IsNullOrEmpty(item.ItemName) ? null : item.ItemName,
                    string.IsNullOrEmpty(item.Brand) ? null : item.Brand,
                    item.CategoryId.HasValue ? item.CategoryId.Value.ToString() : null,
                    item.SubCategoryId.HasValue ? item.SubCategoryId.Value.ToString() : null,
                    item.Location.HasValue ? item.Location.Value.ToString() : null,
                    string.IsNullOrEmpty(item.Tag) ? null : item.Tag,
                    string.IsNullOrEmpty(item.Sku) ? null : item.Sku)
                    .Select(x => new ItemSearchResult
                    {
                        Id = x.Id,
                        ItemName = x.ItemName,
                        Brand = x.BrandName,
                        Status = x.IsActive == true ? "Active" : "Inactive",
                        CreateDttm = x.CreateDttm
                    }).ToList();

                return result;
            }
        }

        public List<string> ItemAutoComplete(string word)
        {
            using(OrmocIMSEntities context = new OrmocIMSEntities())
            {
                var result = context.Items.Where(x => x.ItemName.Contains(word)).Select(x => x.ItemName).Take(10).ToList();
                return result;
            }
        }
    }
}
