using System;
using System.Collections.Generic;

namespace VetMedPlus.API.Models;

public partial class Treatment
{
    public int TreatmentId { get; set; }

    public int AppointmentId { get; set; }

    public DateTime TreatmentDate { get; set; }

    public string TreatmentType { get; set; } = null!;

    public string? TreatmentDetails { get; set; }

    public virtual ICollection<AppointmentTreatment> AppointmentTreatments { get; } = new List<AppointmentTreatment>();
}
