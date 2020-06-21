using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Domain.Infrastructure
{
    /// <summary>
    /// 修改接口
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IModifyRepository<T>
    {
        /// <summary>
        /// 插入数据
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        T Insert(T entity);
        /// <summary>
        /// 插入数据
        /// </summary>
        /// <param name="entities"></param>
        void Insert(params T[] entities);
        /// <summary>
        /// 插入数据
        /// </summary>
        /// <param name="entities"></param>
        void Insert(IEnumerable<T> entities);
        /// <summary>
        /// 保存已提交的修改
        /// </summary>
        /// <param name="entity"></param>
        void Update(T entity);
        /// <summary>
        /// 保存已提交的修改
        /// </summary>
        /// <param name="entities"></param>
        void Update(params T[] entities);
        /// <summary>
        /// 更新数据
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="updator"></param>
        void Update(Expression<Func<T, bool>> predicate, Expression<Func<T, T>> updator);
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="entity"></param>
        void Delete(T entity);
        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="entities"></param>
        void Delete(params T[] entities);
        /// <summary>
        /// 根据条件删除数据
        /// </summary>
        /// <param name="predicate"></param>
        void Delete(Expression<Func<T, bool>> predicate);
        /// <summary>
        /// 删除主键对应的数据
        /// </summary>
        /// <param name="key"></param>
        void DeleteByKey(object key);
        /// <summary>
        /// 删除主键对应的数据
        /// </summary>
        /// <param name="keys"></param>
        void DeleteByKeys(params object[] keys);
    }
}
