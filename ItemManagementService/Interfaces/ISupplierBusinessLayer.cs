using IMSRepository;
using ItemManagementService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ItemManagementService.Interfaces
{
    public interface ISupplierBusinessLayer
    {
        List<SupplierModel> GetSuppliers();
        Supplier CreateNewSupplier(SupplierModel sup);
        List<SupplierModel> SuppliersSearch(SupplierSimpleSearchModel supplierName);
        string UpdateSupplier(SupplierUpdateModel sup);
        SupplierSingleModel ViewSupplierById(int SupplierId);
    }
}