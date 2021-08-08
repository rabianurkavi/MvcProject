using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjectCamp.Controllers.WriterPanelControllers
{
    public class WriterPanelContentController : Controller
    {
        ContentManager contentManager = new ContentManager(new EfContentDal());
        // GET: WriterPanelContent
        public ActionResult MyContent(string p)
        {
            MvcKampContext mvcKampContext = new MvcKampContext();
            p = (string)Session["WriterMail"];
            var writerIdInfo = mvcKampContext.Writers.Where(x => x.WriterMail == p).Select(y => y.WriterId).FirstOrDefault();
            var contentValues = contentManager.GetListByWriter(writerIdInfo);
            return View(contentValues);
        }
    }
}