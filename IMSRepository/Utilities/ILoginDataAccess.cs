using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMSRepository.Utilities
{
    public interface ILoginDataAccess
    {
        int GetUserId(string userName);
        bool ValidateUserPassword(int id, string password);
        string SaveToken(User saveToken);
        string GetHashKey();
    }
}
