using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMSRepository.Utilities
{
    public class BrandDataAccess : IBrandDataAccess
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<Brand> GetBrands()
        {
            using (OrmocIMSEntities context = new OrmocIMSEntities())
            {
                var brands = context.Brands.ToList();
                return brands;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="brand"></param>
        /// <returns></returns>
        public Brand InsertNewBrand(Brand brand)
        {
            try
            {
                Brand insertBrand = new Brand();

                insertBrand.BrandName = brand.BrandName;
                insertBrand.Notes = brand.Notes;
                insertBrand.IsActive = brand.IsActive;
                insertBrand.CreateUserName = brand.CreateUserName;
                insertBrand.CreateDttm = brand.CreateDttm;
                insertBrand.UpdateUserName = brand.UpdateUserName;
                insertBrand.UpdateDttm = brand.UpdateDttm;

                using (OrmocIMSEntities context = new OrmocIMSEntities())
                {
                    context.Brands.Add(insertBrand);
                    int result = context.SaveChanges();

                    return result > 0 ? insertBrand : new Brand();
                }
            }
            catch (Exception ex)
            {
                return new Brand();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="brand"></param>
        /// <returns></returns>
        public string UpdateBrandDetails(Brand brand)
        {
            try
            {
                using (OrmocIMSEntities context = new OrmocIMSEntities())
                {
                    Brand updateBrand = context.Brands.Where(x => x.Id == brand.Id).FirstOrDefault();

                    if (updateBrand == null)
                    {
                        return "No record found.";
                    }

                    updateBrand.BrandName = brand.BrandName;
                    updateBrand.Notes = brand.Notes;
                    updateBrand.IsActive = brand.IsActive;
                    updateBrand.UpdateUserName = brand.UpdateUserName;
                    updateBrand.UpdateDttm = brand.UpdateDttm;

                    context.Brands.Attach(updateBrand);
                    context.Entry(updateBrand).State = System.Data.Entity.EntityState.Modified;
                    int result = context.SaveChanges();

                    return result > 0 ? "Brand updated." : "Error saving Brand.";
                }
            }
            catch
            {
                return "Internal error encountered.";
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="brandId"></param>
        /// <returns></returns>
        public string DeleteBrand(int brandId)
        {
            try
            {
                using (OrmocIMSEntities context = new OrmocIMSEntities())
                {
                    var selectedBrand = context.Brands.Where(x => x.Id == brandId && x.IsActive == true).FirstOrDefault();

                    if (selectedBrand != null)
                    {
                        selectedBrand.IsActive = false;
                        selectedBrand.UpdateUserName = "ADMIN";
                        selectedBrand.UpdateDttm = DateTime.UtcNow;

                        context.Brands.Attach(selectedBrand);
                        context.Entry(selectedBrand).State = System.Data.Entity.EntityState.Modified;
                        var result = context.SaveChanges();

                        if (result > 0)
                        {
                            return "Brand deleted.";
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="brandName"></param>
        /// <returns></returns>
        public List<Brand> SearchBrands(string brandName)
        {
            using (OrmocIMSEntities context = new OrmocIMSEntities())
            { 
                var search = context.Brands.Where(x => x.BrandName.Contains(brandName)).ToList();
                return search;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="brandName"></param>
        /// <returns></returns>
        public int GetBrandsCount(string brandName)
        {
            using (OrmocIMSEntities context = new OrmocIMSEntities())
            {
                var result = context.Brands.Where(x => x.BrandName.Contains(brandName)).Count();

                return result;
            }
        }

        public List<string> GetBrandNameList(string brandName)
        {
            using (OrmocIMSEntities context = new OrmocIMSEntities())
            {
                var result = context.Brands.Where(x => x.BrandName.Contains(brandName) && x.IsActive == true)
                    .Select(x => x.BrandName).Take(10).ToList();

                return result;
            }
        }
    }
}
