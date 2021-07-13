using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IAboutService
    {
        void AboutAdd(About about);
        void AboutDelete(About about);
        void AboutUpdate(About about);
        List<About> GetList();
        About AboutGetById(int id);
    }
}
