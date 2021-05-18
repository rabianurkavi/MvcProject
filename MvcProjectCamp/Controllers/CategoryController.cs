using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
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
            CategoryValidator categoryValidator = new CategoryValidator();
            ValidationResult results = categoryValidator.Validate(category);//sen result değişkeni parametreden gelenlerin kontrolünü yap(categoryvalidatordaki kurallara göre)
            //categoryManager.CategoryAdd(category);
            if(results.IsValid)
            {
                categoryManager.CategoryAddBL(category);
                return RedirectToAction("GetCategoryList");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();

        }
    }
}