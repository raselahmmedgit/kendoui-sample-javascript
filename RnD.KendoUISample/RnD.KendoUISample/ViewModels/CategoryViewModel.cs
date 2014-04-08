using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RnD.KendoUISample.ViewModels
{
    public class CategoryViewModel
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public bool Select { get; set; }
    }

    public class ParamViewModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        //public string[] IdList { get; set; }
        //public IList<string> IdList { get; set; }
        //public IList<ParamViewModel> ParamViewModelList { get; set; }
    }

    public class ProductViewModel
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public float ProductPrice { get; set; }

        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}