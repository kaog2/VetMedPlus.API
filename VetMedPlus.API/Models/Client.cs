using System;
using System.Collections.Generic;

namespace VetMedPlus.API.Models;

public partial class Client
{
    public int AddressId { get; set; }

    public virtual Address Address { get; set; } = null!;

    public virtual ICollection<Animal> Animals { get; } = new List<Animal>();
}
