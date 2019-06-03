using IMSRepository;
using IMSRepository.Utilities;
using ItemManagementService.Interfaces;
using ItemManagementService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
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
            string encryptedPassword = EncryptText(hash, login.Password);

            var passwordCheck = _LoginDataAccess.ValidateUserPassword(userId, encryptedPassword);

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

        private string EncryptText(string hashKey, string originalText)
        {
            String encryptedText = String.Empty;

            byte[] data = UTF8Encoding.UTF8.GetBytes(originalText);
            using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
            {
                byte[] keys = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(hashKey));
                using (TripleDESCryptoServiceProvider tripDes = new TripleDESCryptoServiceProvider() { Key = keys, Mode = CipherMode.ECB, Padding = PaddingMode.PKCS7 })
                {
                    ICryptoTransform transform = tripDes.CreateEncryptor();
                    byte[] results = transform.TransformFinalBlock(data, 0, data.Length);
                    encryptedText = Convert.ToBase64String(results, 0, results.Length);
                }
            }

            return encryptedText;
        }
    }
}