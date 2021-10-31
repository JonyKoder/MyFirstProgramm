using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestBL
{
    public interface IRepository<T> 
    {
        bool AddItem(T item);
        bool UpdateItem(T item);
        bool DeleteItem(int id);

        IEnumerable<T> GetItems();
        T GetItem(int id);
        
    }
}
