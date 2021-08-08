using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjectCamp.Controllers
{
    [AllowAnonymous]
    public class RegisterController : Controller
    {
        IAuthService _authService = new AuthManager(new AdminManager(new EfAdminDal()),new WriterManager(new EfWriterDal()));
        // GET: Register
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(AdminForLoginDto adminForLoginDto)
        {
            _authService.AdminRegister(adminForLoginDto.AdminUserName, adminForLoginDto.AdminMail, adminForLoginDto.AdminPassword);
            return RedirectToAction("Index", "AdminCategory");
        }
    }
}