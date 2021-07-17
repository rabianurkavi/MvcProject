using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IImageFileService
    {
        void Add(ImageFile imageFile);
        void Delete(ImageFile imageFile);
        void Update(ImageFile imageFile);
        List<ImageFile> GetList();
        ImageFile GetById(int id);
    }
}
