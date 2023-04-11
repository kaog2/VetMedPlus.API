using System;
using System.Collections.Generic;

namespace VetMedPlus.API.Models;

public partial class Specialization
{
    public int SpecializationsId { get; set; }

    public string SpecializationsName { get; set; } = null!;

    public virtual ICollection<DoctorSpecialization> DoctorSpecializations { get; } = new List<DoctorSpecialization>();
}
