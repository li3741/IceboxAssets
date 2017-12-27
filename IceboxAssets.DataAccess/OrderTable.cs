using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace IceboxAssets.DataAccess
{
    /// <summary>
    /// 排序
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class OrderTable<T>
    {
        private IQueryable<T> _queryable;//源
        public OrderTable(IQueryable<T>enumerable)
        {
            _queryable = enumerable;
        }
        public IQueryable<T> Queryable
        {
            get { return _queryable; }
        }
        //升顺序排序 最多三个
        public OrderTable<T> Asc<TKey>(Expression<Func<T,TKey>>keySelector)
        {
            _queryable = _queryable.OrderBy(keySelector);
            return this;//这里做了什么东东？是本来的一个实例的意思？
        }
        public OrderTable<T>Asc<TKey1,TKey2>(Expression<Func<T,TKey1>>keySelector1,Expression<Func<T,TKey2>>keySelector2)
        {
            _queryable = _queryable.OrderBy(keySelector1).OrderBy(keySelector2);
            return this;
        }
        public OrderTable<T>Asc<TKey1,TKey2,TKey3>(Expression<Func<T,TKey1>>keySelector1,Expression<Func<T,TKey2>>keySelector2,Expression<Func<T,TKey3>>keySelector3)
        {
            _queryable = _queryable.OrderBy(keySelector1).OrderBy(keySelector2).OrderBy(keySelector3);
            return this;
        }
        //降顺序排序 最多三个
        public OrderTable<T>Desc<TKey>(Expression<Func<T,TKey>>keySelector)
        {
            _queryable = _queryable.OrderByDescending(keySelector);
            return this;
        }
        public OrderTable<T>Desc<TKey1,TKey2>(Expression<Func<T,TKey1>>keySelector1,Expression<Func<T,TKey2>>keySelector2)
        {
            _queryable = _queryable.OrderByDescending(keySelector1).OrderByDescending(keySelector2);
            return this;
        }
        public OrderTable<T>Desc<TKey1,TKey2,TKey3>(Expression<Func<T,TKey1>>keySelector1,Expression<Func<T,TKey2>>keySeletor2,Expression<Func<T,TKey3>>keySelector3)
        {
            _queryable = _queryable.OrderByDescending(keySelector1).OrderByDescending(keySeletor2).OrderByDescending(keySelector3);
            return this;
        }
    }
}
