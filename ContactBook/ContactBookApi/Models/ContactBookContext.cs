using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ContactBookApi.Models
{
    public partial class ContactBookContext : DbContext
    {
        public ContactBookContext(DbContextOptions<ContactBookContext> options) : base(options)
        {
        }

        public virtual DbSet<Address> Address { get; set; }
        public virtual DbSet<AddressType> AddressType { get; set; }
        public virtual DbSet<Contact> Contact { get; set; }
        public virtual DbSet<Email> Email { get; set; }
        public virtual DbSet<EmailType> EmailType { get; set; }
        public virtual DbSet<Event> Event { get; set; }
        public virtual DbSet<EventType> EventType { get; set; }
        public virtual DbSet<Phone> Phone { get; set; }
        public virtual DbSet<PhoneType> PhoneType { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<Website> Website { get; set; }
        public virtual DbSet<WebsiteType> WebsiteType { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Address>(entity =>
            {
                entity.Property(e => e.Address1).HasMaxLength(60);

                entity.Property(e => e.Address2).HasMaxLength(60);

                entity.Property(e => e.City).HasMaxLength(50);

                entity.Property(e => e.Country).HasMaxLength(60);

                entity.Property(e => e.PostalCode).HasMaxLength(10);

                entity.Property(e => e.StateProvince).HasMaxLength(50);

                entity.HasOne(d => d.AddressType)
                    .WithMany(p => p.Address)
                    .HasForeignKey(d => d.AddressTypeId)
                    .HasConstraintName("FK_Address_AddressType");

                entity.HasOne(d => d.Contact)
                    .WithMany(p => p.Address)
                    .HasForeignKey(d => d.ContactId)
                    .HasConstraintName("FK_Address_Contact");
            });

            modelBuilder.Entity<AddressType>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Contact>(entity =>
            {
                entity.Property(e => e.Company).HasMaxLength(50);

                entity.Property(e => e.JobTitle).HasMaxLength(50);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.Notes).HasMaxLength(500);

                entity.Property(e => e.PreferredName).HasMaxLength(50);

                entity.Property(e => e.PreviousNames).HasMaxLength(250);

                entity.Property(e => e.Relationship).HasMaxLength(50);

                entity.Property(e => e.Title).HasMaxLength(50);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Contact)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Contact_User");
            });

            modelBuilder.Entity<Email>(entity =>
            {
                entity.Property(e => e.EmailAddress)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.HasOne(d => d.Contact)
                    .WithMany(p => p.Email)
                    .HasForeignKey(d => d.ContactId)
                    .HasConstraintName("FK_Email_Contact");

                entity.HasOne(d => d.EmailType)
                    .WithMany(p => p.Email)
                    .HasForeignKey(d => d.EmailTypeId)
                    .HasConstraintName("FK_Email_EmailType");
            });

            modelBuilder.Entity<EmailType>(entity =>
            {
                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<Event>(entity =>
            {
                entity.HasOne(d => d.Contact)
                    .WithMany(p => p.Event)
                    .HasForeignKey(d => d.ContactId)
                    .HasConstraintName("FK_Event_Contact");

                entity.HasOne(d => d.EventType)
                    .WithMany(p => p.Event)
                    .HasForeignKey(d => d.EventTypeId)
                    .HasConstraintName("FK_Event_EventType");
            });

            modelBuilder.Entity<EventType>(entity =>
            {
                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<Phone>(entity =>
            {
                entity.Property(e => e.Number)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.HasOne(d => d.Contact)
                    .WithMany(p => p.Phone)
                    .HasForeignKey(d => d.ContactId)
                    .HasConstraintName("FK_Phone_Contact");

                entity.HasOne(d => d.PhoneType)
                    .WithMany(p => p.Phone)
                    .HasForeignKey(d => d.PhoneTypeId)
                    .HasConstraintName("FK_Phone_PhoneType");
            });

            modelBuilder.Entity<PhoneType>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasIndex(e => e.UserId)
                    .HasName("IX_User");

                entity.Property(e => e.Active).HasDefaultValueSql("((1))");

                entity.Property(e => e.CreatedDate).HasDefaultValueSql("(sysutcdatetime())");

                entity.Property(e => e.FullName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.LogonName).HasMaxLength(50);

                entity.Property(e => e.PreferredName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Website>(entity =>
            {
                entity.Property(e => e.Url)
                    .IsRequired()
                    .HasColumnName("URL")
                    .HasMaxLength(256);

                entity.HasOne(d => d.Contact)
                    .WithMany(p => p.Website)
                    .HasForeignKey(d => d.ContactId)
                    .HasConstraintName("FK_Website_Contact");

                entity.HasOne(d => d.WebsiteType)
                    .WithMany(p => p.Website)
                    .HasForeignKey(d => d.WebsiteTypeId)
                    .HasConstraintName("FK_Website_WebsiteType");
            });

            modelBuilder.Entity<WebsiteType>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });
        }
    }
}
