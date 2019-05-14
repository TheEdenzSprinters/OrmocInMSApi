using IMSRepository.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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
                    .Include("Location").Include("Brand").Include("CodeDetail")
                    .Where(x => x.Id == id).FirstOrDefault();

                return result;
            }
        }

        public List<ItemSearchResult> AdvancedSearchItems(ItemSearchModel item)
        {
            using (OrmocIMSEntities context = new OrmocIMSEntities())
            {
                var result = context.ItemAdvancedSearch_SP(item.ModuleName, item.Id.HasValue ? item.Id.Value.ToString() : null,
                    null, string.IsNullOrEmpty(item.ItemName) ? null : item.ItemName,
                    string.IsNullOrEmpty(item.Brand) ? null : item.Brand,
                    item.CategoryId.HasValue ? item.CategoryId.Value.ToString() : null,
                    item.SubCategoryId.HasValue ? item.SubCategoryId.Value.ToString() : null,
                    item.Location.HasValue ? item.Location.Value.ToString() : null,
                    string.IsNullOrEmpty(item.Tag) ? null : item.Tag,
                    string.IsNullOrEmpty(item.Sku) ? null : item.Sku,
                    item.StatusCd.HasValue ? item.StatusCd.Value.ToString() : null
                    )
                    .Select(x => new ItemSearchResult
                    {
                        Id = x.Id,
                        ItemName = x.ItemName,
                        Brand = x.BrandName,
                        Status = x.StatusCd,
                        CreateDttm = x.CreateDttm
                    }).ToList();

                return result;
            }
        }

        public List<string> ItemAutoComplete(string word)
        {
            using (OrmocIMSEntities context = new OrmocIMSEntities())
            {
                var result = context.Items.Where(x => x.ItemName.Contains(word)).Select(x => x.ItemName).Distinct().Take(10).ToList();
                return result;
            }
        }

        public List<Location> GetAllLocations()
        {
            using (OrmocIMSEntities context = new OrmocIMSEntities())
            {
                var result = context.Locations.Where(x => x.IsActive == true).ToList();
                return result;
            }
        }

        public List<CodeDetail> GetAllItemStatus()
        {
            using (OrmocIMSEntities context = new OrmocIMSEntities())
            {
                int CodeHeaderId = context.CodeHeaders
                    .Where(x => x.CodeHeaderName.Equals("item status") && x.IsActive == true).
                    Select(x => x.Id).FirstOrDefault();

                var result = context.CodeDetails.Where(x => x.CodeHeaderId == CodeHeaderId && x.IsActive == true)
                    .ToList();

                return result;
            }
        }

        public List<ItemDetailMapping> GetItemDetailByItemId(int itemId)
        {
            using (OrmocIMSEntities context = new OrmocIMSEntities())
            {
                var result = context.ItemDetailMappings.Include("ItemDetail")
                    .Where(x => x.ItemID == itemId).ToList();

                return result;
            }
        }

        public List<UnitsOfMeasure> GetItemUnitsOfMeasure(List<ItemDetailMapping> item)
        {
            using (OrmocIMSEntities context = new OrmocIMSEntities())
            {
                var itemDetailID = item.Select(x => x.ItemDetailID).ToList();
                var result = context.UnitsOfMeasures.Where(x => itemDetailID.Contains(x.Id) && x.IsActive == true).ToList();

                return result;
            }
        }

        public List<ItemDetail> GetItemDetailBySubCategoryId(int id)
        {
            using (OrmocIMSEntities context = new OrmocIMSEntities())
            {
                var result = context.ItemDetails.Include("UnitsOfMeasure")
                    .Where(x => x.SubCategoryID == id && x.IsActive == true).ToList();

                return result;
            }
        }

        public Item InsertNewItem(Item item)
        {
            using (OrmocIMSEntities context = new OrmocIMSEntities())
            {
                context.Items.Add(item);
                context.Entry(item).State = EntityState.Added;
                int result = context.SaveChanges();

                return result > 0 ? item : new Item();
            }
        }

        public bool InsertNewItemDetailMapping(List<ItemDetailMapping> itemDetail)
        {
            using (OrmocIMSEntities context = new OrmocIMSEntities())
            {
                int result = 0;

                for (int i = 0; i < itemDetail.Count; i++)
                {
                    context.ItemDetailMappings.Add(itemDetail[i]);
                    context.Entry(itemDetail[i]).State = EntityState.Added;
                    result = result + context.SaveChanges();
                }

                return result == itemDetail.Count ? true : false;
            }
        }

        public bool UpdateItemStatusById(int id, string StatusCd)
        {
            using (OrmocIMSEntities context = new OrmocIMSEntities())
            {
                var item = context.Items.Where(x => x.Id == id).FirstOrDefault();
                var codeDetail = context.CodeDetails.Where(x => x.CodeValue.ToLower().Equals(StatusCd)).FirstOrDefault();

                item.StatusCd = codeDetail.Id;
                item.UpdateUserName = "ADMIN";
                item.UpdateDttm = DateTime.UtcNow;

                context.Entry(item).State = EntityState.Modified;
                int result = context.SaveChanges();

                return result > 0 ? true : false;
            }
        }

        public bool UpdateItemById(Item item)
        {
            using (OrmocIMSEntities context = new OrmocIMSEntities())
            {
                var query = context.Items.Where(x => x.Id == item.Id).FirstOrDefault();

                if(query != null)
                {
                    query.ItemName = item.ItemName;
                    query.LocationID = item.LocationID;
                    query.CategoryID = item.CategoryID;
                    query.SubCategoryID = item.SubCategoryID;
                    query.BrandID = item.BrandID;
                    query.Quantity = item.Quantity;
                    query.MeasuredBy = item.MeasuredBy;
                    query.ThresholdQty = item.ThresholdQty;
                    query.Sku = item.Sku;
                    query.Notes = item.Notes;
                    query.UpdateUserName = item.UpdateUserName;
                    query.UpdateDttm = item.UpdateDttm;

                    //for(int i = 0; i < query.ItemDetailMappings.Count; i++)
                    //{
                    //    query.ItemDetailMappings = item.ItemDetailMappings;
                    //}
                    
                    context.Entry(query).State = EntityState.Modified;
                    int result = context.SaveChanges();

                    return result > 0 ? true : false;
                }
            }

            return false;
        }

        public bool UpdateItemDetailMappingByItemId(ItemDetailMapping item)
        {
            using (OrmocIMSEntities context = new OrmocIMSEntities())
            {
                int result = 0;
                
                int itemDetailMappingId = item.Id;

                var query = context.ItemDetailMappings.Where(x => x.Id == itemDetailMappingId).FirstOrDefault();

                query.ItemDetailValue = item.ItemDetailValue;
                query.IsActive = item.IsActive;
                query.UpdateUserName = item.UpdateUserName;
                query.UpdateDttm = item.UpdateDttm;

                context.Entry(query).State = EntityState.Modified;
                result = result + context.SaveChanges();

                return result > 0 ? true : false;
            }
        }

        public bool RemoveTaggingByItemId(int itemId, int tagId)
        {
            int result = 0;

            using (OrmocIMSEntities context = new OrmocIMSEntities())
            {
                var query = context.TagsMappings.Where(x => x.ItemID == itemId && x.TagID == tagId).FirstOrDefault();

                if(query != null)
                {
                    query.IsActive = false;
                    query.UpdateUserName = "ADMIN";
                    query.UpdateDttm = DateTime.UtcNow;

                    context.Entry(query).State = EntityState.Modified;
                    result = context.SaveChanges();

                    return result > 0 ? true : false;
                }
            }

            return false;
        }

        public int AddNewTag(Tag tag)
        {
            Tag newTag = new Tag();

            using (OrmocIMSEntities context = new OrmocIMSEntities())
            {
                int result = 0;
                var query = context.Tags.Where(x => x.TagValue.Equals(tag.TagValue)).FirstOrDefault();
                
                if(query == null)
                {
                    newTag.TagValue = tag.TagValue;
                    newTag.CreateUserName = "ADMIN";
                    newTag.CreateDttm = DateTime.UtcNow;
                    newTag.UpdateUserName = "ADMIN";
                    newTag.UpdateDttm = DateTime.UtcNow;

                    context.Tags.Add(newTag);
                    context.Entry(newTag).State = EntityState.Added;
                    result = context.SaveChanges();

                    return result > 0 ? newTag.Id : 0;
                }
                else
                {
                    return query.Id;
                }
            }

            return 0;
        }

        public bool AddTaggingByItemId(int tagId, int itemId)
        {
            TagsMapping newTag = new TagsMapping();
            int result = 0;

            using (OrmocIMSEntities context = new OrmocIMSEntities())
            {
                var query = context.TagsMappings.Where(x => x.TagID == tagId && x.ItemID == itemId).FirstOrDefault();

                if (query == null)
                {
                    newTag.TagID = tagId;
                    newTag.ItemID = itemId;
                    newTag.IsActive = true;
                    newTag.CreateUserName = "ADMIN";
                    newTag.CreateDttm = DateTime.UtcNow;
                    newTag.UpdateUserName = "ADMIN";
                    newTag.UpdateDttm = DateTime.UtcNow;

                    context.Entry(newTag).State = EntityState.Added;
                    result = context.SaveChanges();

                    return result > 0 ? true : false;
                }
                else
                {
                    query.IsActive = true;
                    query.UpdateUserName = "ADMIN";
                    query.UpdateDttm = DateTime.UtcNow;

                    context.Entry(query).State = EntityState.Modified;
                    result = context.SaveChanges();

                    return result > 0 ? true : false;
                }
            }
        }

        public List<Tag> TagsAutoComplete(string word)
        {
            using (OrmocIMSEntities context = new OrmocIMSEntities())
            {
                var result = context.Tags.Where(x => x.TagValue.Contains(word)).Take(10).ToList();
                return result;
            }
        }

        public List<ItemSearchResult> SimpleSearchItems(string itemName)
        {
            using (OrmocIMSEntities context = new OrmocIMSEntities())
            {
                var result = context.Items.Include("Brands").Where(x => x.ItemName.Contains(itemName))
                    .Select(x => new ItemSearchResult
                    {
                        Id = x.Id,
                        ItemName = x.ItemName,
                        Brand = x.Brand.BrandName,
                        Status = x.StatusCd,
                        CreateDttm = x.CreateDttm
                    }).ToList();

                    return result;
            }
        }

        public Brand GetBrandByName(string brandName)
        {
            using (OrmocIMSEntities context = new OrmocIMSEntities())
            {
                var result = context.Brands.Where(x => x.BrandName.Contains(brandName)).FirstOrDefault();

                return result;
            }
        }
    }
}
