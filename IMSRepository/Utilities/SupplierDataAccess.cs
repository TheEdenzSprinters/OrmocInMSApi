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
        public List<Supplier> GetSuppliers()
        {
            using (OrmocIMSEntities context = new OrmocIMSEntities())
            {
                var suppliers = context.Suppliers.ToList();
                return suppliers;
            }
        }

        public Supplier CreateNewSupplier(Supplier sup)
        {
            try
            {
                Supplier createSupplier = new Supplier();

                createSupplier.SupplierName = sup.SupplierName;
                createSupplier.SupplierAddress = sup.SupplierAddress;
                createSupplier.TelephoneNumber = sup.TelephoneNumber;
                createSupplier.Email = sup.Email;
                createSupplier.Notes = sup.Notes;
                createSupplier.IsActive = sup.IsActive;
                createSupplier.CreateUserName = sup.CreateUserName;
                createSupplier.CreateDttm = sup.CreateDttm;
                createSupplier.UpdateDttm = sup.UpdateDttm;
                createSupplier.UpdateUserName = sup.UpdateUserName;

                using (OrmocIMSEntities context = new OrmocIMSEntities())
                {
                    context.Suppliers.Add(createSupplier);
                    int result = context.SaveChanges();

                    return result > 0 ? createSupplier : new Supplier();
                }
            }
            catch (Exception ex)
            {
                return new Supplier();
            }
        }

        public List<Supplier> SuppliersSearch(SupplierSearchModel sup)
        {
            using (OrmocIMSEntities context = new OrmocIMSEntities())
            {
                var search = context.Suppliers.Where(x => (x.SupplierName.Contains(sup.SupplierName) || sup.SupplierName == null) && (x.SupplierAddress.Contains(sup.SupplierAddress) || sup.SupplierAddress == null)).ToList();

                return search;
            }
        }

        public string UpdateSupplier(Supplier sup)
        {
            try
            {
                using (OrmocIMSEntities context = new OrmocIMSEntities())
                {
                    var updateSup = context.Suppliers.Where(x => x.Id == sup.Id).FirstOrDefault();

                    if (updateSup == null)
                    {
                        return "No record found.";
                    }

                    updateSup.SupplierName = sup.SupplierName;
                    updateSup.IsActive = sup.IsActive;
                    updateSup.UpdateUserName = sup.UpdateUserName;
                    updateSup.UpdateDttm = sup.UpdateDttm;
                    updateSup.TelephoneNumber = sup.TelephoneNumber;
                    updateSup.Notes = sup.Notes;
                    updateSup.Email = sup.Email;
                    updateSup.SupplierAddress = sup.SupplierAddress;

                    context.Suppliers.Attach(updateSup);
                    context.Entry(updateSup).State = EntityState.Modified;
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
                var sups = context.Suppliers.Where(x => x.Id == SupplierId).FirstOrDefault();
                return sups;
            }
        }
    }
}
