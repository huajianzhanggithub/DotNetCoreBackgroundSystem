using Data.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Domain.Infrastructure
{
    /// <summary>
    /// 查询接口
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface ISearchRepository<T>
    {
        // 获取单个数据
        /// <summary>
        /// 根据主键获取数据
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        T Get(object key);
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        T Get(Expression<Func<T, bool>> predicate);

        // 统计数量
        /// <summary>
        /// 返回数据库中的数据条目
        /// </summary>
        /// <returns></returns>
        int Count();
        /// <summary>
        /// 返回数据库中的数据条目，类型为Long
        /// </summary>
        /// <returns></returns>
        long LongCount();
        /// <summary>
        /// 返回符合条件的数据数目
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        int Count(Expression<Func<T, bool>> predicate);
        /// <summary>
        /// 返回长整形的符合条件的数目
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        long LongCount(Expression<Func<T, bool>> predicate);

        // 存在性判断
        /// <summary>
        /// 是否存在满足条件的数据
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        bool IsExists(Expression<Func<T, bool>> predicate);

        // 查询
        // <summary>
        /// 返回数据库中所有记录
        /// </summary>
        /// <returns></returns>
        List<T> Search();
        /// <summary>
        /// 返回所有符合条件的数据
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        List<T> Search(Expression<Func<T, bool>> predicate);
        /// <summary>
        /// 返回一个延迟查询的对象
        /// </summary>
        /// <returns></returns>
        IEnumerable<T> Query();
        /// <summary>
        /// 返回一个延迟查询的对象，并预设了一个查询条件
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        IEnumerable<T> Query(Expression<Func<T, bool>> predicate);

        // 排序
        /// <summary>
        /// 排序查询，默认升序
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="order"></param>
        /// <typeparam name="P"></typeparam>
        /// <returns></returns>
        List<T> Search<P>(Expression<Func<T, bool>> predicate, Expression<Func<T, P>> order);
        /// <summary>
        /// 排序查找，指定是否降序排列
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="order"></param>
        /// <param name="isDesc"></param>
        /// <typeparam name="P"></typeparam>
        /// <returns></returns>
        List<T> Search<P>(Expression<Func<T, bool>> predicate, Expression<Func<T, P>> order, bool isDesc);

        // 分页
        PageModel<T> Search(PageCondition<T> condition);
    }
}
