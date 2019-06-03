using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMSRepository.Utilities

{
    public class LoginDataAccess : ILoginDataAccess
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public int GetUserId(string userName)
        {
            using (OrmocIMSEntities context = new OrmocIMSEntities())
            {
                var userId = context.Users
                    .Where(x => x.UserName.Equals(userName)).Select(x => x.Id).FirstOrDefault();

                return userId;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        public bool ValidateUserPassword(int id, string password)
        {
            using (OrmocIMSEntities context = new OrmocIMSEntities())
            {
                var pass = context.Users
                    .Where(x => x.Id == id && x.Password.Equals(password)).FirstOrDefault();

                return pass != null ? true : false;
            }
        }

        /// <summary>
        /// Getting a hashKey
        /// </summary>
        /// <returns></returns>
        public string GetHashKey()
        {
            using (OrmocIMSEntities context = new OrmocIMSEntities())
            {
                var hash = context.HashKeys.Select(x => x.KeyValue).FirstOrDefault();

                return hash;
            }
        }

        public string SaveToken(User saveToken)
        {
            try
            {
                using (OrmocIMSEntities context = new OrmocIMSEntities())
                {
                    var query = context.Users.Where(x => x.Id == saveToken.Id).FirstOrDefault();

                    query.Token = saveToken.Token;
                    query.UpdateDttm = DateTime.UtcNow;
                    query.UpdateUserName = "ADMIN";

                    context.Entry(query).State = System.Data.Entity.EntityState.Modified;
                    var result = context.SaveChanges();

                    if (result > 0)
                    {
                        return saveToken.Token;
                    }
                    else
                    {
                        return "Error encountered during token save.";
                    }
                }
            }
            catch
            {
                return "Internal error encountered.";
            }
        }
    }
}