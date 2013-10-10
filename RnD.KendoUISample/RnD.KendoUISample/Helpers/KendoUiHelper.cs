using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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

            //If the sort Order is provided perform a sort on the specified column
            if (requestParams.SortOrd.IsNotEmpty())
            {
                //Test
                var qqq = collection.ToList();

                var ddd = collection.OrderByDescending(x => x.GetType().GetProperty(requestParams.SortOn));
                var aaa = collection.OrderBy(x => x.GetType().GetProperty(requestParams.SortOn));

                var ddd1 = qqq.OrderByDescending(x => x.GetType().GetProperty(requestParams.SortOn));
                var aaa1 = qqq.OrderBy(x => x.GetType().GetProperty(requestParams.SortOn));
                //Test
                
                collection = requestParams.SortOrd == "desc"
                             ? collection.OrderByDescending(x => requestParams.SortOn)
                             : collection.OrderBy(x => requestParams.SortOn);
            }

            List<T> gridData;
            try
            {
                gridData = collection.Skip(requestParams.Skip).Take(requestParams.PageSize).ToList();
            }
            catch
            {
                //collection = collection.OrderBy("id");
                gridData = collection.Skip(requestParams.Skip).Take(requestParams.PageSize).ToList();
            }

            //var collectionType = typeof(T);
            //var collectionProperties = collectionType.GetProperties();
            //gridData.ForEach(row => {
            //    foreach (var cProp in collectionProperties)
            //    {
            //        var pVal = cProp.GetValue(row, null);
            //        if (pVal == null)
            //        {
            //            cProp.SetValue(row, "", null);
            //        }
            //    }
            //});

            return new KendoGridResult<T>
            {
                Data = gridData,
                Total = collection.Count()
            };
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