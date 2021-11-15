using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IMessageService
    {
        void MessageAdd(Message message);
        void MessageDelete(Message message);
        void MessageUpdate(Message message);
        List<Message> GetListInbox(string p);
        List<Message> ListInbox();
        List<Message> GetListSendbox(string p);
        List<Message> ListSendBox();
        List<Message> GetListDrafts();//taslaklar
        Message GetByID(int id);
    }
}
