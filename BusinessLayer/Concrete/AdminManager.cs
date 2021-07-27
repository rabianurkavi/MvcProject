using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class AdminManager : IAdminService
    {
        IAdminDal _adminDal;
        public AdminManager(IAdminDal adminDal)
        {
            _adminDal = adminDal;
        }
        public void AdminAdd(Admin admin)
        {
            _adminDal.Insert(admin);
        }

        public void AdminDelete(Admin admin)
        {
            _adminDal.Delete(admin);
        }

        public void AdminUpdate(Admin admin)
        {
            _adminDal.Update(admin);
        }

        public Admin EditProfil(Admin admin, string password)
        {
            throw new NotImplementedException();
        }

        //public List<Admin> GetAdminUserByEmail(string email)
        //{
        //    return _adminDal.List(x => x.AdminUserName == email);
        //}

        public Admin GetById(int id)
        {
            return _adminDal.Get(x => x.AdminId == id);
        }

        //public Admin GetByMail(string email)
        //{
        //    return _adminDal.Get(x => x.AdminUserName == email);
        //}

        public List<Admin> GetList()
        {
            return _adminDal.List();
        }

        //public Admin Login(Admin admin)
        //{
        //    Context context = new Context();
        //    var adminLogin = context.Admins.SingleOrDefault(x => x.AdminUserName == admin.AdminUserName && x.AdminPassword == admin.AdminPassword);
        //    return adminLogin;
        //}
    }
}
