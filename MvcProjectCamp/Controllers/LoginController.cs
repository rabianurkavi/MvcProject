using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using EntityLayer.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MvcProjectCamp.Controllers
{
    public class LoginController : Controller
    {
        AdminManager _adminManager = new AdminManager(new EfAdminDal());
        // GET: Login 
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult AdminLogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AdminLogin(Admin admin)
        {
            //var userToLogin = _authService.Login(adminForLoginDto);
            //if(userToLogin!=null)
            //{
            //    FormsAuthentication.SetAuthCookie(adminForLoginDto.AdminUserName, false);
            //    Session["AdminUserName"] = adminForLoginDto.AdminUserName;
            //    return RedirectToAction("Index", "AdminCategory");
            //}
            //else
            //{

            //    return RedirectToAction("Login");
            //}
            var adminLoginInfo = _adminManager.Login(admin);
            if(adminLoginInfo!=null)
            {
                FormsAuthentication.SetAuthCookie(adminLoginInfo.AdminUserName, false);
                Session["AdminUserName"] = adminLoginInfo.AdminUserName;
                return RedirectToAction("Index", "AdminCategory");
            }
            else
            {
                return RedirectToAction("Index");
            }

        }
    }
}