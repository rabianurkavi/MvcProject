using BusinessLayer.Concrete;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjectCamp.Controllers
{
    public class StatisticsController : Controller
    {
        CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
        public ActionResult GetCategoryList()
        {
            var categoryvalues = categoryManager.GetList();//getall da olabilir
            var sayac = categoryvalues.Count();

            return View(categoryvalues);
        }


        // GET: Statistics
        public ActionResult Index()
        {
            return View();
        }
    }
}