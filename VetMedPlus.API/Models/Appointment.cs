using System;
using System.Collections.Generic;

namespace VetMedPlus.API.Models;

public partial class Appointment
{
    public int AppointmentId { get; set; }

    public int AppointmentDoctorId { get; set; }

    public int AppointmentAnimalId { get; set; }

    public DateTime AppointmentDate { get; set; }

    public TimeSpan AppointmentTime { get; set; }

    public string? AppointmentNotes { get; set; }

    public int AppointmentStatusTypeId { get; set; }

    public int AppointmentPaymentMethodId { get; set; }

    public virtual Animal AppointmentAnimal { get; set; } = null!;

    public virtual Doctor AppointmentDoctor { get; set; } = null!;

    public virtual PaymentMethod AppointmentPaymentMethod { get; set; } = null!;

    public virtual StatusAppointmentType AppointmentStatusType { get; set; } = null!;

    public virtual ICollection<AppointmentTreatment> AppointmentTreatments { get; } = new List<AppointmentTreatment>();
}
