using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
namespace IceboxAssets.DataAccess
{
    public interface IRepository <T>
    {
        //因为对象是引用类型，所以增加后，会改变传递进来的对象的值
        void Add(T entity);
        void Delete(T entity);
        void Update(T entity);
        //复制？
        void Copy(T source, T target);
        //刷新？
        void Flush();

        T GetById(int id);
        T GetByExpression(Expression<Func<T, bool>>predicate/*谓语*/);

        int Count(Expression<Func<T, bool>> predicate);
        IEnumerable<T> Fetch(Expression<Func<T, bool>>predicate);/*fetch 拿来， 范围 */
        IEnumerable<T> Fetch(Expression<Func<T, bool>> predicate, Action<OrderTable<T>> order);/*可以排序*/
        IEnumerable<T> Fetch(Expression<Func<T, bool>> predicate, Action<OrderTable<T>> order, int shipCout, int takeCout);/*可排序和分页*/

    }
}
