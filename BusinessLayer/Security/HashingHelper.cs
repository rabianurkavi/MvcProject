﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Security
{
    public class HashingHelper
    {
        public static void CreatePasswordHash(string adminMail, string password, out byte[] adminMailHash,out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                adminMailHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(adminMail));
              
            }
        }

        public static void WriterCreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));

            }
        }
        public static bool WriterVerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var computedPasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedPasswordHash.Length; i++)
                {
                    if (computedPasswordHash[i] != passwordHash[i])
                    {
                        return false;
                    }
                }
                return true;
            }
        }
        public static bool VerifyPasswordHash(string adminMail, string password, byte[] adminMailHash, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var computedPasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedPasswordHash.Length; i++)
                {
                    if (computedPasswordHash[i] != passwordHash[i])
                    {
                        return false;
                    }
                }

                var computedUserNameHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(adminMail));
                for (int i = 0; i < computedUserNameHash.Length; i++)
                {
                    if (computedUserNameHash[i] != adminMailHash[i])
                    {
                        return false;
                    }
                }
                return true;
            }
        }

        public static bool VerifyPasswordHash(string userName, byte[] userNameHash)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                var computedUserNameHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(userName));
                for (int i = 0; i < computedUserNameHash.Length; i++)
                {
                    if (computedUserNameHash[i] != userNameHash[i])
                    {
                        return false;
                    }
                }
                return true;
            }
        }
    }
}

   