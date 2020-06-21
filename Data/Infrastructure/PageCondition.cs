using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Data.Infrastructure
{
    /// <summary>
    /// 分页条件模型
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class PageCondition<T>
    {
        /// <summary>
        /// 查询条件
        /// </summary>
        public Expression<Func<T, bool>> Predicate { get; set; }
        /// <summary>
        /// 排序属性
        /// </summary>
        public string OrderProperty { get; set; }
        /// <summary>
        /// 升序排序或者降序排序，升序为asc或者空，降序为desc
        /// </summary>
        public string Sort { get; set; }
        /// <summary>
        /// 每页最大数据容量
        /// </summary>
        public int PerpageSize { get; set; }
        /// <summary>
        /// 当前页
        /// </summary>
        public int CurrentPage { get; set; }

    }
}
