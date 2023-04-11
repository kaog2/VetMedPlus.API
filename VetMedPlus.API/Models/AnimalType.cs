using System;
using System.Collections.Generic;

namespace VetMedPlus.API.Models;

public partial class AnimalType
{
    public int AnimalTypeId { get; set; }

    public string AnimalTypeName { get; set; } = null!;

    public virtual ICollection<Animal> Animals { get; } = new List<Animal>();
}
