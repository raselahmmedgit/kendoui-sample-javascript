using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Linq.Expressions;

namespace RnD.KendoUISample.Helpers
{
    public class KendoUiHelper
    {
        public static KendoGridResult<T> ParseGridData<T>(IQueryable<T> collection, KendoGridPost requestParams)
        {
            return ReturnGridData<T>(requestParams, ref collection);
        }

        private static KendoGridResult<T> ReturnGridData<T>(KendoGridPost requestParams, ref IQueryable<T> collection)
        {
            List<T> gridData = new List<T>();

            try
            {
                //If the sort Order is provided perform a sort on the specified column
                if (requestParams.SortOrd.IsNotEmpty())
                {
                    var sortCollection = Sort<T>(collection, requestParams.SortOn, requestParams.SortOrd);

                    //If sort and paging
                    gridData = sortCollection.Skip(requestParams.Skip).Take(requestParams.PageSize).ToList();
                }
                if (requestParams.FilterField.IsNotEmpty() && requestParams.FilterOperator.IsNotEmpty() && requestParams.FilterValue.IsNotEmpty())
                {
                    var filterCollection = Filter<T>(collection, requestParams.FilterField, requestParams.FilterOperator, requestParams.FilterValue);

                    //If sort and paging
                    gridData = filterCollection.Skip(requestParams.Skip).Take(requestParams.PageSize).ToList();
                }
                else
                {
                    //If only paging
                    gridData = collection.Skip(requestParams.Skip).Take(requestParams.PageSize).ToList();
                }
            }
            catch
            {

            }

            return new KendoGridResult<T>
            {
                Data = gridData.Count > 0 ? gridData : collection.ToList(),
                Total = collection.Count()
            };
        }

        private static IQueryable<T> Sort<T>(IQueryable<T> collection, string sortOn, string sortOrd)
        {
            var param = Expression.Parameter(typeof(T));

            var sortExpression = Expression.Lambda<Func<T, object>>
                (Expression.Convert(Expression.Property(param, sortOn), typeof(object)), param);

            switch (sortOrd.ToLower())
            {
                case "asc":
                    return collection.AsQueryable<T>().OrderBy<T, object>(sortExpression);
                default:
                    return collection.AsQueryable<T>().OrderByDescending<T, object>(sortExpression);

            }
        }

        private static IQueryable<T> Filter<T>(IQueryable<T> collection, string filterField, string filterOperator, string filterValue)
        {
            IQueryable<T> filteredCollection = from item in collection select item;

            Func<T, bool> expression = item =>
            {
                var itemValue = item.GetType()
                    .GetProperty(filterField)
                    .GetValue(item, null);

                if (itemValue == null)
                {
                    return false;
                }

                var value = filterValue;
                switch (filterOperator)
                {
                    case "eq":
                        return itemValue.ToString() == value;
                    case "startswith":
                        return itemValue.ToString().StartsWith(value);
                    case "contains":
                        return itemValue.ToString().Contains(value);
                    case "endswith":
                        return itemValue.ToString().EndsWith(value);
                }

                return true;
            };

            filteredCollection = filteredCollection.Where(expression).AsQueryable();

            return filteredCollection;
        }

        public class KendoGridResult<T>
        {
            public IEnumerable<T> AggregateResults { get; set; }
            public IEnumerable<T> Data { get; set; }
            public IEnumerable<T> Errors { get; set; }
            public int Total { get; set; }
        }
    }
}