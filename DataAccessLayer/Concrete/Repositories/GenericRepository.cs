using DataAccessLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete.Repositories
{
    public class GenericRepository<T> : IRepository<T> where T : class
    {
        Context context = new Context();
        DbSet<T> _object;
        public GenericRepository()
        {
            //senin değerin contexte bağlı olarak gönderilen t değeridir.(özne=object)
            //yani object artık dışardan gönderilen t değeri ne ise o olalcak
            _object = context.Set<T>();
        }
        public void Delete(T t)
        {
            _object.Remove(t);
            context.SaveChanges();
        }

        public void Insert(T t)
        {
            _object.Add(t);
            context.SaveChanges();
        }

        public List<T> List()
        {
            return _object.ToList(); 
        }

        public List<T> List(Expression<Func<T, bool>> filter)
        {
            return _object.Where(filter).ToList();
        }

        public void Update(T t)
        {
            context.SaveChanges();
        }
    }
}
