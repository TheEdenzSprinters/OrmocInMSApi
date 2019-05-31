using IMSRepository;
using IMSRepository.Models;
using IMSRepository.Utilities;
using ItemManagementService.Interfaces;
using ItemManagementService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ItemManagementService.BusinessLayer
{
    public class SupplierBusinessLayer : ISupplierBusinessLayer
    {
        readonly ISupplierDataAccess _supplierDataAccess;

        public SupplierBusinessLayer(ISupplierDataAccess supplierDataAccess)
        {
            _supplierDataAccess = supplierDataAccess;
        }
        public List<SupplierModel> GetSuppliers()
        {
            return _supplierDataAccess.GetSuppliers().Select(x => MapSupplierToSupplierModel(x)).ToList();

        }

        private SupplierModel MapSupplierToSupplierModel(Supplier supplier)
        {
            return new SupplierModel
            {
                Id = supplier.Id,
                SupplierName = supplier.SupplierName,
                SupplierAddress = supplier.SupplierAddress,
                TelephoneNumber = supplier.TelephoneNumber,
                Email = supplier.Email,
                Notes = supplier.Notes,
                IsActive = supplier.IsActive,
                CreateUserName = supplier.CreateUserName,
                UpdateUserName = supplier.UpdateUserName,
                CreateDttm = supplier.CreateDttm,
                UpdateDttm = supplier.UpdateDttm,
            };
        }


        public Supplier CreateNewSupplier(SupplierModel sup)
        {
            Supplier supToCtreate = new Supplier();

            supToCtreate.SupplierName = sup.SupplierName;
            supToCtreate.SupplierAddress = sup.SupplierAddress;
            supToCtreate.TelephoneNumber = sup.TelephoneNumber;
            supToCtreate.Email = sup.Email;
            supToCtreate.Notes = sup.Notes;
            supToCtreate.IsActive = true;
            supToCtreate.CreateUserName = "ADMIN";
            supToCtreate.CreateDttm = DateTime.UtcNow;
            supToCtreate.UpdateUserName = "ADMIN";
            supToCtreate.UpdateDttm = DateTime.UtcNow;

            var createsup = _supplierDataAccess.CreateNewSupplier(supToCtreate);
            return createsup;
        }

        public List<SupplierModel> SuppliersSearch(SupplierSimpleSearchModel sup)
        {
            SupplierSearchModel query = new SupplierSearchModel();
            query.SupplierName = sup.SupplierName;
            query.SupplierAddress = sup.SupplierAddress;
            var result = _supplierDataAccess.SuppliersSearch(query).Select(x => MapSupplierToSupplierModel(x)).ToList();

            return result;
        }

        public string UpdateSupplier(SupplierUpdateModel sup)
        {
            Supplier supplierToUpdate = new Supplier();

            supplierToUpdate.Id = sup.Id;
            supplierToUpdate.SupplierName = sup.SupplierName;
            supplierToUpdate.SupplierAddress = sup.SupplierAddress;
            supplierToUpdate.Email = sup.Email;
            supplierToUpdate.Notes = sup.Notes;
            supplierToUpdate.IsActive = sup.Status.Equals("active") ? true : false;
            supplierToUpdate.UpdateUserName = "ADMIN";
            supplierToUpdate.UpdateDttm = DateTime.UtcNow;
            supplierToUpdate.TelephoneNumber = sup.TelephoneNumber;

            string result = _supplierDataAccess.UpdateSupplier(supplierToUpdate);

            return result;
        }

        public SupplierSingleModel ViewSupplierById(int SupplierId)
        {
            SupplierSingleModel result = new SupplierSingleModel();
            SupplierSingleModel singleSup = new SupplierSingleModel();

            var sups = _supplierDataAccess.ViewSupplierById(SupplierId);

            result.Id = sups.Id;
            result.SupplierName = sups.SupplierName;
            result.SupplierAddress = sups.SupplierAddress;
            result.Notes = sups.Notes;
            result.TelephoneNumber = sups.TelephoneNumber;
            result.UpdateDttm = sups.UpdateDttm;
            result.UpdateUserName = sups.UpdateUserName;
            result.CreateDttm = sups.CreateDttm;
            result.CreateUserName = sups.CreateUserName;
            result.Email = sups.Email;
            result.Status = sups.IsActive ? "active" : "inactive";

            return result;
        }
    }
}