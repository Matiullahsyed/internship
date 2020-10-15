using StudentData;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentRepositry
{
   public class BaseRepositry <T> where T : class
    {
        public DbSet<T> _dbset;

        public SchoolContext _context;

        public BaseRepositry(SchoolContext context)
        {
            _context = context;
        }
        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }
        public void Post(T tobject)
        {
            _context.Set<T>().Add(tobject);
            _context.SaveChanges();
        }
        public void Update(T tobject)
        {
            _context.Entry(tobject).State = EntityState.Modified;
            _context.SaveChanges();
        }
        public void Delete(int id)
        {
            var deletingObject = _context.Set<T>().Find(id);
            _context.Set<T>().Remove(deletingObject);
            _context.SaveChanges();
        }
    }
}
