using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IContentService
    {
        void ContentAdd(Content content);
        void ContentDelete(Content content);
        void ContentUpdate(Content content);
        List<Content> GetList(string p);
        List<Content> GetListByWriter(int id);
        List<Content> GetListHeadingById(int id);
        Content GetById(int id);
    }
}
