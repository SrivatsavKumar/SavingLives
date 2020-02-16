namespace SavingLives_WebApp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ReceiverDetail
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ReceiverDetail()
        {
            BloodRequests = new HashSet<BloodRequest>();
            NewRequirements = new HashSet<NewRequirement>();
        }

        [Required]
        [StringLength(128)]
        public string UserID { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ReceiverID { get; set; }

        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        [StringLength(50)]
        public string LastName { get; set; }

        [StringLength(30)]
        public string EmailID { get; set; }

        public int PhoneNum { get; set; }

        [Required]
        [StringLength(50)]
        public string Location { get; set; }

        [Required]
        [StringLength(30)]
        public string City { get; set; }

        [StringLength(20)]
        public string State { get; set; }

        [StringLength(20)]
        public string Country { get; set; }

        [Required]
        [StringLength(10)]
        public string Pincode { get; set; }

        [Required]
        [StringLength(128)]
        public string CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; }

        [Required]
        [StringLength(128)]
        public string LastModifiedBy { get; set; }

        public DateTime LastModifiedDate { get; set; }

        public virtual AspNetUser AspNetUser { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BloodRequest> BloodRequests { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NewRequirement> NewRequirements { get; set; }
    }
}
