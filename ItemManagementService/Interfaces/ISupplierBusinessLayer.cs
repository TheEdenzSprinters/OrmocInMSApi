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
        List<Supplier> GetAllSuppliers();
        string CreateNewSupplier(SupplierModel sup);
        List<SupplierSearchResultModel> SuppliersSearch(SupplierSimpleSearchModel supplierSimple);
        string UpdateSupplier(SupplierUpdateModel sup);
        SupplierSingleModel ViewSupplierById(int SupplierId);
        string DeleteSupplier(int Id);
    }
}