using System;
using System.Collections.Generic;

namespace VetMedPlus.API.Models;

public partial class Doctor
{
    public int AddressId { get; set; }

    public string LicenseNumber { get; set; } = null!;

    public virtual Address Address { get; set; } = null!;

    public virtual ICollection<Appointment> Appointments { get; } = new List<Appointment>();

    public virtual ICollection<DoctorSpecialization> DoctorSpecializations { get; } = new List<DoctorSpecialization>();
}
