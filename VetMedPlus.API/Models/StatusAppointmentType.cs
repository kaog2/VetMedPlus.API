using System;
using System.Collections.Generic;

namespace VetMedPlus.API.Models;

public partial class StatusAppointmentType
{
    public int StatusAppointmentTypeId { get; set; }

    public string StatusAppointmentTypeName { get; set; } = null!;

    public virtual ICollection<Appointment> Appointments { get; } = new List<Appointment>();
}
