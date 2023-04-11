using System;
using System.Collections.Generic;

namespace VetMedPlus.API.Models;

public partial class DoctorSpecialization
{
    public int DoctorSpecializationsId { get; set; }

    public int AddressId { get; set; }

    public int SpecializationsId { get; set; }

    public virtual Doctor Address { get; set; } = null!;

    public virtual Specialization Specializations { get; set; } = null!;
}
