namespace SavingLives_WebApp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BRWorkFlowActionHistory")]
    public partial class BRWorkFlowActionHistory
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int BRWorkFlowActionHistoryID { get; set; }

        public int BloodRequestID { get; set; }

        public int StatusID { get; set; }

        [Required]
        [StringLength(128)]
        public string CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; }

        [Required]
        [StringLength(128)]
        public string LastModifiedBy { get; set; }

        public DateTime LastModifiedDate { get; set; }

        public virtual Status Status { get; set; }
    }
}
