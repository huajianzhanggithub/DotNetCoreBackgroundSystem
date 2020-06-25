using Data.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Service.Infrastructure
{
    public interface IBaseService<T>
    {
        T Get(object key);
        T Get(Expression<Func<T, bool>> predicate);
        PageModel<T> SearchPage(PageCondition<T> condition);
        void Delete(Expression<Func<T, bool>> predicate);
        void Update(T entity);
        List<T> Search(Expression<Func<T, bool>> predicate);
    }
}
