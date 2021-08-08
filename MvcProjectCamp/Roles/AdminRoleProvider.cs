using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Security;

namespace MvcProjectCamp.Roles
{
    public class AdminRoleProvider : RoleProvider
    {
        AdminManager adminManager = new AdminManager(new EfAdminDal());
        public override string ApplicationName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }

        public override string[] GetRolesForUser(string username)
        {
            using (var crypto = new System.Security.Cryptography.HMACSHA512())
            {
                var mailCrypto = crypto.ComputeHash(Encoding.UTF8.GetBytes(username));
                var admin = adminManager.GetList();

                if (admin != null)
                {
                    foreach (var item in admin)
                    {
                        for (int i = 0; i < mailCrypto.Length; i++)
                        {
                            if (mailCrypto[i] == item.AdminMail[i])
                            {
                                return new string[] { item.AdminRole };
                            }
                        }
                    }
                }

                return new string[] { };

            }

        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool IsUserInRole(string username, string roleName)
        {
            throw new NotImplementedException();
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }
    }
}