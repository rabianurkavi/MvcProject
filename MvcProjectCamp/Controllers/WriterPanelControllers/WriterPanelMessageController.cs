using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace MvcProjectCamp.Controllers.WriterPanelControllers
{
    public class WriterPanelMessageController : Controller
    {
        MessageValidator messageValidator = new MessageValidator();
        MessageManager messageManager = new MessageManager(new EfMessageDal());
        // GET: WriterPanelMessage
        public ActionResult Inbox()
        {
            string p = (string)Session["WriterMail"];
            var messagelist = messageManager.GetListInbox(p);
            return View(messagelist);
        }
        public PartialViewResult MessageListMenu()
        {
            return PartialView();
        }
        public ActionResult Sendbox()
        {
            string p = (string)Session["WriterMail"];
            var messagelist = messageManager.GetListSendbox(p);
            return View(messagelist);
        }
        public ActionResult GetInboxDetails(int id)
        {
            var messageValue = messageManager.GetByID(id);
            return View(messageValue);
        }
        public ActionResult GetSendboxDetails(int id)
        {
            var messageValue = messageManager.GetByID(id);
            return View(messageValue);
        }
        [HttpGet]
        public ActionResult NewMessage()
        {
            return View();
        }
        [HttpPost]
        public ActionResult NewMessage(Message message)
        {

            ValidationResult results = messageValidator.Validate(message);
            string p = (string)Session["WriterMail"];
            if (results.IsValid)
            {
                message.SenderMail = p;
                message.MessageDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                messageManager.MessageAdd(message);
                return RedirectToAction("Sendbox");
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