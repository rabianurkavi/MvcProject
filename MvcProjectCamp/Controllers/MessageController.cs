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
    public class MessageController : Controller
    {
        MessageValidator messageValidator = new MessageValidator();
        MessageManager messageManager = new MessageManager(new EfMessageDal());

        // GET: Message
        public ActionResult Inbox()
        {
            var messagelist = messageManager.GetListInbox();
            return View(messagelist);
        }
        public ActionResult Sendbox()
        {
            var messagelist = messageManager.GetListSendbox();
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
            if (results.IsValid)
            {
                message.SenderMail = "rabiakavi@hotmail.com";
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
        public ActionResult DeleteMessage(int id)
        {
            var messageValue = messageManager.GetByID(id);
            messageManager.MessageDelete(messageValue);
            return RedirectToAction("Inbox");
        }
        public ActionResult InDrafts()
        {
            
            var messageList = messageManager.GetListDrafts();
            return View(messageList);
        }
    }
}