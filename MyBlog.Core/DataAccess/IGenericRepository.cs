

using MyBlog.Core.Entities;
using System.Linq.Expressions;

namespace MyBlog.Core.DataAccess

{
    public interface IGenericRepository<T> where T : class, IEntityBase, new()
    {
        T Get(Expression<Func<T,bool>> expression);
        List<T> GettAll(Expression<Func<T, bool>>? expression = null);

        bool Add(T entitiy);
        bool Update(T entitiy);
        bool Delete(T entitiy);


    }
}
