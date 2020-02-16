namespace SavingLives_WebApp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BloodRequest")]
    public partial class BloodRequest
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int BloodRequestID { get; set; }

        public int ReceiverID { get; set; }

        public int DonorID { get; set; }

        public DateTime ExpectedDate { get; set; }

        public DateTime ReceivedDate { get; set; }

        [Required]
        [StringLength(128)]
        public string CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; }

        [Required]
        [StringLength(128)]
        public string LastModifiedBy { get; set; }

        public DateTime LastModifiedDate { get; set; }

        public virtual DonorDetail DonorDetail { get; set; }

        public virtual ReceiverDetail ReceiverDetail { get; set; }
    }
}
