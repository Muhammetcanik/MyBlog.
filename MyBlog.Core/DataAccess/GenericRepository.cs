using Microsoft.EntityFrameworkCore;
using MyBlog.Core.Entities;
using System.Linq.Expressions;

//bu işlemleri yaptıktan sonra DataAccess içerisinde abstract class oluşturup orada tanımlayabiliriz
//herbir nesne modelim için işlem yapabilen sınıflar oluşturururuz

namespace MyBlog.Core.DataAccess
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class, IEntityBase, new()
    {
        //Dependecy ınjection
        private readonly DbContext _context; // readonly constructor içerisinde sadece değer ataması yapılabilir
        private readonly DbSet<T> _set; // bunu kullanabilmemiz için constructor içerisinde _decontext.set<T> yapmamız lazım

        private bool Save() => _context.SaveChanges() > 0;
        public GenericRepository(DbContext context)
        {
            _context = context;
            _set = _context.Set<T>();

        }
        public bool Add(T entitiy)
        {
            _set.Add(entitiy);
            return Save();
        }

        public bool Delete(T entitiy)
        {
            _set.Remove(entitiy);
            return Save();
        }

        public T Get(Expression<Func<T, bool>> expression)
        => _set.FirstOrDefault(expression) ?? new(); // eşleşen ilk kaydı getir yoksa null döner. verilen şarta göre ilk kaydı getir

        public List<T> GettAll(Expression<Func<T, bool>>? expression = null)
        =>  expression == null ? _set.ToList() : _set.Where(expression).ToList();

        public bool Update(T entitiy)
        {
            _set.Update(entitiy);
            return Save();
        }
    }
}