namespace SavingLives_WebApp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("AvailOfBloodInBank")]
    public partial class AvailOfBloodInBank
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        public int BloodGroupDetailsID { get; set; }

        [Required]
        [StringLength(5)]
        public string BloodGroupName { get; set; }

        public int? NumOfUnitsAvail { get; set; }

        public DateTime ExpiryDate { get; set; }

        [Required]
        [StringLength(128)]
        public string CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; }

        [Required]
        [StringLength(128)]
        public string LastModifiedBy { get; set; }

        public DateTime LastModifiedDate { get; set; }

        public virtual BloodGroupDetail BloodGroupDetail { get; set; }
    }
}
