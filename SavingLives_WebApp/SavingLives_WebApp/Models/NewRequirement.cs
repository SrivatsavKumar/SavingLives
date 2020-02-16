namespace SavingLives_WebApp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class NewRequirement
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int NewRequirementID { get; set; }

        public int ReceiverID { get; set; }

        public int BloodGroupDetialsID { get; set; }

        public DateTime ExpectedDate { get; set; }

        public int NumOfUnitsReq { get; set; }

        [Required]
        [StringLength(128)]
        public string CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; }

        [Required]
        [StringLength(128)]
        public string LastModifiedBy { get; set; }

        public DateTime LastModifiedDate { get; set; }

        public virtual BloodGroupDetail BloodGroupDetail { get; set; }

        public virtual ReceiverDetail ReceiverDetail { get; set; }
    }
}
