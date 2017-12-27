using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace IceboxAssets.DataAccess
{
    //匹配泛型统一函数，所以在该类限制泛型为类
    public class Repository<T> : IRepository<T> where T : class, new()//大家约束一样的时候，才能用它的泛型接口
    {//如果可以，把操作日志写在这里
       
        public Repository()
        {
            //因为做了单例模式，所以这里不再接受数据源，如果是webapi的或者依赖的NH 数据库，可能需要用session来做的话，
        }

        protected SQLiteConnection _db
        {
            get { return Database.SqLiteDB; }
        }

        public IQueryable<T> Table()
        {
            return _db.Table<T>().AsQueryable<T>();//这里要给个源表
        }

        #region 成员函数(为什么要显式实现接口的保护函数在这里？)
        void IRepository<T>.Add(T entity)
        {
            Add(entity);
        }
        void IRepository<T>.Delete(T entity)
        {
            Delete(entity);
        }
        void IRepository<T>.Update(T entity)
        {
            Update(entity);
        }
        void IRepository<T>.Copy(T source, T target)
        {
            Copy(source, target);
        }
        IEnumerable<T> IRepository<T>.Fetch(Expression<Func<T, bool>> predicate)
        {
            return Fetch(predicate);
        }
        IEnumerable<T> IRepository<T>.Fetch(Expression<Func<T, bool>> predicate, Action<OrderTable<T>> order)
        {
            return Fetch(predicate, order);
        }
        IEnumerable<T> IRepository<T>.Fetch(Expression<Func<T, bool>> predicate, Action<OrderTable<T>> order, int shipCout, int takeCout)
        {
            return Fetch(predicate, order, shipCout, takeCout);
        }
        void IRepository<T>.Flush()
        {
            Flush();
        }
        T IRepository<T>.GetByExpression(Expression<Func<T, bool>> predicate)
        {
            return GetByExpression(predicate);
        }
        T IRepository<T>.GetById(int id)
        {
            return GetById(id);
        }
        #endregion


        public virtual void Add(T entity)
        {
            _db.Insert(entity, typeof(T));
        }

        public virtual void Copy(T source, T target)
        {//浅复制类后，使用反射获取值，然后放到目标类中，实现深度复制一个类
            throw new NotImplementedException();
        }

        public virtual int Count(Expression<Func<T, bool>> predicate)
        {
            return Fetch(predicate).Count();
        }

        public virtual void Delete(T entity)
        {
            _db.Delete<T>(entity);
        }

        public virtual IEnumerable<T> Fetch(Expression<Func<T, bool>> predicate)
        {
            return Table().Where(predicate);
        }

        public virtual IEnumerable<T> Fetch(Expression<Func<T, bool>> predicate, Action<OrderTable<T>> order)
        {
            var orderTable = new OrderTable<T>(Fetch(predicate).AsQueryable());
            order(orderTable);
            return orderTable.Queryable;
        }

        public virtual IEnumerable<T> Fetch(Expression<Func<T, bool>> predicate, Action<OrderTable<T>> order, int shipCout, int takeCout)
        {
            return Fetch(predicate, order).Skip(shipCout).Take(takeCout);
        }

        public virtual void Flush()
        {
            throw new NotImplementedException();
        }

        public virtual T GetByExpression(Expression<Func<T, bool>> predicate)
        {
            return Fetch(predicate).SingleOrDefault();
        }

        public virtual T GetById(int id)
        {
            return _db.Get<T>(id);
        }

        public virtual void Update(T entity)
        {
            _db.Update(entity);
        }
    }
}
