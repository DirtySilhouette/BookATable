using BookATable.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BookATable.Data.Repositories
{
    public class BaseRepository<T> where T : BaseEntity, new()
    {
        protected readonly DbContext context;
        protected readonly DbSet<T> dbSet;
        protected UnitOfWork unitOfWork;

        public BaseRepository()
        {
            this.context = new BookATableContext();
            this.dbSet = context.Set<T>();
        }

        public BaseRepository(UnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;

            this.context = this.unitOfWork.Context;
            this.dbSet = this.context.Set<T>();
        }

        public T GetByID(int id)
        {
            return dbSet.Find(id);
        }

        public List<T> GetAll()
        {
            return dbSet.ToList();
        }

        //public List<T> GetAll(Expression<Func<T, bool>> filter = null, int page = 0, int pageSize = 10)
        //{
        //    IQueryable<T> query = dbSet;

        //    if (filter != null)
        //        query = query.Where(filter);

        //    page = page <= 0 ? 1 : page;
        //    pageSize = pageSize <= 0 ? 10 : pageSize;

        //    query = query.OrderBy(i => i.ID)
        //                 .Skip((page - 1) * pageSize)
        //                 .Take(pageSize);

        //    return query.ToList();
        //}

        public List<T> GetAll(System.Linq.Expressions.Expression<Func<T,bool>>filter)
        {

            return dbSet.Where(filter).ToList();
        }

        public void Insert(T item)
        {
            dbSet.Add(item);
            context.SaveChanges();
        }

        private void Update(T item)
        {
            context.Entry(item).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            dbSet.Remove(GetByID(id));
            context.SaveChanges();
        }

        public void Save(T item)
        {
            if (item.ID > 0)
                Update(item);
            else
                Insert(item);

            context.SaveChanges();
        }
    }
}
