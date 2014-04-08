using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RnD.KendoUISample.Helpers
{
    public class KendoGridPost
    {
        public KendoGridPost()
        {
            if (HttpContext.Current != null)
            {
                HttpRequest curRequest = HttpContext.Current.Request;
                this.Page = curRequest["page"].Parse<int>(1);
                this.PageSize = curRequest["pageSize"].Parse<int>(5);
                this.Skip = curRequest["skip"].Parse<int>(0);
                this.Take = curRequest["take"].Parse<int>(5);

                this.SortOrd = curRequest["sort[0][dir]"];
                this.SortOn = curRequest["sort[0][field]"];

                this.FilterLogic = curRequest["filter[logic]"];

                this.FilterField = curRequest["filter[filters][0][field]"];
                this.FilterOperator = curRequest["filter[filters][0][operator]"];
                this.FilterValue = curRequest["filter[filters][0][value]"];

                //this.Export = curRequest["export"];
            }
        }

        public int Page { get; set; }
        public int PageSize { get; set; }
        public int Skip { get; set; }
        public int Take { get; set; }

        public string SortOrd { get; set; }
        public string SortOn { get; set; }

        public List<SortDescription> SortDescriptions { get; set; }

        public string FilterLogic { get; set; }

        public string FilterField { get; set; }
        public string FilterOperator { get; set; }
        public string FilterValue { get; set; }
        public List<FilterDescription> FilterDescriptions { get; set; }

        //public string Export { get; set; }
    }

    public class SortDescription
    {
        public string SortField { get; set; }
        public string SortDir { get; set; }
    }

    public class FilterDescription
    {
        //"filter[filters][0][field]"
        //"filter[filters][0][operator]"
        //"filter[filters][0][value]"

        public string FilterField { get; set; }
        public string FilterOperator { get; set; }
        public string FilterValue { get; set; }
    }

}