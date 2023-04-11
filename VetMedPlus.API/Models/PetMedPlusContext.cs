using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace VetMedPlus.API.Models;

public partial class PetMedPlusContext : DbContext
{
    public PetMedPlusContext()
    {
    }

    public PetMedPlusContext(DbContextOptions<PetMedPlusContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Address> Addresses { get; set; }

    public virtual DbSet<Animal> Animals { get; set; }

    public virtual DbSet<AnimalType> AnimalTypes { get; set; }

    public virtual DbSet<Appointment> Appointments { get; set; }

    public virtual DbSet<AppointmentTreatment> AppointmentTreatments { get; set; }

    public virtual DbSet<Client> Clients { get; set; }

    public virtual DbSet<Doctor> Doctors { get; set; }

    public virtual DbSet<DoctorSpecialization> DoctorSpecializations { get; set; }

    public virtual DbSet<PaymentMethod> PaymentMethods { get; set; }

    public virtual DbSet<Right> Rights { get; set; }

    public virtual DbSet<Specialization> Specializations { get; set; }

    public virtual DbSet<StatusAppointmentType> StatusAppointmentTypes { get; set; }

    public virtual DbSet<Treatment> Treatments { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserRight> UserRights { get; set; }

    public virtual DbSet<UserType> UserTypes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=LAPTOP-EIA3MJA1\\KAOGSQLSERVER;Database=PetMedPlus;Integrated Security=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Address>(entity =>
        {
            entity.HasKey(e => e.AddressId).HasName("PK__Address__091C2AFBBBAB82D7");

            entity.ToTable("Address");

            entity.Property(e => e.AddressBirthdate).HasColumnType("date");
            entity.Property(e => e.AddressCity)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.AddressCountry)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.AddressCreatedDate).HasColumnType("date");
            entity.Property(e => e.AddressEmail)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.AddressFirstName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.AddressLastName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.AddressPhone)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.AddressPostalCode)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.AddressStreet)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.AddressUpdateDate).HasColumnType("date");
        });

        modelBuilder.Entity<Animal>(entity =>
        {
            entity.HasKey(e => e.AnimalId).HasName("PK__Animals__A21A73072873E721");

            entity.Property(e => e.AnimalName)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.AnimalOwner).WithMany(p => p.Animals)
                .HasForeignKey(d => d.AnimalOwnerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Animals_AddressId");

            entity.HasOne(d => d.AnimalType).WithMany(p => p.Animals)
                .HasForeignKey(d => d.AnimalTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Animals_AnimalTypeId");
        });

        modelBuilder.Entity<AnimalType>(entity =>
        {
            entity.HasKey(e => e.AnimalTypeId).HasName("PK__AnimalTy__1E8A48B6A99159B6");

            entity.ToTable("AnimalType");

            entity.Property(e => e.AnimalTypeName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Appointment>(entity =>
        {
            entity.HasKey(e => e.AppointmentId).HasName("PK__Appointm__8ECDFCC27C6BD0D7");

            entity.Property(e => e.AppointmentDate).HasColumnType("date");
            entity.Property(e => e.AppointmentNotes)
                .HasMaxLength(255)
                .IsUnicode(false);

            entity.HasOne(d => d.AppointmentAnimal).WithMany(p => p.Appointments)
                .HasForeignKey(d => d.AppointmentAnimalId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_appointments_patient");

            entity.HasOne(d => d.AppointmentDoctor).WithMany(p => p.Appointments)
                .HasForeignKey(d => d.AppointmentDoctorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_appointments_doctor");

            entity.HasOne(d => d.AppointmentPaymentMethod).WithMany(p => p.Appointments)
                .HasForeignKey(d => d.AppointmentPaymentMethodId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_appointments_PaymentMethods");

            entity.HasOne(d => d.AppointmentStatusType).WithMany(p => p.Appointments)
                .HasForeignKey(d => d.AppointmentStatusTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_appointments_status");
        });

        modelBuilder.Entity<AppointmentTreatment>(entity =>
        {
            entity.HasKey(e => e.AppointmentTreatmentsId).HasName("PK__Appointm__058BBA3348812DE8");

            entity.HasOne(d => d.Appointment).WithMany(p => p.AppointmentTreatments)
                .HasForeignKey(d => d.AppointmentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_AppointmentTreatments_Appointment");

            entity.HasOne(d => d.Treatment).WithMany(p => p.AppointmentTreatments)
                .HasForeignKey(d => d.TreatmentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_AppointmentTreatments_Treatment");
        });

        modelBuilder.Entity<Client>(entity =>
        {
            entity.HasKey(e => e.AddressId).HasName("PK_Client_Address");

            entity.Property(e => e.AddressId).ValueGeneratedNever();

            entity.HasOne(d => d.Address).WithOne(p => p.Client)
                .HasForeignKey<Client>(d => d.AddressId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Clients_AddressId");
        });

        modelBuilder.Entity<Doctor>(entity =>
        {
            entity.HasKey(e => e.AddressId).HasName("PK_Doctors_Address");

            entity.Property(e => e.AddressId).ValueGeneratedNever();
            entity.Property(e => e.LicenseNumber)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.HasOne(d => d.Address).WithOne(p => p.Doctor)
                .HasForeignKey<Doctor>(d => d.AddressId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Doctors_AddressId");
        });

        modelBuilder.Entity<DoctorSpecialization>(entity =>
        {
            entity.HasKey(e => e.DoctorSpecializationsId).HasName("PK__DoctorSp__3B57C10DFE7506C6");

            entity.HasOne(d => d.Address).WithMany(p => p.DoctorSpecializations)
                .HasForeignKey(d => d.AddressId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_DoctorSpecializations_AddressId");

            entity.HasOne(d => d.Specializations).WithMany(p => p.DoctorSpecializations)
                .HasForeignKey(d => d.SpecializationsId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_DoctorSpecializations_Specializations");
        });

        modelBuilder.Entity<PaymentMethod>(entity =>
        {
            entity.HasKey(e => e.PaymentMethodsId).HasName("PK__PaymentM__85C0F99358F37CE5");

            entity.Property(e => e.PaymentMethodsName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Right>(entity =>
        {
            entity.HasKey(e => e.RightsId).HasName("PK__Rights__91C6477177AA81C5");

            entity.Property(e => e.RightsId).ValueGeneratedNever();
            entity.Property(e => e.RightsDescription)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.RightsName)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Specialization>(entity =>
        {
            entity.HasKey(e => e.SpecializationsId).HasName("PK__Speciali__F1F63AAE112205C4");

            entity.Property(e => e.SpecializationsName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<StatusAppointmentType>(entity =>
        {
            entity.HasKey(e => e.StatusAppointmentTypeId).HasName("PK__StatusAp__0D57BD3EF56DD311");

            entity.ToTable("StatusAppointmentType");

            entity.Property(e => e.StatusAppointmentTypeName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Treatment>(entity =>
        {
            entity.HasKey(e => e.TreatmentId).HasName("PK__Treatmen__1A57B7F1791A3C7D");

            entity.Property(e => e.TreatmentDate).HasColumnType("datetime");
            entity.Property(e => e.TreatmentDetails).HasColumnType("text");
            entity.Property(e => e.TreatmentType)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Users__1788CC4C50AD13B3");

            entity.Property(e => e.CreatedDate).HasColumnType("date");
            entity.Property(e => e.Password)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Username)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Address).WithMany(p => p.Users)
                .HasForeignKey(d => d.AddressId)
                .HasConstraintName("fk_Users_Address");

            entity.HasOne(d => d.UserType).WithMany(p => p.Users)
                .HasForeignKey(d => d.UserTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Users_UserType");
        });

        modelBuilder.Entity<UserRight>(entity =>
        {
            entity.HasKey(e => e.UserRightsId).HasName("PK__UserRigh__968F09B9C1CB423C");

            entity.Property(e => e.UserRightsId).ValueGeneratedNever();

            entity.HasOne(d => d.Rights).WithMany(p => p.UserRights)
                .HasForeignKey(d => d.RightsId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_RoleRights_Rights");

            entity.HasOne(d => d.User).WithMany(p => p.UserRights)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_RoleRights_User");
        });

        modelBuilder.Entity<UserType>(entity =>
        {
            entity.HasKey(e => e.UserTypeId).HasName("PK__UserType__40D2D816359B2404");

            entity.ToTable("UserType");

            entity.Property(e => e.UserTypeId).ValueGeneratedNever();
            entity.Property(e => e.UserTypeDescription)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.UserTypeName)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
