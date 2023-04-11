﻿using System;
using System.Collections.Generic;

namespace VetMedPlus.API.Models;

public partial class AppointmentTreatment
{
    public int AppointmentTreatmentsId { get; set; }

    public int TreatmentId { get; set; }

    public int AppointmentId { get; set; }

    public virtual Appointment Appointment { get; set; } = null!;

    public virtual Treatment Treatment { get; set; } = null!;
}
