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
        List<Message> GetList();
        Message GetByID(int id);
    }
}
