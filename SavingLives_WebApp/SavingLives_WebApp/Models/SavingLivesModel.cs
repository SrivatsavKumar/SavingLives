namespace SavingLives_WebApp.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class SavingLivesModel : DbContext
    {
        public SavingLivesModel()
            : base("name=SavingLivesProject")
        {
        }

        public virtual DbSet<AspNetRole> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUserRole> AspNetUserRoles { get; set; }
        public virtual DbSet<AspNetUser> AspNetUsers { get; set; }
        public virtual DbSet<AvailOfBloodInBank> AvailOfBloodInBanks { get; set; }
        public virtual DbSet<BloodGroupDetail> BloodGroupDetails { get; set; }
        public virtual DbSet<BloodRequest> BloodRequests { get; set; }
        public virtual DbSet<BRWorkFlowActionHistory> BRWorkFlowActionHistories { get; set; }
        public virtual DbSet<DonorDetail> DonorDetails { get; set; }
        public virtual DbSet<DonorLastDonatedDetail> DonorLastDonatedDetails { get; set; }
        public virtual DbSet<NewRequirement> NewRequirements { get; set; }
        public virtual DbSet<ReceiverDetail> ReceiverDetails { get; set; }
        public virtual DbSet<Status> Status { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AspNetUser>()
                .HasMany(e => e.DonorDetails)
                .WithRequired(e => e.AspNetUser)
                .HasForeignKey(e => e.UserID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<AspNetUser>()
                .HasMany(e => e.ReceiverDetails)
                .WithRequired(e => e.AspNetUser)
                .HasForeignKey(e => e.UserID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<AvailOfBloodInBank>()
                .Property(e => e.BloodGroupName)
                .IsUnicode(false);

            modelBuilder.Entity<BloodGroupDetail>()
                .Property(e => e.BloodGroupName)
                .IsUnicode(false);

            modelBuilder.Entity<BloodGroupDetail>()
                .HasMany(e => e.AvailOfBloodInBanks)
                .WithRequired(e => e.BloodGroupDetail)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<BloodGroupDetail>()
                .HasMany(e => e.NewRequirements)
                .WithRequired(e => e.BloodGroupDetail)
                .HasForeignKey(e => e.BloodGroupDetialsID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DonorDetail>()
                .Property(e => e.EmailID)
                .IsUnicode(false);

            modelBuilder.Entity<DonorDetail>()
                .Property(e => e.Address)
                .IsUnicode(false);

            modelBuilder.Entity<DonorDetail>()
                .Property(e => e.City)
                .IsUnicode(false);

            modelBuilder.Entity<DonorDetail>()
                .Property(e => e.State)
                .IsUnicode(false);

            modelBuilder.Entity<DonorDetail>()
                .Property(e => e.Country)
                .IsUnicode(false);

            modelBuilder.Entity<DonorDetail>()
                .Property(e => e.Verified)
                .IsUnicode(false);

            modelBuilder.Entity<DonorDetail>()
                .Property(e => e.DonorStatus)
                .IsUnicode(false);

            modelBuilder.Entity<DonorDetail>()
                .HasMany(e => e.BloodRequests)
                .WithRequired(e => e.DonorDetail)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DonorDetail>()
                .HasMany(e => e.DonorLastDonatedDetails)
                .WithRequired(e => e.DonorDetail)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ReceiverDetail>()
                .Property(e => e.EmailID)
                .IsUnicode(false);

            modelBuilder.Entity<ReceiverDetail>()
                .Property(e => e.Location)
                .IsUnicode(false);

            modelBuilder.Entity<ReceiverDetail>()
                .Property(e => e.City)
                .IsUnicode(false);

            modelBuilder.Entity<ReceiverDetail>()
                .Property(e => e.State)
                .IsUnicode(false);

            modelBuilder.Entity<ReceiverDetail>()
                .Property(e => e.Country)
                .IsUnicode(false);

            modelBuilder.Entity<ReceiverDetail>()
                .Property(e => e.Pincode)
                .IsUnicode(false);

            modelBuilder.Entity<ReceiverDetail>()
                .HasMany(e => e.BloodRequests)
                .WithRequired(e => e.ReceiverDetail)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ReceiverDetail>()
                .HasMany(e => e.NewRequirements)
                .WithRequired(e => e.ReceiverDetail)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Status>()
                .HasMany(e => e.BRWorkFlowActionHistories)
                .WithRequired(e => e.Status)
                .WillCascadeOnDelete(false);
        }
    }
}
