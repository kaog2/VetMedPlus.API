using System;
using System.Collections.Generic;

namespace VetMedPlus.API.Models;

public partial class Animal
{
    public int AnimalId { get; set; }

    public string AnimalName { get; set; } = null!;

    public int AnimalTypeId { get; set; }

    public int AnimalOwnerId { get; set; }

    public virtual Client AnimalOwner { get; set; } = null!;

    public virtual AnimalType AnimalType { get; set; } = null!;

    public virtual ICollection<Appointment> Appointments { get; } = new List<Appointment>();
}
