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
    public class ContentController : Controller
    {
        // GET: Content
        ContentManager contentManager = new ContentManager(new EfContentDal());
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ContentByHeading(int id)
        {
            var contentValues = contentManager.GetListHeadingById(id);
            return View(contentValues);
        }
        public ActionResult GetContentList()
        {
            var contentValues = contentManager.GetList();//getall da olabilir
            return View(contentManager);
        }
        [HttpGet]
        public ActionResult AddContent()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddContent(Content content)
        {
            ContentValidator contentValidator = new ContentValidator();
            ValidationResult results = contentValidator.Validate(content);
            if (results.IsValid)
            {
                contentManager.ContentAdd(content);
                return RedirectToAction("GetContentList");
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
        [HttpGet]
        public ActionResult UpdateContent(int id)
        {
            var contentValues = contentManager.GetById(id);
            return View(contentValues);
        }
        [HttpPost]
        public ActionResult UpdateContent(Content content)
        {
            contentManager.ContentUpdate(content);
            return RedirectToAction("Index");
        }

    }
}