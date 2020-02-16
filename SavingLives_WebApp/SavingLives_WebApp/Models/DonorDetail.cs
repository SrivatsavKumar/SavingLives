namespace SavingLives_WebApp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class DonorDetail
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DonorDetail()
        {
            BloodRequests = new HashSet<BloodRequest>();
            DonorLastDonatedDetails = new HashSet<DonorLastDonatedDetail>();
        }

        [Required]
        [StringLength(128)]
        public string UserID { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int DonorID { get; set; }

        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        [StringLength(50)]
        public string LastName { get; set; }

        [Required]
        [StringLength(30)]
        public string EmailID { get; set; }

        [Required]
        [StringLength(20)]
        public string PhoneNum { get; set; }

        [Required]
        [StringLength(100)]
        public string Address { get; set; }

        [Required]
        [StringLength(30)]
        public string City { get; set; }

        [Required]
        [StringLength(20)]
        public string State { get; set; }

        [StringLength(20)]
        public string Country { get; set; }

        [Required]
        [StringLength(10)]
        public string BloodGroup { get; set; }

        [Required]
        [StringLength(3)]
        public string Verified { get; set; }

        [Column(TypeName = "image")]
        public byte[] ProofOfBloodGroup { get; set; }

        [Required]
        [StringLength(10)]
        public string DonorStatus { get; set; }

        [Required]
        [StringLength(128)]
        public string CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; }

        [Required]
        [StringLength(128)]
        public string LastModifiedBy { get; set; }

        public DateTime lastModifiedDate { get; set; }

        public virtual AspNetUser AspNetUser { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BloodRequest> BloodRequests { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DonorLastDonatedDetail> DonorLastDonatedDetails { get; set; }
    }
}
