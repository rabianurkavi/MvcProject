using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjectCamp.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult GetCategoryList()
        {
            var categoryvalues = categoryManager.GetList();//getall da olabilir
            return View(categoryvalues);
        }
        [HttpGet]//böylece sayfa yüklendiği zaman httpget devreye girecek
        public ActionResult AddCategory()
        {
            return View();
        }
        [HttpPost]//ben eğer o sayfada butona tıklarsam post devreye girecek
        public ActionResult AddCategory(Category category)
        {
            //categoryManager.CategoryAdd(category);
            return RedirectToAction("GetCategoryList");

        }
    }
}