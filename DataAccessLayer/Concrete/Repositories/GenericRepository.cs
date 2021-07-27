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
        MvcKampContext context = new MvcKampContext();
        DbSet<T> _object;
        public GenericRepository()
        {
            //senin değerin contexte bağlı olarak gönderilen t değeridir.(özne=object)
            //yani object artık dışardan gönderilen t değeri ne ise o olalcak
            _object = context.Set<T>();
        }
        public void Delete(T t)
        {
            var deletedEntity = context.Entry(t);
            deletedEntity.State = EntityState.Deleted;
            //_object.Remove(t);
            context.SaveChanges();
        }

        public T Get(Expression<Func<T, bool>> filter)
        {
            return _object.SingleOrDefault(filter);//bir dizide ya da listede sadece bir tane ifade döndüren linq 
        }

        public void Insert(T t)
        {
            var addedEntity = context.Entry(t);//entry = giriş
            addedEntity.State = EntityState.Added;
             // _object.Add(t);
            context.SaveChanges();
        }

        //Normal list
        public List<T> List()
        {
            return _object.ToList(); 
        }
        //Parametreli list
        public List<T> List(Expression<Func<T, bool>> filter)
        {
            return _object.Where(filter).ToList();
        }

        public void Update(T t)
        {
            var updatedEntity = context.Entry(t);
            updatedEntity.State = EntityState.Modified;
            context.SaveChanges();
        }
    }
}
