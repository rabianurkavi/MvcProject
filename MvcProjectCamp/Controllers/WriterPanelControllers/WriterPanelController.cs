using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;
using FluentValidation.Results;
using BusinessLayer.ValidationRules;

namespace MvcProjectCamp.Controllers.WriterPanelControllers
{
    public class WriterPanelController : Controller
    {
        CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
        // GET: WriterPanel
        HeadingManager headingManager = new HeadingManager(new EfHeadingDal());
        MvcKampContext mvcKampContext = new MvcKampContext();
        WriterManager writerManager = new WriterManager(new EfWriterDal());
       

        [HttpGet]
        public ActionResult WriterProfile(int id=0)
        {
            string p = (string)Session["WriterMail"];
            id = mvcKampContext.Writers.Where(x => x.WriterMail == p).Select(y => y.WriterId).FirstOrDefault();
            var writervalue = writerManager.GetById(id);
            return View(writervalue);
        }
        [HttpPost]
        public ActionResult WriterProfile(Writer writer)
        {
            WriterValidator writerValidator = new WriterValidator();
            ValidationResult results = writerValidator.Validate(writer);
            if (results.IsValid)
            {
                writerManager.WriterUpdate(writer);
                return RedirectToAction("AllHeading","WriterPanel");
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
        public ActionResult MyHeading(string p)
        {
            
            p = (string)Session["WriterMail"];
            var writerIdInfo = mvcKampContext.Writers.Where(x => x.WriterMail == p).Select(y => y.WriterId).FirstOrDefault();
            var headingValues = headingManager.GetListByWriter(writerIdInfo);
            return View(headingValues);
        }
        [HttpGet]
        public ActionResult NewHeading()
        {
            //Dropdown List
            List<SelectListItem> valueCategory = (from x in categoryManager.GetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CategoryName,
                                                      Value = x.CategoryId.ToString()
                                                  }).ToList();
            ViewBag.vc = valueCategory;
            return View();
        }
        [HttpPost]
        public ActionResult NewHeading(Heading heading)
        {
            string writermailinfo = (string)Session["WriterMail"];
            var writerIdInfo = mvcKampContext.Writers.Where(x => x.WriterMail == writermailinfo).Select(y => y.WriterId).FirstOrDefault();
            heading.HeadingDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            heading.WriterId = writerIdInfo;
            heading.HeadingStatus = true;
            headingManager.HeadingAdd(heading);
            return RedirectToAction("MyHeading");
        }
        [HttpGet]
        public ActionResult UpdateHeading(int id)
        {
            List<SelectListItem> valueCategory = (from x in categoryManager.GetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CategoryName,
                                                      Value = x.CategoryId.ToString()
                                                  }).ToList();
            var headingValues = headingManager.GetById(id);
            ViewBag.vlc = valueCategory;
            return View(headingValues);
        }
        [HttpPost]
        public ActionResult UpdateHeading(Heading heading)
        {
            headingManager.HeadingUpdate(heading);
            return RedirectToAction("MyHeading");
        }
        public ActionResult DeleteHeading(int id)
        {
            var headingValue = headingManager.GetById(id);
            headingValue.HeadingStatus = false;
            headingManager.HeadingDelete(headingValue);
            return RedirectToAction("index");
        }
        public ActionResult AllHeading(int p=1)
        {
            var headings = headingManager.GetList().ToPagedList(p, 4);
            return View(headings);
        }
    }
}