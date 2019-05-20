using IMSRepository.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMSRepository.Utilities
{
    public class SupplierDataAccess : ISupplierDataAccess
    {
        public List<Supplier> GetAllSuppliers()
        {
            using (OrmocIMSEntities context = new OrmocIMSEntities())
            {
                var supps = context.Suppliers.Where(x => x.IsActive == true).ToList();
                return supps;
            }
        }

        public string CreateNewSupplier(Supplier sup)
        {
            try
            {
                Supplier createsup = new Supplier();

                createsup.SupplierName = sup.SupplierName;
                createsup.SupplierAddress = sup.SupplierAddress;
                createsup.TelephoneNumber = sup.TelephoneNumber;
                createsup.Email = sup.Email;
                createsup.Notes = sup.Notes;
                createsup.IsActive = sup.IsActive;

                using (OrmocIMSEntities context = new OrmocIMSEntities())
                {
                    context.Suppliers.Add(createsup);
                    int result = context.SaveChanges();

                    return result > 0 ? "Supplier successfully added." : "No Supplier added.";
                }
            }
            catch (Exception ex)
            {
                return "Error while saving Supplier.";
            }
        }

        public List<SupplierSearchResult> SuppliersSearch(string supplierName)
        {
            using (OrmocIMSEntities context = new OrmocIMSEntities())
            {
                var result = context.Suppliers.Include("Name").Where(x => x.SupplierName.Contains(supplierName))
                    .Select(x => new SupplierSearchResult
                    {
                        Id = x.Id,
                        SupplierName = x.SupplierName,                                            
                        
                    }).ToList();

                return result;
            }
        }

        public string UpdateSupplier(Supplier sup)
        {
            try
            {
                using (OrmocIMSEntities context = new OrmocIMSEntities())
                {
                    Supplier updateSup = context.Suppliers.Where(x => x.Id == sup.Id && x.IsActive == true).FirstOrDefault();

                    if (updateSup == null)
                    {
                        return "No record found.";
                    }

                    updateSup.SupplierName = sup.SupplierName;
                    updateSup.IsActive = sup.IsActive;
                    updateSup.UpdateUserName = sup.UpdateUserName;
                    updateSup.UpdateDttm = sup.UpdateDttm;

                    context.Suppliers.Attach(updateSup);
                    context.Entry(updateSup).State = System.Data.Entity.EntityState.Modified;
                    int result = context.SaveChanges();

                    return result > 0 ? "Supplier updated." : "Error saving Supplier.";
                }
            }
            catch (Exception ex)
            {
                return "Internal error encountered.";
            }
        }

        public Supplier ViewSupplierById(int SupplierId)
        {
            using (OrmocIMSEntities context = new OrmocIMSEntities())
            {
                var sups = context.Suppliers.Where(x => x.SupplierID == SupplierId && x.IsActive == true).FirstOrDefault();
                return sups;
            }
        }

        public string DeleteSupplier(int supplierId)
        {
            try
            {
                using (OrmocIMSEntities context = new OrmocIMSEntities())
                {
                    var selectedSupplier = context.Suppliers.Where(x => x.Id == supplierId && x.IsActive == true).FirstOrDefault();

                    if (selectedSupplier != null)
                    {
                        selectedSupplier.IsActive = false;
                        selectedSupplier.UpdateUserName = "ADMIN";
                        selectedSupplier.UpdateDttm = DateTime.UtcNow;

                        context.Suppliers.Attach(selectedSupplier);
                        context.Entry(selectedSupplier).State = System.Data.Entity.EntityState.Modified;
                        var result = context.SaveChanges();

                        if (result > 0)
                        {
                            return "Supplier deleted.";
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
            catch (Exception)
            {
                return "Internal error encountered.";
            }
        }

    }
}
