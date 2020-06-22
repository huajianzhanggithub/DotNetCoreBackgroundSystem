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
                    isAsc = orderArray[1].ToUpper() == "ASC";
                }
                var parameter = Expression.Parameter(typeof(T), "t");
                var property = typeof(T).GetProperty(orderField);
                var propertyAccess = Expression.MakeMemberAccess(parameter, property);
                var orderByExp = Expression.Lambda(propertyAccess, parameter);
                resultExp = Expression.Call(typeof(Queryable), isAsc ? "OrderBy" : "OrderByDescending", new[] { typeof(T), property.PropertyType }, source.Expression, Expression.Quote(orderByExp));
            }
            return resultExp == null ? source : source.Provider.CreateQuery<T>(resultExp);
        }
    }
}
