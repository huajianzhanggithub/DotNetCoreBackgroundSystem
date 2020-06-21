using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Infrastructure
{
    /// <summary>
    /// 分页结果
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class PageModel<T>
    {
        /// <summary>
        /// 数据
        /// </summary>
        public List<T> Items { get; set; }
        /// <summary>
        /// 当前页
        /// </summary>
        public int CurrentPage { get; set; }
        /// <summary>
        /// 每页最大数据容量
        /// </summary>
        public int PerpageSize { get; set; }
        /// <summary>
        /// 查询数据总数
        /// </summary>
        public long TotalCount { get; set; }
        /// <summary>
        /// 总页码
        /// </summary>
        public int TotalPages { get; set; }
    }
}
