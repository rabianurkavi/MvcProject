using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IRepository<T>
    {
        //CRUD OPERASYONLARI
        List<T> List();
        void Insert(T t);
        void Delete(T t);
        void Update(T t);
        //filtreleme işlemleri yapacak örneğin yazar adı ali olanları getir gibi
        List<T> List(Expression<Func<T, bool>> filter);
    }
}
