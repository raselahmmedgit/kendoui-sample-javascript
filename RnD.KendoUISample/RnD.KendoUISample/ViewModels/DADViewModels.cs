using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace RnD.KendoUISample.ViewModels
{
    public class DADMasterViewModel
    {
        public int DADMasterId { get; set; }

        [DisplayName("Funding Source")]
        public string FundSource { get; set; }

        [DisplayName("Committed")]
        public float CommittedAmount { get; set; }

        [DisplayName("Disbursed")]
        public float DisbursedAmount { get; set; }

        [DisplayName("Expended")]
        public float ExpendedAmount { get; set; }
    }

    public class DADDetailViewModel
    {
        public int DADDetailId { get; set; }

        [DisplayName("Funding Agency")]
        public string FundAgency { get; set; }

        [DisplayName("Committed")]
        public float CommittedAmount { get; set; }

        [DisplayName("Disbursed")]
        public float DisbursedAmount { get; set; }

        [DisplayName("Expended")]
        public float ExpendedAmount { get; set; }

        public int DADMasterViewModelId { get; set; }
        [ForeignKey("DADMasterViewModelId")]
        public virtual DADMasterViewModel DADMasterViewModel { get; set; }
    }

    public class DADDetailItemViewModel
    {
        public int DADDetailItemId { get; set; }

        [DisplayName("Project")]
        public string Project { get; set; }

        [DisplayName("Committed")]
        public float CommittedAmount { get; set; }

        [DisplayName("Disbursed")]
        public float DisbursedAmount { get; set; }

        [DisplayName("Expended")]
        public float ExpendedAmount { get; set; }

        public int DADDetailViewModelId { get; set; }
        [ForeignKey("DADDetailViewModelId")]
        public virtual DADDetailViewModel DADDetailViewModel { get; set; }
    }

    public class FilterViewModel
    {
        public string FundSource { get; set; }
        public string FundAgency { get; set; }
        public string Project { get; set; }
        public string Sector { get; set; }
        public string ProvinceOrArea { get; set; }
        public string DistrictOrAgency { get; set; }
        public string ReferenceNumber { get; set; }
        public string FiscalYear { get; set; }
        public string SubCategoreis { get; set; }
        public int[] SubCategoryList { get; set; }
    }

    public class GridModifyViewModel
    {
        public string FieldOne { get; set; }
        public string FieldTwo { get; set; }
        public string FieldThree { get; set; }
        public string FieldFour { get; set; }
        public string FieldFive { get; set; }
    }

    public class DemoViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public float CommittedAmount { get; set; }

        public float DisbursedAmount { get; set; }

        public float ExpendedAmount { get; set; }

        public int AId { get; set; }
        public string AName { get; set; }

        public int BId { get; set; }
        public string BName { get; set; }

        public int CId { get; set; }
        public string CName { get; set; }

        public int DId { get; set; }
        public string DName { get; set; }

        public int EId { get; set; }
        public string EName { get; set; }
    }

    public class DADModelViewModel
    {
        public int Id { get; set; }

        public int PId { get; set; }

        [DisplayName("Title")]
        public string Title { get; set; }

        [DisplayName("Committed")]
        public float CommittedAmount { get; set; }

        [DisplayName("Disbursed")]
        public float DisbursedAmount { get; set; }

        [DisplayName("Expended")]
        public float ExpendedAmount { get; set; }
    }

}