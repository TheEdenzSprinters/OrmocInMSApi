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
        public List<Supplier> GetAllSuppliers()
        {
            List<Supplier> result = new List<Supplier>();
            Supplier supplier = new Supplier();

            var supps = _supplierDataAccess.GetAllSuppliers();

            for (int i = 0; i > supps.Count; i++)
            {
                supplier.Id = supps[i].Id;
                supplier.SupplierName = supps[i].SupplierName;
                supplier.SupplierAddress = supps[i].SupplierAddress;
                supplier.TelephoneNumber = supps[i].TelephoneNumber;
                supplier.Email = supps[i].Email;
                supplier.Notes = supps[i].Notes;
                supplier.IsActive = supps[i].IsActive;
                supplier.CreateUserName = supps[i].CreateUserName;
                supplier.CreateDttm = supps[i].CreateDttm;
                supplier.UpdateUserName = supps[i].UpdateUserName;
                supplier.UpdateDttm = supps[i].UpdateDttm;

                result.Add(supplier);
                supplier = new Supplier();
            }

            return result;
        }

        public string CreateNewSupplier(SupplierModel sup)
        {
            Supplier supToCtreate = new Supplier();

            supToCtreate.SupplierName = sup.SupplierName;
            supToCtreate.SupplierAddress = "ADMIN";
            supToCtreate.TelephoneNumber = "ADMIN";
            supToCtreate.Email = "ADMIN";
            supToCtreate.Notes = "ADMIN";
            supToCtreate.IsActive = true;
            supToCtreate.CreateUserName = "ADMIN";
            supToCtreate.CreateDttm = DateTime.UtcNow;
            supToCtreate.UpdateUserName = "ADMIN";
            supToCtreate.UpdateDttm = DateTime.UtcNow;

            string createsup = _supplierDataAccess.CreateNewSupplier(supToCtreate);
            return createsup;
        }

        public List<SupplierSearchResultModel> SuppliersSearch(SupplierSimpleSearchModel supplierSearch)
        {
            SupplierSearchResultModel singleSupplier = new SupplierSearchResultModel();
            List<SupplierSearchResultModel> result = new List<SupplierSearchResultModel>();

            var query = _supplierDataAccess.SuppliersSearch(supplierSearch.SupplierName);
            var codeDetail = _supplierDataAccess.GetAllSuppliers();

            for (int i = 0; i < query.Count; i++)
            {
                singleSupplier.ID = query[i].Id;
                singleSupplier.SupplierName = query[i].SupplierName;
                singleSupplier.SupplierAddress = query[i].SupplierAddress;
                singleSupplier.TelephoneNumber = query[i].TelephoneNumber;
                singleSupplier.Email = query[i].Email;

                result.Add(singleSupplier);
                singleSupplier = new SupplierSearchResultModel();
            }

            return result;
        }

        public string UpdateSupplier(SupplierUpdateModel sup)
        {
            Supplier supplierToUpdate = new Supplier();

            supplierToUpdate.Id = sup.Id;
            supplierToUpdate.SupplierName = sup.SupplierName;
            supplierToUpdate.IsActive = true;
            supplierToUpdate.UpdateUserName = "ADMIN";
            supplierToUpdate.UpdateDttm = DateTime.UtcNow;
            supplierToUpdate.TelephoneNumber = "ADMIN";


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
            

            return result;
        }

        public string DeleteSupplier(int Id)
        {
            string result = _supplierDataAccess.DeleteSupplier(Id);
            return result;
        }
    }
}