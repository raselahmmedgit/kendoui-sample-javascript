using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace RnD.KendoUISample.Models
{
    public class DADModel
    {
        [Key]
        public int Id { get; set; }

        [DisplayName("Funding Source")]
        public int FundSourceId { get; set; }

        [DisplayName("Funding Agency")]
        public int FundAgencyId { get; set; }

        [DisplayName("Project")]
        public int ProjectId { get; set; }

        [DisplayName("Committed")]
        public float CommittedAmount { get; set; }

        [DisplayName("Disbursed")]
        public float DisbursedAmount { get; set; }

        [DisplayName("Expended")]
        public float ExpendedAmount { get; set; }
    }

    public class DADMaster
    {
        [Key]
        public int DADMasterId { get; set; }

        [DisplayName("Funding Source")]
        public string FundSource { get; set; }

        //[DisplayName("Committed")]
        //public float CommittedAmount { get; set; }

        //[DisplayName("Disbursed")]
        //public float DisbursedAmount { get; set; }

        //[DisplayName("Expended")]
        //public float ExpendedAmount { get; set; }
    }

    public class DADDetail
    {
        [Key]
        public int DADDetailId { get; set; }

        [DisplayName("Funding Agency")]
        public string FundAgency { get; set; }

        //[DisplayName("Committed")]
        //public float CommittedAmount { get; set; }

        //[DisplayName("Disbursed")]
        //public float DisbursedAmount { get; set; }

        //[DisplayName("Expended")]
        //public float ExpendedAmount { get; set; }

        public int DADMasterId { get; set; }
        [ForeignKey("DADMasterId")]
        public virtual DADMaster DADMaster { get; set; }
    }

    public class DADDetailItem
    {
        [Key]
        public int DADDetailItemId { get; set; }

        [DisplayName("Project")]
        public string Project { get; set; }

        [DisplayName("Committed")]
        public float CommittedAmount { get; set; }

        [DisplayName("Disbursed")]
        public float DisbursedAmount { get; set; }

        [DisplayName("Expended")]
        public float ExpendedAmount { get; set; }

        public int DADDetailId { get; set; }
        [ForeignKey("DADDetailId")]
        public virtual DADDetail DADDetail { get; set; }
    }

    public class A_Model
    {
        [Key]
        public int A_ModelId { get; set; }

        [DisplayName("Name")]
        public string A_Name { get; set; }

        [DisplayName("Committed")]
        public float CommittedAmount { get; set; }

        [DisplayName("Disbursed")]
        public float DisbursedAmount { get; set; }

        [DisplayName("Expended")]
        public float ExpendedAmount { get; set; }

    }

    public class B_Model
    {
        [Key]
        public int B_ModelId { get; set; }

        [DisplayName("Name")]
        public string B_Name { get; set; }

        [DisplayName("Committed")]
        public float CommittedAmount { get; set; }

        [DisplayName("Disbursed")]
        public float DisbursedAmount { get; set; }

        [DisplayName("Expended")]
        public float ExpendedAmount { get; set; }

    }

    public class C_Model
    {
        [Key]
        public int C_ModelId { get; set; }

        [DisplayName("Name")]
        public string C_Name { get; set; }

        [DisplayName("Committed")]
        public float CommittedAmount { get; set; }

        [DisplayName("Disbursed")]
        public float DisbursedAmount { get; set; }

        [DisplayName("Expended")]
        public float ExpendedAmount { get; set; }

    }

    public class D_Model
    {
        [Key]
        public int D_ModelId { get; set; }

        [DisplayName("Name")]
        public string D_Name { get; set; }

        [DisplayName("Committed")]
        public float CommittedAmount { get; set; }

        [DisplayName("Disbursed")]
        public float DisbursedAmount { get; set; }

        [DisplayName("Expended")]
        public float ExpendedAmount { get; set; }

    }

    public class E_Model
    {
        [Key]
        public int E_ModelId { get; set; }

        [DisplayName("Name")]
        public string E_Name { get; set; }

        [DisplayName("Committed")]
        public float CommittedAmount { get; set; }

        [DisplayName("Disbursed")]
        public float DisbursedAmount { get; set; }

        [DisplayName("Expended")]
        public float ExpendedAmount { get; set; }

        public int A_ModelId { get; set; }

        public int B_ModelId { get; set; }

        public int C_ModelId { get; set; }

        public int D_ModelId { get; set; }

    }

    public class Ok_Model
    {
        [Key]
        public int Ok_ModelId { get; set; }

        [DisplayName("Name")]
        public string Ok_Name { get; set; }

        [DisplayName("Committed")]
        public float CommittedAmount { get; set; }

        [DisplayName("Disbursed")]
        public float DisbursedAmount { get; set; }

        [DisplayName("Expended")]
        public float ExpendedAmount { get; set; }

        public int A_ModelId { get; set; }

        public int B_ModelId { get; set; }

        public int C_ModelId { get; set; }

        public int D_ModelId { get; set; }

        public int E_ModelId { get; set; }

    }
}