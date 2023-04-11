using System;
using System.Collections.Generic;

namespace VetMedPlus.API.Models;

public partial class PaymentMethod
{
    public int PaymentMethodsId { get; set; }

    public string PaymentMethodsName { get; set; } = null!;

    public virtual ICollection<Appointment> Appointments { get; } = new List<Appointment>();
}
