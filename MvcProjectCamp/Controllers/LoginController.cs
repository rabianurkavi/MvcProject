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
    [AllowAnonymous]
    public class LoginController : Controller
    {
        IAuthService authService = new AuthManager(new AdminManager(new EfAdminDal()));
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
        public ActionResult AdminLogin(AdminForLoginDto adminForLoginDto)
        {
            
            if (authService.AdminLogin(adminForLoginDto))
            {
                FormsAuthentication.SetAuthCookie(adminForLoginDto.AdminMail, false);
                Session["AdminMail"] = adminForLoginDto.AdminMail;
                var session = Session["AdminMail"];
                ViewBag.a = session;
                return RedirectToAction("Index", "Heading");
            }
            else
            {
                ViewData["Hata"] = "Kullanıcı adı veya parola yanlış lütfen tekrar deneyin.";
                return RedirectToAction("AdminLogin");
            }

        }
        public ActionResult AdminLogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("AdminLogin", "Login");
        }

    }
}