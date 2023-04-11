using System;
using System.Collections.Generic;

namespace VetMedPlus.API.Models;

public partial class Right
{
    public Guid RightsId { get; set; }

    public string RightsName { get; set; } = null!;

    public string? RightsDescription { get; set; }

    public virtual ICollection<UserRight> UserRights { get; } = new List<UserRight>();
}
