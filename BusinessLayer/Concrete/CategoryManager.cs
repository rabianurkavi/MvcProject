using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.Repositories;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class CategoryManager : ICategoryService
    {
        ICategoryDal _categoryDal;
        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        //GenericRepository<Category> repository = new GenericRepository<Category>();
        //public List<Category> GetAll()
        //{
        //    return repository.List();
        //}
        //public void CategoryAdd(Category category)
        //{
        //    if (category.CategoryName == "" || category.CategoryName.Length <= 3 ||
        //        category.CategoryDescription == "" || category.CategoryName.Length >= 51)
        //    {
        //        //hata mesajı
        //    }
        //    else
        //    {
        //        repository.Insert(category);
        //    }//ctrl k d satırları düzenler
        //}
        public List<Category> GetList()
        {
            return _categoryDal.List();
        }
    }
}
