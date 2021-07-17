using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class ImageFileManager:IImageFileService
    {
        IImageFileDal _imageFileDal;
        public ImageFileManager(IImageFileDal imageFileDal)
        {
            _imageFileDal = imageFileDal;
        }

        public void Add(ImageFile imageFile)
        {
            _imageFileDal.Insert(imageFile);
        }

        public void Delete(ImageFile imageFile)
        {
            _imageFileDal.Delete(imageFile);
        }

        public ImageFile GetById(int id)
        {
            return _imageFileDal.Get(x => x.ImageId == id);
        }

        public List<ImageFile> GetList()
        {
            return _imageFileDal.List();
        }

        public void Update(ImageFile imageFile)
        {
            _imageFileDal.Update(imageFile);
        }
    }
}
