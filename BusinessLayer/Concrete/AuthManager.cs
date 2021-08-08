using BusinessLayer.Abstract;
using BusinessLayer.Security;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using EntityLayer.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class AuthManager : IAuthService
    {
        IAdminService _adminService;
        IWriterService _writerService;

        public AuthManager(IAdminService adminService,IWriterService writerService)
        {
            _adminService = adminService;
            _writerService = writerService;

        }

        public Admin AdminExists(string email)
        {
            throw new NotImplementedException();
        }

        public bool AdminLogin(AdminForLoginDto adminForLoginDto)
        {
            using (var crypto = new System.Security.Cryptography.HMACSHA512())
            {
                var mailHash = crypto.ComputeHash(Encoding.UTF8.GetBytes(adminForLoginDto.AdminMail));
                var admin = _adminService.GetList();
                foreach (var item in admin)
                {
                    if (HashingHelper.VerifyPasswordHash(adminForLoginDto.AdminMail, adminForLoginDto.AdminPassword, item.AdminMail,
                        item.PasswordHash, item.PasswordSalt))
                    {
                        return true;
                    }
                }
                return false;
            }
        }

        public void AdminRegister(string adminUserName, string adminMail, string password)
        {
            byte[] mailHash,passwordHash, passworSalt;
            HashingHelper.CreatePasswordHash(adminMail, password,out mailHash, out passwordHash, out passworSalt);
            var admin = new Admin
            {
                PasswordHash = passwordHash,
                PasswordSalt = passworSalt,
                AdminMail=mailHash,
                AdminRole = "A",
                AdminUserName = adminUserName,


            };
            _adminService.AdminAdd(admin);

        }
        public Writer WriterLogin(string writerMail, string writerPassword)
        {
            MvcKampContext mvcKampContext = new MvcKampContext();
            return mvcKampContext.Writers.FirstOrDefault(x => x.WriterMail == writerMail && x.WriterPassword == writerPassword);
        }

        public void WriterRegister(string writerName, string writerSurName, string writerAbout,string writerMail, string Title, string writerPassword, bool writerStatus)
        {
            var writer = new Writer
            {
                WriterName = writerName,
                WriterSurName = writerSurName,
                WriterAbout = writerAbout,
                WriterTitle = Title,
                WriterMail = writerMail,
                WriterPassword = writerPassword,
                WriterStatus = writerStatus
            };
            _writerService.WriterAdd(writer);
        }
    }
}
