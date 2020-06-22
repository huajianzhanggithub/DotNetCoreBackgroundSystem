using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Text.RegularExpressions;

namespace Utils.Extend.Lambda
{
    public static class ExtLinq
    {
        public static IQueryable<T> CreateOrderExpression<T>(this IQueryable<T> source, string orderBy, string orderAsc)
        {
            if (string.IsNullOrEmpty(orderBy) || string.IsNullOrEmpty(orderAsc))
            {
                return source;
            }
            var isAsc = orderAsc.ToUpper() == "ASC";
            var _order = orderBy.Split(',');
            MethodCallExpression resultExp = null;
            foreach (var item in _order)
            {
                var orderPart = item;
                orderPart = Regex.Replace(orderPart, @"\s+", " ");
                var orderArray = orderPart.Split(' ');
                var orderField = orderArray[0];
                if (orderArray.Length==2)
                {

                }
            }
        }
    }
}
