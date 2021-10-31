using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestBL
{
    public class Repository<T> : IRepository<T> where T : class, IEntity
    {
        private readonly TestContext _context;
        private readonly DbSet<T> _set;
        public Repository(TestContext context) => (_context, _set) = (context, context.Set<T>());

        public bool AddItem(T item)
        {
            _context.Add(item);
            return _context.SaveChanges() > 0;
        }

        public bool DeleteItem(int id)
        {
            var item = _set.SingleOrDefault(x => x.Id == id);
            _context.Entry(item).State = EntityState.Detached;
            _set.Remove(item);
            return _context.SaveChanges() > 0;
        }

        public T GetItem(int id)
        {
            var item = _set.SingleOrDefault(x => x.Id == id);
            return item;
           
        }

       public IEnumerable<T> GetItems()
        {
            return _set.ToList();
        }

        public bool UpdateItem(T item)
        {
            _context.Entry(_set.SingleOrDefault()).State = EntityState.Modified;
            _context.Update(item);
            return _context.SaveChanges() > 0;
        }
    }
}
