using IMSRepository.Models;
using System.Collections.Generic;

namespace IMSRepository.Utilities
{
    public interface ISupplierDataAccess
    {
        List<Supplier> GetAllSuppliers();
        string CreateNewSupplier(Supplier sup);
        List<SupplierSearchResult> SuppliersSearch(string supplierName);
        string UpdateSupplier(Supplier sup);
        Supplier ViewSupplierById(int SupplierId);
        string DeleteSupplier(int supplierId);

    }
}
