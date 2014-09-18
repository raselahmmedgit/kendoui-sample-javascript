using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RnD.KendoUISample.ViewModels
{
    public class MasterViewModel
    {
        public int MasterId { get; set; }
        public string MasterName { get; set; }
    }

    public class DetailsViewModel
    {
        public int DetailsId { get; set; }
        public string DetailsName { get; set; }
        public int MasterId { get; set; }
    }

    public class ItemViewModel
    {
        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public int MasterId { get; set; }
        public int DetailsId { get; set; }
    }
}