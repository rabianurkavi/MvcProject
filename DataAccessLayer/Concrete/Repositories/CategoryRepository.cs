using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete.Repositories
{

    //AMELELİK YAPIYORUZ
    public class CategoryRepository : ICategoryDal
    {
        Context context = new Context();
        DbSet<Category> _categories;
        public void Delete(Category category)
        {
            _categories.Remove(category);
            context.SaveChanges();
        }

        public void Insert(Category category)
        {
            _categories.Add(category);
            context.SaveChanges();
        }

        public List<Category> List()
        {
            return _categories.ToList();
        }

        public List<Category> List(Expression<Func<Category, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public void Update(Category category)
        {
            context.SaveChanges();
        }
    }
}
/*--entity-----   ado.net
 * ToList() --->  ExecuteReader()-select
 * Add
 * Remove
 * savechanges()-->ExecuteNonQuery()-update-delete-insert-into
 */
