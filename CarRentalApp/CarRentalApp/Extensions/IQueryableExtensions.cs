using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using CarRentalApp.Controllers.Resources;
using CarRentalApp.Core.Model;

namespace CarRentalApp.Extensions
{
    public static class IQueryableExtensions
    {

        public static IQueryable<T> ApplyOrdering<T>(this IQueryable<T> query, IQueryObject queryObject,
            Dictionary<string, Expression<Func<T, object>>> ordering)
        {
            if (String.IsNullOrWhiteSpace(queryObject.SortBy) || !ordering.ContainsKey(queryObject.SortBy))
                return query;

            return queryObject.IsAscending ? 
                query.OrderBy(ordering[queryObject.SortBy])
                : query.OrderByDescending(ordering[queryObject.SortBy]);
        }

        public static IQueryable<T> ApplyPagination<T>(this IQueryable<T> query, IQueryObject queryObject)
        {
            if (queryObject.PageSize <= 0 || queryObject.PageSize >= 100)
            {
                queryObject.PageSize = 10;
            }
            if (queryObject.Page <= 0)
            {
                queryObject.Page = 1;
            }
            return query.Skip((queryObject.Page - 1) * queryObject.PageSize).Take(queryObject.PageSize);
        }

        #region Vehicle

        public static IQueryable<Vehicle> ApplyFiltering(this IQueryable<Vehicle> query, VehicleQuery filterQuery)
        {
            if (filterQuery.MakeId.HasValue)
                query = query.Where(v => v.Model.MakeId == filterQuery.MakeId);

            if (filterQuery.ModelId.HasValue)
                query = query.Where(v => v.ModelId == filterQuery.ModelId);

            return query;
        }

        #endregion
    }
}
