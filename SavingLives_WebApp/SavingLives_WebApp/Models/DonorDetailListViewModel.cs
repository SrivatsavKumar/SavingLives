using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SavingLives_WebApp.Models
{
    public class DonorDetailListViewModel
    {
        public string UserID { get; set; }
        public int DonorID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailID { get; set; }
        public string PhoneNum { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string BloodGroup { get; set; }
        public string Verified { get; set; }
        public byte[] ProofOfBloodGroup { get; set; }
        public string DonorStatus { get; set; }
        public DateTime CreatedDate { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime lastModifiedDate { get; set; }

    }
}