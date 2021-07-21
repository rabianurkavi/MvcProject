﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Security
{
    public class HashingHelper
    {
        public static void AdminCreatePasswordHash(string adminMail, string password, out byte[] adminMailHash, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                adminMailHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(adminMail));
            }
        }

        public static bool AdminVerifyPasswordHash(string adminMail, string password, byte[] adminMailHash, byte[] passwordHash, byte[] passwordSalt)
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

                var computedAdminMailHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(adminMail));
                for (int i = 0; i < computedAdminMailHash.Length; i++)
                {
                    if (computedAdminMailHash[i] != adminMailHash[i])
                    {
                        return false;
                    }
                }
                return true;
            }
        }

        public static bool AdminVerifyPasswordHash(string adminMail, byte[] adminMailHash)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                var computedAdminMailHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(adminMail));
                for (int i = 0; i < computedAdminMailHash.Length; i++)
                {
                    if (computedAdminMailHash[i] != adminMailHash[i])
                    {
                        return false;
                    }
                }
                return true;
            }
        }
    }
}
   