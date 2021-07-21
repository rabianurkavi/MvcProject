using BusinessLayer.Abstract;
using BusinessLayer.Security;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using EntityLayer.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    //public class AuthManager:IAuthService
    //{
    //    private IAdminService _adminService;
    //    IAdminDal _adminDal;
    //    public AuthManager(IAdminService adminService, IAdminDal adminDal)
    //    {
    //        _adminService = adminService;
    //        _adminDal = adminDal;
    //    }

    //    public Admin AdminExists(string email)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public bool AdminLogin(AdminForLoginDto adminForLoginDto)
    //    {
    //        using (var crypto = new System.Security.Cryptography.HMACSHA512())
    //        {
    //            var mailHash = crypto.ComputeHash(Encoding.UTF8.GetBytes(adminForLoginDto.AdminMail));
    //            var admin = _adminService.GetList();
    //            foreach (var item in admin)
    //            {
    //                if (HashingHelper.AdminVerifyPasswordHash(adminForLoginDto.AdminMail, adminForLoginDto.AdminPassword, item.AdminMail,
    //                    item.PasswordHash, item.PasswordSalt))
    //                {
    //                    return true;
    //                }
    //            }
    //            return false;
    //        }
    //    }

    //    public void AdminRegister(string adminUserName, string adminMail, string password)
    //    {
    //        throw new NotImplementedException();
    //    }
    //}
}
