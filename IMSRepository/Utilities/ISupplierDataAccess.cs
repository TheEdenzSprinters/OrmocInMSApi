using IMSRepository.Models;
using System.Collections.Generic;

namespace IMSRepository.Utilities
{
    public interface ISupplierDataAccess
    {
        List<Supplier> GetSuppliers();
        Supplier CreateNewSupplier(Supplier sup);
        List<Supplier> SuppliersSearch(SupplierSearchModel supplierName);
        string UpdateSupplier(Supplier sup);
        Supplier ViewSupplierById(int SupplierId);
    }
}
