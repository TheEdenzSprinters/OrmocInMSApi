using IMSRepository;
using IMSRepository.Utilities;
using ItemManagementService.Interfaces;
using ItemManagementService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ItemManagementService.BusinessLayer
{
    public class LoginBusinessLayer : ILoginBusinessLayer
    {
        readonly ILoginDataAccess _LoginDataAccess;


        public LoginBusinessLayer(ILoginDataAccess LoginDataAccess)
        {
            _LoginDataAccess = LoginDataAccess;
        }

        public LoginResultModel AuthenticateUser(LoginModel login)
        {
            User saveToken = new User();
            LoginResultModel result = new LoginResultModel();

            var userId = _LoginDataAccess.GetUserId(login.UserName);

            if(userId == 0)
            {
                result.Message = "User not found.";
                result.Token = "";
            }
            
            string hash = GetHashKey();
            //Call the string encrypt here

            var passwordCheck = _LoginDataAccess.ValidateUserPassword(userId, login.Password);

            if (passwordCheck)
            {
                //Generate the token and save to db.
                saveToken.Id = userId;
                saveToken.Token = "valid user";
                saveToken.UpdateDttm = DateTime.UtcNow;
                saveToken.UpdateUserName = "ADMIN";

                //save token to db.
                var updatedToken = _LoginDataAccess.SaveToken(saveToken);

                if (!updatedToken.ToLower().Contains("error"))
                {
                    result.Message = "Success";
                    result.Token = updatedToken;
                }
                else
                {
                    result.Message = updatedToken;
                    result.Token = "";
                }
            }

            return result;
        }


        private string GetHashKey()
        {
            var hash = _LoginDataAccess.GetHashKey();

            return hash;
        }
    }
}